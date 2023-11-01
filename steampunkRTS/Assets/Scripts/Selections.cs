using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.AI;

public class Selections : MonoBehaviour
{


    //public RadialFormation radialFormation;

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

    public int spacing = 1;
    public GameObject groundMarker;

    private GameObject leader;

    private FormationBase _formation;

    public FormationBase Formation
    {
        get
        {
            if (_formation == null) _formation = GetComponent<FormationBase>();
            return _formation;
        }
        set => _formation = value;
    }

    private List<Vector3> _points = new List<Vector3>();

    public void moveUnits(Vector3 moveToPosition)
    {
        Debug.Log("move units");

        if (unitsSelected.Count > 0)
        {
            setGroundMarker(groundMarker, moveToPosition);
            _points = Formation.EvaluatePoints().ToList();

            for (var i = 0; i < unitsSelected.Count; i++)
            {
                myAgent = unitsSelected[i].GetComponent<NavMeshAgent>();
                myAgent.SetDestination(_points[i] + moveToPosition);
                //unitsSelected[i].transform.position = Vector3.MoveTowards(unitsSelected[i].transform.position, transform.position + _points[i], _unitSpeed * Time.deltaTime);
            }
            /*

            radialFormation = GetComponent<RadialFormation>();

            // Calculate the number of units in the formation
            int formationSize = Mathf.CeilToInt(Mathf.Sqrt(unitsSelected.Count));

            if (radialFormation != null)
            {


                // Calculate the formation
                List<Vector3> formation = new List<Vector3>(radialFormation.EvaluatePoints());

                if (formation.Count >= unitsSelected.Count)
                {
                    for (int i = 0; i < unitsSelected.Count; i++)
                    {
                        myAgent = unitsSelected[i].GetComponent<NavMeshAgent>();
                        myAgent.SetDestination(moveToPosition + formation[i]);
                    }
                }
                else
                {
                    Debug.LogWarning("Not enough positions in the radial formation for all selected units.");
                }
            }
            else
            {
                Debug.LogError("The 'radialFormation' variable is not set. Make sure to assign a RadialFormation component in the Inspector.");
            }
            */
        }
    }

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
        if (!unitsSelected.Contains(unitToAdd) && (unitsSelected.Count < 20))
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

    



    public void setGroundMarker(GameObject groundMarkerObject, Vector3 groundMarkerPosition)
    {
        groundMarkerObject.transform.position = groundMarkerPosition;
        groundMarkerObject.SetActive(false);
        groundMarkerObject.SetActive(true);
    }
}
