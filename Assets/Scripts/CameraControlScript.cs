using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
[AddComponentMenu("Camera Controller")]
public class CameraControlScript : MonoBehaviour
{
    private Transform cameraTransform;
    public float camMovSpeed = 0;
    public float camRotateSpeed = 0;

    [SerializeField]
    GameObject cameraContObj;
    public float maxX;
    public float minX;
    public float maxY;
    public float minY;
    public float maxZ;
    public float minZ;
    void LateUpdate()
    {

        var c = cameraContObj.transform;

        #region Movement


        if (Input.mousePosition.x <= 0 && c.position.x >= minX)
        {

            Vector3 move = new Vector3(-camMovSpeed, 0, 0) * Time.deltaTime;
            c.Translate(move, Space.Self);
            if (c.position.z >= maxZ)
                c.position = new Vector3(c.position.x, c.position.y, maxZ);
            if (c.position.z <= minZ)
                c.position = new Vector3(c.position.x, c.position.y, minZ);
        }
        else if (Input.mousePosition.x >= 1600 && c.position.x <= maxX)
        {
            Vector3 move = new Vector3(camMovSpeed, 0, 0) * Time.deltaTime;
            c.Translate(move, Space.Self);
            if (c.position.z >= maxZ)
                c.position = new Vector3(c.position.x, c.position.y, maxZ);
            if (c.position.z <= minZ)
                c.position = new Vector3(c.position.x, c.position.y, minZ);
        }
        if (Input.mousePosition.y <= 5 && c.position.z <= maxZ)
        {
            Vector3 move = new Vector3(0, 0, -camMovSpeed) * Time.deltaTime;
            c.Translate(move, Space.Self);
            if (c.position.x >= maxX)
                c.position = new Vector3(maxX, c.position.y, c.position.z);
            if (c.position.x <= minX)
                c.position = new Vector3(minX, c.position.y, c.position.z);
        }
        else if (Input.mousePosition.y >= 900 && c.position.z >= minZ)
        {

            Vector3 move = new Vector3(0, 0, camMovSpeed) * Time.deltaTime;
            c.Translate(move, Space.Self);
            if (c.position.x >= maxX)
                c.position = new Vector3(maxX, c.position.y, c.position.z);
            if (c.position.x <= minX)
                c.position = new Vector3(minX, c.position.y, c.position.z);
        }

        #endregion

        #region Rotate

        if (Input.GetMouseButton(1))
        {


            c.Rotate(0, Input.GetAxis("Mouse X") * camMovSpeed, 0);
            //c.Rotate(-Input.GetAxis("Mouse Y") * camMovSpeed, 0, 0);
            if (Input.GetMouseButtonDown(0))
                Cursor.lockState = CursorLockMode.Locked;


        }

        #endregion

        #region Zoom
        this.GetComponent<Camera>().fieldOfView -= Input.GetAxis("Mouse ScrollWheel") * 5;
        #endregion


    }


}
