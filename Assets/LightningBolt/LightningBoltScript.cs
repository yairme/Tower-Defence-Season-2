using UnityEngine;
using System.Collections.Generic;

namespace DigitalRuby.LightningBolt
{
    public enum LightningBoltAnimationMode
    {
        None,
        Random,
        Loop,
        PingPong
    }

    [RequireComponent(typeof(LineRenderer))]
    public class LightningBoltScript : ChainLightning
    {
        [Header("LineRendere Fields")]
        [Range(0, 8)]
        [Tooltip("How manu generations? Higher numbers create more line segments.")]
        public int Generations = 6;

        [Range(0.01f, 1.0f)]
        [Tooltip("How long each bolt should last before creating a new bolt. In ManualMode, the bolt will simply disappear after this amount of seconds.")]
        public float Duration = 0.05f;
        private float timer;

        [Range(0.0f, 1.0f)]
        [Tooltip("How chaotic should the lightning be? (0-1)")]
        public float ChaosFactor = 0.15f;

        [Tooltip("In manual mode, the trigger method must be called to create a bolt")]
        public bool ManualMode;

        [Range(1, 64)]
        [Tooltip("The number of rows in the texture. Used for animation.")]
        public int Rows = 1;

        [Range(1, 64)]
        [Tooltip("The number of columns in the texture. Used for animation.")]
        public int Columns = 1;

        [Tooltip("The animation mode for the lightning")]
        public LightningBoltAnimationMode AnimationMode = LightningBoltAnimationMode.PingPong;

        /// <summary>
        /// Assign your own random if you want to have the same lightning appearance
        /// </summary>
        [HideInInspector]
        [System.NonSerialized]
        public System.Random RandomGenerator = new System.Random();

        private LineRenderer lineRenderer;
        private List<KeyValuePair<Vector3, Vector3>> segments = new List<KeyValuePair<Vector3, Vector3>>();
        private int startIndex;
        private Vector2 size;
        private Vector2[] offsets;
        private int animationOffsetIndex;
        private int animationPingPongDirection = 1;
        private bool orthographic;

        private void GetPerpendicularVector(ref Vector3 directionNormalized, out Vector3 side)
        {
            if (directionNormalized == Vector3.zero)
            {
                side = Vector3.right;
            }
            else
            {
                // use cross product to find any perpendicular vector around directionNormalized:
                // 0 = x * px + y * py + z * pz
                // => pz = -(x * px + y * py) / z
                // for computational stability use the component farthest from 0 to divide by
                float x = directionNormalized.x;
                float y = directionNormalized.y;
                float z = directionNormalized.z;
                float px, py, pz;
                float ax = Mathf.Abs(x), ay = Mathf.Abs(y), az = Mathf.Abs(z);
                if (ax >= ay && ay >= az)
                {
                    // x is the max, so we can pick (py, pz) arbitrarily at (1, 1):
                    py = 1.0f;
                    pz = 1.0f;
                    px = -(y * py + z * pz) / x;
                }
                else if (ay >= az)
                {
                    // y is the max, so we can pick (px, pz) arbitrarily at (1, 1):
                    px = 1.0f;
                    pz = 1.0f;
                    py = -(x * px + z * pz) / y;
                }
                else
                {
                    // z is the max, so we can pick (px, py) arbitrarily at (1, 1):
                    px = 1.0f;
                    py = 1.0f;
                    pz = -(x * px + y * py) / z;
                }
                side = new Vector3(px, py, pz).normalized;
            }
        }

        private void GenerateLightningBolt(Vector3 start, Vector3 end, int generation, int totalGenerations, float offsetAmount)
        {
            if (generation < 0 || generation > 8)
            {
                return;
            }
            else if (orthographic)
            {
                start.z = end.z = Mathf.Min(start.z, end.z);
                start.x = end.x = Mathf.Min(start.x, end.x);
                start.y = end.y = Mathf.Min(start.y, end.y);
            }

            segments.Add(new KeyValuePair<Vector3, Vector3>(start, end));
            if (generation == 0)
            {
                return;
            }

            Vector3 randomVector;
            if (offsetAmount <= 0.0f)
            {
                offsetAmount = (end - start).magnitude * ChaosFactor;
            }

            while (generation-- > 0)
            {
                int previousStartIndex = startIndex;
                startIndex = segments.Count;
                for (int i = previousStartIndex; i < startIndex; i++)
                {
                    start = segments[i].Key;
                    end = segments[i].Value;

                    // determine a new direction for the split
                    Vector3 midPoint = (start + end) * 0.5f;

                    // adjust the mid point to be the new location
                    RandomVector(ref start, ref end, offsetAmount, out randomVector);
                    midPoint += randomVector;

                    // add two new segments
                    segments.Add(new KeyValuePair<Vector3, Vector3>(start, midPoint));
                    segments.Add(new KeyValuePair<Vector3, Vector3>(midPoint, end));
                }

                // halve the distance the lightning can deviate for each generation down
                offsetAmount *= 0.5f;
            }
        }

