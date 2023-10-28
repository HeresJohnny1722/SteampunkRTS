using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Unit : MonoBehaviour
{
    private NavMeshAgent myAgent;
    public UnitScriptableObject unit;

    private UnitScriptableObject.unitType unitType;

    private string name;
    private float cost, attack, health, atkRange, movementSpeed, turnSpeed;
    

    
    void Start()
    {
        SetStats();
        Selections.Instance.unitList.Add(this.gameObject);


    }

    void OnDestroy()
    {
        Selections.Instance.unitList.Remove(this.gameObject);
    }

    private void SetStats()
    {
        NavMeshAgent unitAgent = gameObject.GetComponent<NavMeshAgent>();
        unitAgent.speed = unit.movementSpeed;
        unitAgent.angularSpeed = unit.turnSpeed;
        cost = unit.cost;
        attack = unit.attack;
        health = unit.health;
        atkRange = unit.atkRange;
        name = unit.name;
    }
}
