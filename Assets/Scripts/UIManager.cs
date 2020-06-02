using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    GameObject pnl_Tower;
    GameObject slider;

    GameObject tower;

    private static UIManager instance;

    public static UIManager _Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<UIManager>();
            }
            return instance;
        }
    }

    public void OpenMenu(GameObject selectedObject)
    {
        if (selectedObject.name.Contains("Tower"))
        {
            pnl_Tower.SetActive(true);
            tower = selectedObject;
            slider = pnl_Tower.transform.GetChild(2).GetChild(0).gameObject;
            slider.GetComponent<Slider>().value = tower.GetComponent<Tower>().archerCount;


        }


    }
    private void Update()
    {
        if(pnl_Tower.activeSelf)
            slider.GetComponent<Slider>().value = (int)slider.GetComponent<Slider>().value;

    }

    public void CloseMenu(GameObject menu)
    {
        menu.SetActive(false);
    }
    
    public void Save()
    {
        tower.GetComponent<Tower>().archerCount = (int)slider.GetComponent<Slider>().value;

    }



}
