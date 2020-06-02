using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineStatus : MonoBehaviour
{
    public bool copperMineExsist;
    public bool tinMineExsist;
    public bool sawmillExsist;
    private static MineStatus instance;

    public static MineStatus _Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<MineStatus>();
            }
            return instance;
        }
    }
    
}
