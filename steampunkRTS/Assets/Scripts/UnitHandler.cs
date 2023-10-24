using UnityEngine;
using UnityEngine.AI;

public class UnitHandler : MonoBehaviour
{

    //public UnitScriptableObject unitData;
    [SerializeField]
    private UnitScriptableObject worker, warrior, healer;

    

    private void Start()
    {
        GameObject newUnit = Instantiate(worker.unitPrefab, transform.position, Quaternion.identity);
        GameObject two = Instantiate(warrior.unitPrefab, transform.position, Quaternion.identity);
        GameObject three = Instantiate(healer.unitPrefab, transform.position, Quaternion.identity);
        SetUnitStats(newUnit);
        SetUnitStats(two);
        SetUnitStats(three);

    }

    private void SetUnitStats(GameObject unitToSet)
    {
        NavMeshAgent unitAgent = unitToSet.GetComponent<NavMeshAgent>();
        UnitScriptableObject UnitSO = unitToSet.GetComponent<Unit>().unit; ;
        unitAgent.speed = UnitSO.movementSpeed;
        unitAgent.angularSpeed = UnitSO.turnSpeed;
    }



}
