using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopPeople : MonoBehaviour
{
    private static ShopPeople instance;

    public static ShopPeople _Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<ShopPeople>();
            }
            return instance;
        }
    }

    public PeopleBlueprints worker;
    public PeopleBlueprints farmer;
    public PeopleBlueprints scientist;
    public SoldierBlueprints archer;
    public SoldierBlueprints crossbowman;
    public SoldierBlueprints catapultMan;


    public void TrainingArcher(int a)
    {
        for (int i = 0; i < a; i++)
        {
            if (PlayerStats.coin < archer.people.costTraningCoins && PlayerStats.wood < archer.people.costEquipment)
            {
                Debug.Log("Not enough!!!");
                return;
            }
            PlayerStats.coin -= archer.people.costTraningCoins;
            PlayerStats.wood -= archer.people.costEquipment;
            People.unattachedArcher.Add(archer);
            People.totalArcher.Add(archer);
                      
        }
       

    }

    public void TrainingCrossbowman(int a)
    {
        for (int i = 0; i < a; i++)
        {
            if (PlayerStats.coin < crossbowman.people.costTraningCoins && PlayerStats.wood < crossbowman.people.costEquipment)
            {
                Debug.Log("Not enough!!!");
                return;
            }
            PlayerStats.coin -= crossbowman.people.costTraningCoins;
            PlayerStats.wood -= crossbowman.people.costEquipment;
            People.unattachedCrossbowman.Add(crossbowman);
            People.totalCrossbowman.Add(crossbowman);

        }
    }

    public void TrainingCatapultMan(int a)
    {
        for (int i = 0; i < a; i++)
        {
            if (PlayerStats.coin < catapultMan.people.costTraningCoins && PlayerStats.wood < catapultMan.people.costEquipment)
            {
                Debug.Log("Not enough!!!");
                return;
            }
            PlayerStats.coin -= catapultMan.people.costTraningCoins;
            PlayerStats.wood -= catapultMan.people.costEquipment;
            People.unattachedCatapultman.Add(catapultMan);
            People.totalCatapultman.Add(catapultMan);

        }
    }
    public void TrainingWorker()
    {

    }
    public void TrainingScientist()
    {

    }
    public void TrainingFarmer()
    {

    }
}
