using UnityEngine;

public class UnitSpawner : MonoBehaviour
{
    public UnitSO unitData; // Reference to the ScriptableObject

    private void Start()
    {
        if (unitData != null)
        {
            GameObject newUnit = Instantiate(unitData.unitPrefab, transform.position, Quaternion.identity);
            GameObject two = Instantiate(unitData.unitPrefab, transform.position, Quaternion.identity);
            GameObject three = Instantiate(unitData.unitPrefab, transform.position, Quaternion.identity);
            GameObject four = Instantiate(unitData.unitPrefab, transform.position, Quaternion.identity);
            // You might want to do more with the newUnit here, like setting its stats or behavior.
        }
        else
        {
            Debug.LogError("Unit Data ScriptableObject is not assigned.");
        }
    }
}
