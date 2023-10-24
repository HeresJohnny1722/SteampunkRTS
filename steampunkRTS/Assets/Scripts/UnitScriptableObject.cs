using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Unit", menuName = "New Game/Unit")]

public class UnitScriptableObject : ScriptableObject
{
    public enum unitType
    {
        Worker,
        Warrior,
        Healer,
    };

    [Space(15)]
    [Header("Unit Settings")]
    public unitType type;

    public string name;

    public GameObject unitPrefab;

    [Header("Unit Stats")]
    public int cost;
    public int attack;
    public int health;
    public int atkRange;
    public int movementSpeed;
    public int turnSpeed;
}
