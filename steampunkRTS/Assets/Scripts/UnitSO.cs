using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Unit", menuName = "Create New Unit")]

public class UnitSO : ScriptableObject
{
    public enum unitType
    {
        Worker,
        Warrior,
        Healer,
    };

    
    public bool isUnit;

    public unitType type;

    public string unitName;

    public GameObject unitPrefab;

    public int cost;
    public int attack;
    public int health;
    public int armor;
    
}
