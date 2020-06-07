using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{

    public static int coin;
    public int startCoin = 150;

    public static int wood;
    public int startWood = 150;

    public static int cityHealth;
    public int startCityHealth = 20;

    public static int copperMineHealth;
    public int startCopperMineHealth = 5;

    public static int tinMineHealth;
    public int startTinMineHealth = 5;

    public static int sawmillHealth;
    public int startSawmillHealth = 5;

    public static int population;
    public int startPopulation;

    public static int soldierCount;
    public int startsoldierCount;

    public static List<SoldierBlueprints> soldier = new List<SoldierBlueprints>();


    [SerializeField]
    Text txt_coin;
    [SerializeField]
    Text txt_wood;
    [SerializeField]
    Text txt_population;
    [SerializeField]
    Text txt_startPopulation;
    void Start()
    {
        coin = startCoin;
        wood = startWood;
        cityHealth = startCityHealth;
        copperMineHealth = startCopperMineHealth;
        tinMineHealth = startTinMineHealth;
        sawmillHealth = startCityHealth;
        population = startPopulation;
        soldierCount = startsoldierCount;
    }

    void Update()
    {
        txt_coin.text = coin.ToString();
        txt_wood.text = wood.ToString();
        txt_population.text = population.ToString();
        txt_startPopulation.text = startPopulation.ToString();
    }

}
