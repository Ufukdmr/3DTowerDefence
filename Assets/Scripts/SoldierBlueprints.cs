using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SoldierBlueprints
{
    public string name;
    public int damage;
    public int range;
    public float cooldown;
    public PeopleBlueprints people;
    public Transform target;
}
