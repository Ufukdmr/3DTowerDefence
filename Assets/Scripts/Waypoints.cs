using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public static Transform[] points;
    public static Transform[] pointsCopperMine;
    public static Transform[] pointsTinMine;
 

    void Awake()
    {
        points = new Transform[transform.GetChild(0).childCount];
        pointsCopperMine = new Transform[transform.GetChild(1).childCount];
        pointsTinMine = new Transform[transform.GetChild(2).childCount];



        for (int i = 0; i < points.Length; i++)
        {

            points[i] = transform.GetChild(0).GetChild(i);

        }
        for (int i = 0; i < pointsCopperMine.Length; i++)
        {
            pointsCopperMine[i] = transform.GetChild(1).GetChild(i);
        }
        for (int i = 0; i < pointsTinMine.Length; i++)
        {
            pointsTinMine[i] = transform.GetChild(2).GetChild(i);
        }
    }
}
