using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastManager : MonoBehaviour
{
    private GameObject SelectedObject;
    [SerializeField]
    LayerMask clickable;
    BuildManager buildManager;
    

    private void Start()
    {
        buildManager = BuildManager._Instance;
       
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0)&&!buildManager.canBuild)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity, clickable))
            {
                SelectedObject = hitInfo.collider.gameObject;
                UIManager._Instance.OpenMenu(SelectedObject.gameObject);
                Debug.Log(SelectedObject.gameObject.name);
            }
        }

    }
}
