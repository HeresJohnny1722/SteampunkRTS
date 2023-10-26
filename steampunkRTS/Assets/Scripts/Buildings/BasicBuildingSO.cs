using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Building", menuName = "New Building/Basic")]

public class BasicBuildingSO : ScriptableObject
{
    public enum buildingType
    {
        Barracks
    }

    

    [Space(15)]
    [Header("Building Settings")]

    public buildingType type;
    public new string name;
    public GameObject buildingPrefab;
    public UnitScriptableObject[] unit = new UnitScriptableObject[0];

    [Space(15)]
    [Header("Building Base Stats")]
    [Space(15)]

    public float health, armor, attack;
}
