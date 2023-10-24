using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Unit : MonoBehaviour
{
    private NavMeshAgent myAgent;
    public UnitScriptableObject unit;

    // Start is called before the first frame update
    void Start()
    {
        
        UnitSelections.Instance.unitList.Add(this.gameObject);
        
        
    }

    void OnDestroy()
    {
        UnitSelections.Instance.unitList.Remove(this.gameObject);
    }
}
