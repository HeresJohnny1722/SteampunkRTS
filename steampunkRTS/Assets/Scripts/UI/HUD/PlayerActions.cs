using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player Actions", menuName = "PlayerAction")]

public class PlayerActions : ScriptableObject
{
    [Header("Units")]
    public UnitScriptableObject.unitType[] basicUnits = new UnitScriptableObject.unitType[0];

    [Header("Buildings")]
    public BasicBuildingSO.buildingType[] basicBuildings = new BasicBuildingSO.buildingType[0];
}
