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
}
