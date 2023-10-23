using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitSelections : MonoBehaviour
{
    public List<GameObject> unitList = new List<GameObject>();
    public List<GameObject> unitsSelected = new List<GameObject>();

    private static UnitSelections _instance;
    public static UnitSelections Instance { get { return _instance; } }

    private NavMeshAgent myAgent;
    private Camera myCam;

    public LayerMask clickable;
    public LayerMask ground;

    public float spacing = 1f;
    public GameObject groundMarker;


    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

        myCam = Camera.main;
    }

    public void ClickSelect(GameObject unitToAdd)
    {
        DeselectAll();
        unitsSelected.Add(unitToAdd);
        unitToAdd.transform.GetChild(0).gameObject.SetActive(true);
    }

    public void ShiftClickSelect(GameObject unitToAdd)
    {
        if (!unitsSelected.Contains(unitToAdd))
        {
            unitsSelected.Add(unitToAdd);
            unitToAdd.transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            unitToAdd.transform.GetChild(0).gameObject.SetActive(false);
            unitsSelected.Remove(unitToAdd);

        }
    }

    public void DragSelect(GameObject unitToAdd)
    {
        if (!unitsSelected.Contains(unitToAdd))
        {
            unitsSelected.Add(unitToAdd);
            unitToAdd.transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    public void DeselectAll()
    {
        foreach (var unit in unitsSelected)
        {
            unit.transform.GetChild(0).gameObject.SetActive(false);
        }
        unitsSelected.Clear();

    }

    public void Deselect(GameObject unitToDeselect)
    {

    }

    public void moveUnits(Vector3 moveToPosition)
    {
        Debug.Log("move units");

        if (unitsSelected.Count > 0)
        {
            
            groundMarker.transform.position = moveToPosition;
            groundMarker.SetActive(false);

            groundMarker.SetActive(true);

        }

        int formationSize = (int)Mathf.CeilToInt(Mathf.Sqrt(unitsSelected.Count));
        

        List<Vector3> targetPositionList = new List<Vector3>();

        for (int x = 0; x < formationSize; x++)
        {
            for (int z = 0; z < formationSize; z++)
            {
                Vector3 formationOffset = new Vector3(x * spacing, 0, z * spacing);
                Vector3 targetPosition = moveToPosition + formationOffset;
                targetPositionList.Add(targetPosition);
            }
        }

        int targetPositionListIndex = 0;

        foreach (var unit in unitsSelected)
        {
            myAgent = unit.GetComponent<NavMeshAgent>();
            myAgent.SetDestination(targetPositionList[targetPositionListIndex]);
            targetPositionListIndex = (targetPositionListIndex + 1) % targetPositionList.Count;
            
        }
    }



}
