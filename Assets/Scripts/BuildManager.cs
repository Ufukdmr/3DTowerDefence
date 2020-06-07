using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour
{
    public static BuildManager _Instance;

    void Awake()
    {
        if (_Instance != null)
        {
            return;
        }
        _Instance = this;
    }
    public GameObject arrowTowerPrefabs;
    public GameObject bowCatapultPrefabs;
    private Blueprints towerToBuild;
    float y;



    public bool canBuild { get { return towerToBuild != null; } }
    //public bool hasCoin { get { return PlayerStats.coin>=towerToBuild.costCoin; } }


    public void BuildTowerOn(TerrainScript terrainScript)
    {
        if (PlayerStats.coin < towerToBuild.costCoin && PlayerStats.wood < towerToBuild.costWood)
        {
            Debug.Log("Not enough!!!");
            SelectTowerToBuild(null);
                return;
        }
        PlayerStats.coin -= towerToBuild.costCoin;
        PlayerStats.wood -= towerToBuild.costWood;
        GameObject tower = (GameObject)Instantiate(towerToBuild.prefab, terrainScript.GetBuildPosition, towerToBuild.prefab.transform.rotation);

        if (tower.gameObject.name.Contains("Tower"))
            y = 36.03f;
        else
            y = 32;


        tower.transform.position = new Vector3(tower.transform.position.x, terrainScript.transform.position.y + y, tower.transform.position.z);
        SelectTowerToBuild(null);
    }
    public void SelectTowerToBuild(Blueprints tower)
    {
        towerToBuild = tower;
    }


}
