using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Selections : MonoBehaviour
{
    public float angleOffset = 45f;

    public List<GameObject> unitList = new List<GameObject>();
    public List<GameObject> unitsSelected = new List<GameObject>();

    private static Selections _instance;
    public static Selections Instance { get { return _instance; } }

    public List<GameObject> buildingsList = new List<GameObject>();
    public Transform selectedBuilding = null;

    private ActionFrame actionFrame;
    public GameObject ActionFrameGameobject;

    private NavMeshAgent myAgent;
    private Camera myCam;

    public LayerMask friendlyUnit;
    public LayerMask enemyUnit;
    public LayerMask Building;
    public LayerMask ground;

    public float spacing = 1f;
    public GameObject groundMarker;

    private GameObject leader;


    void Awake()
    {
        actionFrame = ActionFrameGameobject.GetComponent<ActionFrame>();

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

 

    public void ClickSelectUnit(GameObject unitToAdd)
    {
        DeselectAll();
        unitsSelected.Add(unitToAdd);
        unitToAdd.transform.GetChild(0).gameObject.SetActive(true);

        actionFrame.BarracksMenuClose();

    }

    public void ClickSelectBuilding(Transform buildingToSelect)
    {
        actionFrame.BarracksMenuClose();
        DeselectAll();
        Debug.Log(buildingToSelect.name);
        selectedBuilding = buildingToSelect;
        selectedBuilding.GetChild(0).gameObject.SetActive(true);
        //Open up a training/reserch menu/ just some kind of UI
        //ActionFrame.instance.SetActionButtons();
        actionFrame.BarracksMenuOpen();
        

        //unitToAdd.transform.GetChild(0).gameObject.SetActive(true);


    }

    public void ShiftClickSelect(GameObject unitToAdd)
    {
        if (!unitsSelected.Contains(unitToAdd) && (unitsSelected.Count < 9))
        {
            actionFrame.BarracksMenuClose();
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
        if (!unitsSelected.Contains(unitToAdd) && (unitsSelected.Count < 9))
        {
            actionFrame.BarracksMenuClose();
            unitsSelected.Add(unitToAdd);
            unitToAdd.transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    public void DeselectAll()
    {
        actionFrame.BarracksMenuClose();


        foreach (var unit in unitsSelected)
        {
            unit.transform.GetChild(0).gameObject.SetActive(false);
        }
        unitsSelected.Clear();

        if (selectedBuilding)
        {
            selectedBuilding.GetChild(0).gameObject.SetActive(false);
            selectedBuilding = null;
        }
        
    }


        

        public void Deselect(GameObject unitToDeselect)
        {

        }

    public float offsetDistance = 2f;

    public void moveUnits(Vector3 moveToPosition)
    {
        Debug.Log("move units");


        if (unitsSelected.Count > 0)
        {
            groundMarker.transform.position = moveToPosition;
            groundMarker.SetActive(false);
            groundMarker.SetActive(true);

            //float spacing = 2f;

            int formationSize = (int)Mathf.CeilToInt(Mathf.Sqrt(unitsSelected.Count));

            List<Vector3> targetPositionList = new List<Vector3>();
            int targetPositionListIndex = 1;

            leader = unitsSelected[0].gameObject;
            //Debug.Log(leader);
            leader.GetComponent<NavMeshAgent>().SetDestination(moveToPosition);

            // Calculate leader's forward vector
            Vector3 leaderForward = leader.transform.forward;


            for (int x = -1; x <= 1; x++)
            {
                for (int z = -1; z <= 1; z++)
                {
                    Vector3 targetPosition = new Vector3(moveToPosition.x + x, 0, moveToPosition.z + z);
                    targetPositionList.Add(targetPosition);
                }
            }

            foreach (var unit in unitsSelected)
            {
                myAgent = unit.GetComponent<NavMeshAgent>();
                myAgent.SetDestination(targetPositionList[targetPositionListIndex]);
                targetPositionListIndex = (targetPositionListIndex + 1) % targetPositionList.Count;
            }
        }
    }



        public void setGroundMarker(GameObject groundMarkerObject, Vector3 groundMarkerPosition)
    {
        groundMarkerObject.transform.position = groundMarkerPosition;
        groundMarkerObject.SetActive(false);
        groundMarkerObject.SetActive(true);
    }

















    /*for (int x = 0; x < formationSize; x++)
    {
        for (int z = 0; z < formationSize; z++)
        {
            // Calculate formationOffset based on current unit's position within the formation
            Vector3 formationOffset = new Vector3(x * spacing, 0, z * spacing);
            formationOffset = Quaternion.Euler(0, leader.transform.eulerAngles.y, 0) * formationOffset;
            Vector3 targetPosition = moveToPosition + formationOffset;
            targetPositionList.Add(targetPosition);
        }
    }*/
    /*
        int targetPositionListIndex = 0;

        foreach (var unit in unitsSelected)
        {

        }
    */
}

/*else if (Physics.Raycast(ray, out hit, Mathf.Infinity, Building))
        {
            if ()
        }*/







