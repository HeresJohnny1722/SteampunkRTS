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

    private BarracksHandler barraksHandler;
    public GameObject barracksHandlerGameobject;

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
        barraksHandler = barracksHandlerGameobject.GetComponent<BarracksHandler>();

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


        barraksHandler.BarracksMenuClose();

    }

    public void ClickSelectBuilding(Transform buildingToSelect)
    {
        barraksHandler.BarracksMenuClose();
        DeselectAll();
        Debug.Log(buildingToSelect.name);
        selectedBuilding = buildingToSelect;
        selectedBuilding.GetChild(3).gameObject.SetActive(false);
        selectedBuilding.GetChild(4).gameObject.SetActive(true);
        selectedBuilding.GetChild(2).gameObject.SetActive(true);

        //selectedBuilding.GetChild(0).gameObject.SetActive(true);
        //change material to white outline


        //selectedBuilding.GetChild(2).gameObject.SetActive(true);
        //Open up a training/reserch menu/ just some kind of UI
        //ActionFrame.instance.SetActionButtons();
        barraksHandler.BarracksMenuOpen();


        //unitToAdd.transform.GetChild(0).gameObject.SetActive(true);


    }

    public void ShiftClickSelect(GameObject unitToAdd)
    {
        if (!unitsSelected.Contains(unitToAdd) && (unitsSelected.Count < 9))
        {
            barraksHandler.BarracksMenuClose();
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
            barraksHandler.BarracksMenuClose();
            unitsSelected.Add(unitToAdd);
            unitToAdd.transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    public void DeselectAll()
    {
        barraksHandler.BarracksMenuClose();


        foreach (var unit in unitsSelected)
        {
            unit.transform.GetChild(0).gameObject.SetActive(false);
        }
        unitsSelected.Clear();

        if (selectedBuilding)
        {
            selectedBuilding.GetChild(3).gameObject.SetActive(true);
            selectedBuilding.GetChild(4).gameObject.SetActive(false);
            selectedBuilding.GetChild(2).gameObject.SetActive(false);
            selectedBuilding = null;
        }

    }

    public void moveUnits(Vector3 moveToPosition)
    {
        Debug.Log("move units");


        if (unitsSelected.Count > 0)
        {
            setGroundMarker(groundMarker, moveToPosition);

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
}
