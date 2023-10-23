using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitClick : MonoBehaviour
{

    private Camera myCam;

    public LayerMask clickable;
    public LayerMask ground;

    public GameObject groundMarker;

    // Start is called before the first frame update
    void Start()
    {
        myCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            RaycastHit hit;
            Ray ray = myCam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, clickable))
            {

                if (Input.GetKey(KeyCode.LeftShift))
                {

                    UnitSelections.Instance.ShiftClickSelect(hit.collider.gameObject);

                } else
                {

                    UnitSelections.Instance.ClickSelect(hit.collider.gameObject);

                }

            } else
            {
                if (!Input.GetKey(KeyCode.LeftShift))
                {
                    UnitSelections.Instance.DeselectAll();
                }
                
            }

        }

        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray = myCam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, ground))
            {
                groundMarker.transform.position = hit.point;
                groundMarker.SetActive(false);

                groundMarker.SetActive(true);

                UnitSelections.Instance.moveUnits(hit.point);
            } else
            {
                //attak I think
            }

            
            
        }
    }
}
