using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionFrame : MonoBehaviour
{
    public GameObject BarracksTrainingMenu;
    public Transform spawnTransform;
    public PlayerManager playerManager;

    [SerializeField]
    private List<UnitScriptableObject> unitsToTrain = new List<UnitScriptableObject>();

    [SerializeField] private List<Button> buttonPrefabs = new List<Button>();
    [SerializeField] private Transform layoutGroup = null;
    private List<Button> buttonsInstantiated = new List<Button>();

    private void Start()
    {
        
        int unitIndex = 0;

        foreach (UnitScriptableObject unit in unitsToTrain)
        {
            Button btn = Instantiate(buttonPrefabs[unitIndex], layoutGroup);
            buttonsInstantiated.Add(btn);
            btn.name = unit.name;
            Debug.Log(btn.name);
            unitIndex++;
        }

        /*foreach (Button btn in buttonsInstantiated)
        {
            buttonsInstantiated.Remove(btn);
            Destroy(btn);
        }*/


    }

    public void spawnTroop(UnitScriptableObject unit)
    {

        Vector3 targetPosition = new Vector3(0, 2, 0);
        GameObject troop = Instantiate(unit.unitPrefab, targetPosition, Quaternion.identity);
        Debug.Log(targetPosition);
        //playerManager.UpdateStats(unit);

    }

    

    public void BarracksMenuClose()
    {
        BarracksTrainingMenu.gameObject.SetActive(false);

    } 

    public void BarracksMenuOpen()
    {
        Debug.Log("BUILDING TRAINING MENU");
        BarracksTrainingMenu.gameObject.SetActive(true);

        
        
        

        /*if (actions.basicUnits.Length > 0)
        {
            foreach(UnitScriptableObject.unitType unit in actions.basicUnits)
            {
                Button btn = Instantiate(actionButton, layoutGroup);
                //btn.name = unit.;
                buttons.Add(btn);
            }
        }

        if (actions.basicBuildings.Length > 0)
        {
            foreach (BasicBuildingSO.buildingType building in actions.basicBuildings)
            {
                Button btn = Instantiate(actionButton, layoutGroup);
                //btn.name = building.nam
                buttons.Add(btn);
            }
        }*/

        
    }

    public void ClearActions()
    {
        
    }
}
