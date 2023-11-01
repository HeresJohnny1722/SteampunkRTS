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

                } else
                {
                    if (!Input.GetKey(KeyCode.LeftShift))
                    {
                        Selections.Instance.DeselectAll();
                    }

                }

            }

        if (Input.GetMouseButtonDown(1) && !IsMouseOverUI())
        {
                RaycastHit hit;
                Ray ray = myCam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, enemyUnit))
            {
                //attack
                if (Selections.Instance.unitsSelected.Count > 0)
                {
                    //Selections.Instance.attackUnits(hit.point);
                    Debug.Log("Attacking Enemy");
                }

            } else if (Physics.Raycast(ray, out hit, Mathf.Infinity, ground))
            {
                if (Selections.Instance.unitsSelected.Count > 0)
                {
                    Selections.Instance.moveUnits(hit.point);
                }
            }

        }
    }
}
