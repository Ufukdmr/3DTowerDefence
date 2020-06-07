using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class Tower : MonoBehaviour
{
 

    [Header("Attributes")]
    public float range = 15f;
    public int archerCount = 0;
    public float fireCountdown = 0f;
    public float turnspeed = 3f;
    public float fireCountdownCatapult = 0f;
    public float fireCountdownArcherTower = 0f;
    public int towerLevel=1;
    public Sprite sprite;

   
    public List<SoldierBlueprints> soldierArray=new List<SoldierBlueprints>();
    public int soldierArrayMaxCount = 0;

   

    [Header("")]
    public string enemyTag = "Enemy";

    public GameObject arrowPrefab;
    public Transform firePoint;
    public Transform partToRotate;

    SoldierBlueprints temporary;
    void Start()
    {
        InvokeRepeating("UptadeTarget", 0, 0.5f);
       
    }

    void UptadeTarget()
    {
        FoundToppestRange();
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
        foreach (SoldierBlueprints soldier in soldierArray)
        {
            if (nearestEnemy != null && shortestDistance <=soldier.range)
            {
               soldier.target = nearestEnemy.transform;
            }
            else
            {
               soldier.target = null;
            }
        }
        
    }

    void FoundToppestRange()
    {
        for (int i = 0; i < soldierArray.Count- 1; i++)
        {
            for (int j = i; j < soldierArray.Count; j++)
            {
              
                if (soldierArray[i].range < soldierArray[j].range)
                {
                    temporary = soldierArray[j];
                    soldierArray[j] = soldierArray[i];
                    soldierArray[i] = temporary;
                }

            }

        }
    }
    void Update()
    {
        if (soldierArray.Count == 0)
            return;

        if (soldierArray[0].target == null)
            return;
       
        //if (partToRotate != null)
        //{

        //    //if (archerCount >= 3)
        //    //{
        //    //    Vector3 dir = target.position - transform.position;
        //    //    Quaternion lookRotation = Quaternion.LookRotation(dir);
        //    //    Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnspeed).eulerAngles;
        //    //    partToRotate.rotation = Quaternion.Euler(-90f, rotation.y, -90f);

        //    //    if (fireCountdown <= 0f)
        //    //    {
        //    //        Shoot();
        //    //        fireCountdown = fireCountdownCatapult / archerCount;
        //    //    }
        //    //    fireCountdown -= Time.deltaTime;
        //    //}

        //}
        //else
        //{
        if (soldierArray.Count > 0)
        {
            foreach (SoldierBlueprints soldier in soldierArray)
            {
                if (soldier.cooldown <= 0f && soldier.target != null)
                {
                    Shoot(soldier.target);
                    soldier.cooldown = 1f / (float)towerLevel;
                }

                soldier.cooldown -= Time.deltaTime;
            }

          
        }

       

        //}

    }

    
    void Shoot(Transform targetSoldier)
    {

        GameObject throws = (GameObject)Instantiate(arrowPrefab, firePoint.position, Quaternion.identity);
        Throwing throwing = throws.GetComponent<Throwing>();

        if (throwing != null)
        {
            throwing.Seek(targetSoldier);
        }
    }
    void OnDrawGizmosSelected()
    {
        for (int i = 0; i < soldierArray.Count; i++)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position,soldierArray[i].range);
        }
       
    }
}
