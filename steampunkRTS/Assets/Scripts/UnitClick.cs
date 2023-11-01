using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine;

public class UnitClick : MonoBehaviour
{

    private Camera myCam;

    public LayerMask friendlyUnit;
    public LayerMask enemyUnit;
    public LayerMask Building;
    public LayerMask ground;

    public GameObject groundMarker;

    // Start is called before the first frame update
    void Start()
    {
        myCam = Camera.main;
    }

    private bool IsMouseOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !IsMouseOverUI())
        {

            RaycastHit hit;
            Ray ray = myCam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, friendlyUnit))
            {

                if (Input.GetKey(KeyCode.LeftShift))
                {

                    Selections.Instance.ShiftClickSelect(hit.collider.gameObject);

                }
                else
                {

                    Selections.Instance.ClickSelectUnit(hit.collider.gameObject);

                }

            }
            else if (Physics.Raycast(ray, out hit, Mathf.Infinity, Building))
            {
                //Building stuff

                Selections.Instance.ClickSelectBuilding(hit.transform);
                //ActionFrame.instance.SetActionButtons();

            }


            else
            {
                if (!Input.GetKey(KeyCode.LeftShift))
                {
                    Selections.Instance.DeselectAll();
                }

            }

        }

        if (Input.GetMouseButtonDown(1) && !IsMouseOverUI())
        {
            Debug.Log("shooting raycasy");
            RaycastHit hit;
            Ray ray = myCam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, ground))
            {
                if (Selections.Instance.selectedBuilding)
                {
                    //Be able to move the spawn point
                    Selections.Instance.selectedBuilding.GetChild(2).gameObject.SetActive(true);
                    Selections.Instance.selectedBuilding.GetChild(2).transform.position = hit.point;
                }
                else
                {
                    Selections.Instance.moveUnits(hit.point);
                    setGroundMarker(groundMarker, hit.point);
                    Debug.Log("Moving units!");
                }

            }
            else
            {

            }
            //attack I think



        }
    }

    public void setGroundMarker(GameObject groundMarkerObject, Vector3 groundMarkerPosition)
    {
        groundMarkerObject.transform.position = groundMarkerPosition;
        groundMarkerObject.SetActive(false);
        groundMarkerObject.SetActive(true);
    }
}