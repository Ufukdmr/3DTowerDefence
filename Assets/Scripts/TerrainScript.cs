using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TerrainScript : MonoBehaviour
{
    [SerializeField]
    LayerMask canBe;
    [SerializeField]
    LayerMask canNot;
    float y;
    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager._Instance;
    }

    public Vector3 GetBuildPosition;
 
    public void PlaceTower(Vector3 position)
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (position.y > 30&&position.y<50)
        {
            
            GetBuildPosition = new Vector3(position.x, position.y + 30, position.z);
            buildManager.BuildTowerOn(this);
        }
        else
        {
            Debug.Log("Koyamazsin");
        }
    }

    void OnMouseDown()
    {
        if (!buildManager.canBuild)
            return;
    

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hitInfo;

            if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity, canNot))
            {
                Debug.Log("Koyamazsin");
            }
            else if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity, canBe))
            {

                Vector3 objectPosition = hitInfo.point;
                PlaceTower(objectPosition);
            }
        
    }
  
}
