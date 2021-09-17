using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blueprint : MonoBehaviour
{
    protected Transform target;

    [Header("Attributes")]
    public float range;
    public float fireRate;
    protected float fireCountdown;

    [Header("Unity Setup Fields")]

    public string enemyTag = "Enemy";

    public Transform PartToRotate;
    public Transform firepoint;
    public float turnspeed = 10f;
    public GameObject bulletprefab;

}