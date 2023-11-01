using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSelections : MonoBehaviour
{
    public List<GameObject> buildingsList = new List<GameObject>();
    public Transform selectedBuilding = null;

    private static BuildingSelections _instance;
    public static BuildingSelections Instance { get { return _instance; } }


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
}
