using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public Blueprints arrowTower;
    public Blueprints BowCatapult;
    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager._Instance;
        arrowTower.txt_CostCoin.text = arrowTower.costCoin.ToString();
        arrowTower.txt_CostWood.text = arrowTower.costWood.ToString();
        BowCatapult.txt_CostCoin.text = BowCatapult.costCoin.ToString();
        BowCatapult.txt_CostWood.text = BowCatapult.costWood.ToString();


    }
    public void SelectArrowTower()
    {
        buildManager.SelectTowerToBuild(arrowTower);
    }
    public void SelectBowCatapult()
    {
        buildManager.SelectTowerToBuild(BowCatapult);
    }
}