        public void RandomVector(ref Vector3 start, ref Vector3 end, float offsetAmount, out Vector3 result)
        {
            if (orthographic)
            {
                Vector3 directionNormalized = (end - start).normalized;
                Vector3 side = new Vector3(-directionNormalized.y, directionNormalized.x, directionNormalized.z);
                float distance = ((float)RandomGenerator.NextDouble() * offsetAmount * 2.0f) - offsetAmount;
                result = side * distance;
            }
            else
            {
                Vector3 directionNormalized = (end - start).normalized;
                Vector3 side;
                GetPerpendicularVector(ref directionNormalized, out side);

                // generate random distance
                float distance = (((float)RandomGenerator.NextDouble() + 0.1f) * offsetAmount);

                // get random rotation angle to rotate around the current direction
                float rotationAngle = ((float)RandomGenerator.NextDouble() * 360.0f);

                // rotate around the direction and then offset by the perpendicular vector
                result = Quaternion.AngleAxis(rotationAngle, directionNormalized) * side * distance;
            }
        }

        private void SelectOffsetFromAnimationMode()
        {
            int index;

            if (AnimationMode == LightningBoltAnimationMode.None)
            {
                lineRenderer.material.mainTextureOffset = offsets[0];
                return;
            }
            else if (AnimationMode == LightningBoltAnimationMode.PingPong)
            {
                index = animationOffsetIndex;
                animationOffsetIndex += animationPingPongDirection;
                if (animationOffsetIndex >= offsets.Length)
                {
                    animationOffsetIndex = offsets.Length - 2;
                    animationPingPongDirection = -1;
                }
                else if (animationOffsetIndex < 0)
                {
                    animationOffsetIndex = 1;
                    animationPingPongDirection = 1;
                }
            }
            else if (AnimationMode == LightningBoltAnimationMode.Loop)
            {
                index = animationOffsetIndex++;
                if (animationOffsetIndex >= offsets.Length)
                {
                    animationOffsetIndex = 0;
                }
            }
            else
            {
                index = RandomGenerator.Next(0, offsets.Length);
            }

            if (index >= 0 && index < offsets.Length)
            {
                lineRenderer.material.mainTextureOffset = offsets[index];
            }
            else
            {
                lineRenderer.material.mainTextureOffset = offsets[0];
            }
        }

        private void UpdateLineRenderer()
        {
            int segmentCount = (segments.Count - startIndex) + 1;
            lineRenderer.positionCount = segmentCount;

            if (segmentCount < 1)
            {
                return;
            }

            int index = 0;
            lineRenderer.SetPosition(index++, segments[startIndex].Key);

            for (int i = startIndex; i < segments.Count; i++)
            {
                lineRenderer.SetPosition(index++, segments[i].Value);
            }

            segments.Clear();

            SelectOffsetFromAnimationMode();
        }

        private void Start()
        {
            InvokeRepeating("Trigger", 0f, 0.5f);
            orthographic = (Camera.main != null && Camera.main.orthographic);
            lineRenderer = GetComponent<LineRenderer>();
            lineRenderer.positionCount = 0;
            UpdateFromMaterialChange();
        }

        private void Update()
        {
            orthographic = (Camera.main != null && Camera.main.orthographic);
            if (timer <= 0.0f)
            {
                if (ManualMode)
                {
                    timer = Duration;
                    lineRenderer.positionCount = 0;
                }
                else
                {
                    Trigger();
                }
            }
            timer -= Time.deltaTime;
        }

        /// <summary>
        /// Trigger a lightning bolt. Use this if ManualMode is true.
        /// </summary>
        public void Trigger()
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

            float ShortestDistance = Mathf.Infinity;

            GameObject nearestEnemy = null;
            foreach (GameObject enemy in enemies)
            {
                float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
                if (distanceToEnemy < ShortestDistance)
                {
                    ShortestDistance = distanceToEnemy;
                    nearestEnemy = enemy;
                }
            }
            if (nearestEnemy != null && ShortestDistance <= range / 1)
            {
                target = nearestEnemy.transform;
                if (!lineRenderer.enabled)
                    lineRenderer.enabled = true;
                StartCoroutine(DamageTick());
            }
            else
            {
                target = null;
                if (!lineRenderer.enabled)
                    lineRenderer.enabled = false;
            }

            GenerateLightningBolt(firepoint.position, target.position, Generations, Generations, 0.0f);
            UpdateLineRenderer();
        }

        /// <summary>
        /// Call this method if you change the material on the line renderer
        /// </summary>
        public void UpdateFromMaterialChange()
        {
            size = new Vector2(1.0f / (float)Columns, 1.0f / (float)Rows);
            lineRenderer.material.mainTextureScale = size;
            offsets = new Vector2[Rows * Columns];
            for (int y = 0; y < Rows; y++)
            {
                for (int x = 0; x < Columns; x++)
                {
                    offsets[x + (y * Columns)] = new Vector2((float)x / Columns, (float)y / Rows);
                }
            }
        }
    }
}