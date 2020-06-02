using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : MonoBehaviour
{
    Vector3 position;

    void Update()
    {
        FollowMouse();
    }

    private void FollowMouse()
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo))
        {
            position = new Vector3(hitInfo.point.x, 10, hitInfo.point.z);
            transform.position = position;
        }
    }
}
