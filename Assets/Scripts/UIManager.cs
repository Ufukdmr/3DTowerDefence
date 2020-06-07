using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.TextCore.LowLevel;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{

    [SerializeField]
    GameObject[] panels;

    [SerializeField]
    GameObject panelPrefab;

    GameObject SelectedObject;

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
        SelectedObject = selectedObject;
        if (selectedObject.name.Contains("Military"))
        {
            panels[1].SetActive(true);
            panels[1].transform.GetChild(1).GetChild(0).GetChild(1).GetChild(1).GetChild(0).GetComponent<Text>().text = People.totalArcher.Count.ToString();
            panels[1].transform.GetChild(1).GetChild(1).GetChild(1).GetChild(1).GetChild(0).GetComponent<Text>().text = People.totalCrossbowman.Count.ToString();
            panels[1].transform.GetChild(1).GetChild(2).GetChild(1).GetChild(1).GetChild(0).GetComponent<Text>().text = People.totalCatapultman.Count.ToString();
        }
        else if (selectedObject.name.Contains("Tower"))
        {

            panels[0].SetActive(true);
            panels[0].transform.GetChild(0).GetComponent<Text>().text = "Tower";
            panels[0].transform.GetChild(3).GetComponent<Image>().sprite = selectedObject.GetComponent<Tower>().sprite;

            List<SoldierBlueprints> allUnattachedSoldier = new List<SoldierBlueprints>();
            allUnattachedSoldier.AddRange(People.unattachedArcher);
            allUnattachedSoldier.AddRange(People.unattachedCrossbowman);

            CreatePanelPrefab(0);
            CreatePanelPrefab(1);

            foreach (SoldierBlueprints soldier in allUnattachedSoldier)
            {
                CreateSoldier(soldier, 1);

            }

            foreach (SoldierBlueprints soldierTower in selectedObject.GetComponent<Tower>().soldierArray)
            {
                CreateSoldier(soldierTower, 0);
            }


        }
        else if (selectedObject.name.Contains("Catapult"))
        {
            panels[0].SetActive(true);
            panels[0].transform.GetChild(0).GetComponent<Text>().text = "Catapult";
            panels[0].transform.GetChild(3).GetComponent<Image>().sprite = selectedObject.GetComponent<Tower>().sprite;

            CreatePanelPrefab(0);
            CreatePanelPrefab(1);

            foreach (SoldierBlueprints soldier in People.unattachedCatapultman)
            {

                CreateSoldier(soldier, 1);
            }

            foreach (SoldierBlueprints soldierTower in selectedObject.GetComponent<Tower>().soldierArray)
            {
                CreateSoldier(soldierTower, 0);
            }
        }
    }

    public void CloseMenu(GameObject menu)
    {
        menu.SetActive(false);
        SelectedObject = null;
        if (menu == panels[0])
        {
            for (int i = 0; i < panels[0].transform.GetChild(6).GetChild(0).childCount; i++)
            {
                Destroy(panels[0].transform.GetChild(6).GetChild(0).GetChild(i).gameObject);
            }
            for (int i = 0; i < panels[0].transform.GetChild(6).GetChild(1).childCount; i++)
            {
                Destroy(panels[0].transform.GetChild(6).GetChild(1).GetChild(i).gameObject);
            }

        }

    }

    public void Save()
    {

        if (panels[1].activeSelf)
        {
            int a = 0, b = 0, d = 0;

            a = Convert.ToInt32(panels[1].transform.GetChild(1).GetChild(0).GetChild(1).GetChild(1).GetChild(0).GetComponent<Text>().text);
            if (a > People.totalArcher.Count)
            {
                ShopPeople._Instance.TrainingArcher(Convert.ToInt32(a - People.totalArcher.Count));
            }
            else if (a < People.totalArcher.Count)
            {
                int c = People.totalArcher.Count;

                People.totalArcher.RemoveRange(a, c - a);
                int k = People.unattachedArcher.Count;
                for (int i = 0; i < (c - a); i++)
                {
                    People.unattachedArcher.RemoveAt((k - 1) - i);
                }



            }


            b = Convert.ToInt32(panels[1].transform.GetChild(1).GetChild(1).GetChild(1).GetChild(1).GetChild(0).GetComponent<Text>().text);
            if (b > People.totalCrossbowman.Count)
            {
                ShopPeople._Instance.TrainingCrossbowman(Convert.ToInt32(b - People.totalCrossbowman.Count));
            }
            else if (b < People.totalCrossbowman.Count)
            {
                int c = People.totalCrossbowman.Count;

                People.totalCrossbowman.RemoveRange(b, c - b);
                int k = People.unattachedCrossbowman.Count;
                for (int i = 0; i < (c - a); i++)
                {
                    People.unattachedCrossbowman.RemoveAt((k - 1) - i);
                }

            }
            d = Convert.ToInt32(panels[1].transform.GetChild(1).GetChild(2).GetChild(1).GetChild(1).GetChild(0).GetComponent<Text>().text);
            if (d > People.totalCatapultman.Count)
            {
                ShopPeople._Instance.TrainingCatapultMan(Convert.ToInt32(d - People.totalCatapultman.Count));
            }
            else if (d < People.totalCatapultman.Count)
            {
                int c = People.totalCatapultman.Count;

                People.totalCatapultman.RemoveRange(d, c - d);
                int k = People.unattachedCatapultman.Count;
                for (int i = 0; i < (c - d); i++)
                {
                    People.unattachedCatapultman.RemoveAt((k - 1) - i);
                }



            }
        }

    }

    public void increaseSoldier(Text txt_Soldier)
    {
        int a = Convert.ToInt32(txt_Soldier.text);

        a += 1;
        txt_Soldier.text = a.ToString();
    }
    public void DecreaseSoldier(Text txt_Soldier)
    {
        int a = Convert.ToInt32(txt_Soldier.text);
        if (txt_Soldier == panels[1].transform.GetChild(1).GetChild(0).GetChild(1).GetChild(1).GetChild(0).GetComponent<Text>())
        {
            if (a == People.archer.Count)
            {
                return;
            }
            else
            {
                a -= 1;
                txt_Soldier.text = a.ToString();
            }
        }
        else if (txt_Soldier == panels[1].transform.GetChild(1).GetChild(1).GetChild(1).GetChild(1).GetChild(0).GetComponent<Text>())
        {
            if (a == People.Crossbowman.Count)
            {
                return;
            }
            else
            {
                a -= 1;
                txt_Soldier.text = a.ToString();
            }
        }

    }

    public void Placement(SoldierBlueprints soldier, GameObject button)
    {
        for (int i = 0; i < panels[0].transform.GetChild(6).GetChild(1).childCount; i++)
        {
            Destroy(panels[0].transform.GetChild(6).GetChild(1).GetChild(i).gameObject);
        }
        
        CreateSoldier(soldier, 0);
        SelectedObject.GetComponent<Tower>().soldierArray.Add(soldier);
        if (soldier.name == "Archer")
        {
            People.unattachedArcher.RemoveAt(People.unattachedArcher.Count - 1);
            People.archer.Add(soldier);
        }
        else if (soldier.name == "Crossbowman")
        {
            People.unattachedCrossbowman.RemoveAt(People.unattachedCrossbowman.Count - 1);
            People.Crossbowman.Add(soldier);
        }
        else if (soldier.name == "Catapultman")
        {
            People.unattachedCatapultman.RemoveAt(People.unattachedCatapultman.Count - 1);
            People.Catapultman.Add(soldier);
        }
        if (SelectedObject.name.Contains("Tower"))
        {
            List<SoldierBlueprints> allUnattachedSoldier = new List<SoldierBlueprints>();
            allUnattachedSoldier.AddRange(People.unattachedArcher);
            allUnattachedSoldier.AddRange(People.unattachedCrossbowman);

            CreatePanelPrefab(1);

            foreach (SoldierBlueprints _soldier in allUnattachedSoldier)
            {
                CreateSoldier(_soldier, 1);

            }
        }
        else if (SelectedObject.name.Contains("Catapult"))
        {
            
            CreatePanelPrefab(1);

            foreach (SoldierBlueprints _soldier in People.unattachedCatapultman)
            {

                CreateSoldier(soldier, 1);
            }
        }
    }

    void CreateSoldier(SoldierBlueprints soldier, int a)
    {

        int b = panels[0].transform.GetChild(6).GetChild(a).childCount;
        int c = panels[0].transform.GetChild(6).GetChild(a).GetChild(b - 1).childCount;
        GameObject placementSoldier = new GameObject();
        Image Img = placementSoldier.AddComponent<Image>();
        Img.sprite = soldier.people.Img;
        placementSoldier.AddComponent<LayoutElement>();
        placementSoldier.GetComponent<LayoutElement>().preferredHeight = 15;
        placementSoldier.GetComponent<LayoutElement>().preferredWidth = 20;
        placementSoldier.AddComponent<Button>();
        placementSoldier.GetComponent<RectTransform>().SetParent(panels[0].transform.GetChild(6).GetChild(a).GetChild(b - 1).transform);
        placementSoldier.SetActive(true);
        Button btn = placementSoldier.GetComponent<Button>();
        placementSoldier.name = soldier.name;
        btn.onClick.AddListener(delegate { Placement(soldier, placementSoldier); });

        if (panels[0].transform.GetChild(6).GetChild(a).GetChild(b - 1).childCount == 4)
        {

            CreatePanelPrefab(a);
        }

    }
    void CreatePanelPrefab(int a)
    {
        GameObject _panel = Instantiate(panelPrefab);

        _panel.GetComponent<RectTransform>().SetParent(panels[0].transform.GetChild(6).GetChild(a).transform);
        _panel.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
    }
}
