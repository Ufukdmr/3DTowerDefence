using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwing : MonoBehaviour
{
    private Transform target;

    public float speed = 50f;
    public float impactRadius = 0f;
    public void Seek(Transform _target)
    {
        target = _target;
    }
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame,Space.World);

        transform.LookAt(target);
    }


    void HitTarget()
    {

        if (impactRadius > 0f)
        {
            Impact();
        }
        else
        {
            Damage(target);
            
        }

        Destroy(gameObject);

    }
    void Impact()
    {
        Collider[] colliders= Physics.OverlapSphere(transform.position, impactRadius);

        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }
    void Damage(Transform enemy)
    {
        Destroy(enemy.gameObject);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, impactRadius);
    }

}
