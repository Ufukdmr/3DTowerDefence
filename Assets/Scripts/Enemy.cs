using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed = 10f;
    public int health = 100;

    [SerializeField]
    private Transform target;

    private int wavepointIndex = 0;

    int a = 0;

    private bool copperMineExsist;
    private bool tinMineExsist;
    private bool sawmillExsist;



    MineStatus mineStatus;

    private void Start()
    {
        mineStatus = MineStatus._Instance;
        copperMineExsist = mineStatus.copperMineExsist;
        tinMineExsist = mineStatus.tinMineExsist;
        sawmillExsist = mineStatus.sawmillExsist;

        if ((copperMineExsist&&!tinMineExsist)||(copperMineExsist&&!sawmillExsist))
        {
            a = Random.Range(1, 3);
        }
        else if ((tinMineExsist && !copperMineExsist)||(sawmillExsist&&!copperMineExsist))
        {
           a = Random.Range(1, 4);
            if (a == 2)
                a = 0;
        }
        else if ((tinMineExsist && copperMineExsist)||(sawmillExsist&&copperMineExsist))
        {
            a = Random.Range(1, 4);
        }
      
        target = Waypoints.points[0];

    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        //transform.rotation = target.rotation;

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {

        if (a == 2)
        {
            if (wavepointIndex >= Waypoints.pointsCopperMine.Length - 1)
            {
                EndPath();
            }
            else
            {
                wavepointIndex++;
                target = Waypoints.pointsCopperMine[wavepointIndex];
                if (wavepointIndex == 28 && copperMineExsist)
                {
                    if (PlayerStats.copperMineHealth == 0)
                    {                    
                       MineStatus._Instance.copperMineExsist = false;
                    }
                    else if (PlayerStats.copperMineHealth > 0)
                    {
                        PlayerStats.copperMineHealth--;
                        Debug.Log(PlayerStats.copperMineHealth);
                        Destroy(gameObject);
                    }
                    else
                    {
                        return;
                    }
                }

            }
        }
        else if (a == 3)
        {
            if (wavepointIndex >= Waypoints.pointsTinMine.Length - 1)
            {
                EndPath();
            }
            else
            {
                wavepointIndex++;
                target = Waypoints.pointsTinMine[wavepointIndex];
                if (wavepointIndex == 29 && tinMineExsist)
                {
                    if (PlayerStats.tinMineHealth == 0)
                    {
                        MineStatus._Instance.tinMineExsist = false;
                    }
                    else if (PlayerStats.tinMineHealth > 0)
                    {
                        PlayerStats.tinMineHealth--;                      
                        Destroy(gameObject);
                    }
                    else
                    {
                        return;
                    }
                    
                }
                else if (wavepointIndex == 54 && sawmillExsist)
                {
                    if (PlayerStats.sawmillHealth == 0)
                    {
                        MineStatus._Instance.sawmillExsist = false;
                    }
                    else if (PlayerStats.sawmillHealth > 0)
                    {
                        PlayerStats.sawmillHealth--;
                        Destroy(gameObject);
                    }
                    else
                    {
                        return;
                    }
                }

            }
        }
        else
        {
            if (wavepointIndex >= Waypoints.points.Length - 1)
            {
                EndPath();
            }
            else
            {
                wavepointIndex++;
                target = Waypoints.points[wavepointIndex];
            }
        }


    }

    void EndPath()
    {
        PlayerStats.cityHealth--;
        Destroy(gameObject);

    }
}
