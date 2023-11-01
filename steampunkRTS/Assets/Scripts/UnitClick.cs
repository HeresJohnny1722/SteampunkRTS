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

<<<<<<< HEAD:steampunkRTS/Assets/Scripts/Units/UnitClick.cs
<<<<<<< HEAD:steampunkRTS/Assets/Scripts/Units/UnitClick.cs
                } else
=======
=======
>>>>>>> parent of 6ef52dd (Merge branch 'main' of https://github.com/HeresJohnny1722/SteampunkRTS):steampunkRTS/Assets/Scripts/UnitClick.cs
                } else if (Physics.Raycast(ray, out hit, Mathf.Infinity, Building))
                {
                //Building stuff
                
                Selections.Instance.ClickSelectBuilding(hit.transform);
                //ActionFrame.instance.SetActionButtons();

<<<<<<< HEAD:steampunkRTS/Assets/Scripts/Units/UnitClick.cs
            }


                else
>>>>>>> parent of 111c25c (Beginning Refactoring):steampunkRTS/Assets/Scripts/UnitClick.cs
=======
            } 


                else
>>>>>>> parent of 6ef52dd (Merge branch 'main' of https://github.com/HeresJohnny1722/SteampunkRTS):steampunkRTS/Assets/Scripts/UnitClick.cs
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

<<<<<<< HEAD:steampunkRTS/Assets/Scripts/Units/UnitClick.cs
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, enemyUnit))
            {
                //attack
                if (Selections.Instance.selectedBuilding == null)
                {
                    Selections.Instance.attackUnits(hit.point);
                    Debug.Log("Attacking Enemy");
                }
            } else if (Physics.Raycast(ray, out hit, Mathf.Infinity, ground))
=======
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, ground))
>>>>>>> parent of 111c25c (Beginning Refactoring):steampunkRTS/Assets/Scripts/UnitClick.cs
            {
                    if (Selections.Instance.selectedBuilding != null)
                {
                    //Be able to move the spawn point
                    Selections.Instance.selectedBuilding.GetChild(2).gameObject.SetActive(true);
                    Selections.Instance.selectedBuilding.GetChild(2).transform.position = hit.point;
                } else
                {
                    Selections.Instance.moveUnits(hit.point);
                }
<<<<<<< HEAD:steampunkRTS/Assets/Scripts/Units/UnitClick.cs
<<<<<<< HEAD:steampunkRTS/Assets/Scripts/Units/UnitClick.cs
            }
=======
                    
             }
                else 
                {
                    
                }
                //attack I think
=======
                    
             }
            
           


>>>>>>> parent of 6ef52dd (Merge branch 'main' of https://github.com/HeresJohnny1722/SteampunkRTS):steampunkRTS/Assets/Scripts/UnitClick.cs


>>>>>>> parent of 111c25c (Beginning Refactoring):steampunkRTS/Assets/Scripts/UnitClick.cs

            }
        }
    }
