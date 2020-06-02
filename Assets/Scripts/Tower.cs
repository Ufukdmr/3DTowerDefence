using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class Tower : MonoBehaviour
{
    private Transform target;

    [Header("Attributes")]
    public float range = 15f;
    public int archerCount = 1;
    public float fireCountdown = 0f;
    public float turnspeed = 3f;
   

    [Header("")]
    public string enemyTag = "Enemy";

    public GameObject arrowPrefab;
    public Transform firePoint;
    public Transform partToRotate;

   
    void Start()
    {
        InvokeRepeating("UptadeTarget", 0, 0.5f);
    }

    void UptadeTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    void Update()
    {
        if (target == null)
            return;
        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / archerCount;
        }

        fireCountdown -= Time.deltaTime;

        if (partToRotate != null)
        {
            Vector3 dir = target.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(dir);
            Vector3 rotation =Quaternion.Lerp(partToRotate.rotation,lookRotation,Time.deltaTime*turnspeed).eulerAngles;
            partToRotate.rotation = Quaternion.Euler(-90f, rotation.y, -90f);
        }
       
    }

    void Shoot()
    {
       GameObject throws=(GameObject)Instantiate(arrowPrefab, firePoint.position, Quaternion.identity);
        Throwing throwing = throws.GetComponent<Throwing>();

        if (throwing != null)
        {
            throwing.Seek(target);
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
