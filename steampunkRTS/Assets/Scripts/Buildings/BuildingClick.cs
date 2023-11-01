using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine;

public class BuildingClick : MonoBehaviour
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

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, Building))
            {
                //Building stuff

                BuildingSelections.Instance.ClickSelectBuilding(hit.transform);
                //ActionFrame.instance.SetActionButtons();

            } else {
                BuildingSelections.Instance.DeselectBuilding();
            }

            

        }

        if (Input.GetMouseButtonDown(1) && !IsMouseOverUI())
        {
            RaycastHit hit;
            Ray ray = myCam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, ground))
            {
                if (BuildingSelections.Instance.selectedBuilding != null)
                {
                    //Be able to move the spawn point
                    BuildingSelections.Instance.selectedBuilding.GetChild(2).gameObject.SetActive(true);
                    BuildingSelections.Instance.selectedBuilding.GetChild(2).transform.position = hit.point;
                }
               

            }





        }
    }
}
