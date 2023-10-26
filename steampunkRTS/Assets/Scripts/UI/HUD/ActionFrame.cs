using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionFrame : MonoBehaviour
{
    public GameObject BarracksTrainingMenu;

    [SerializeField]
    private List<UnitScriptableObject> unitsToTrain = new List<UnitScriptableObject>();

    [SerializeField] private List<Button> buttonPrefabs = new List<Button>();
    [SerializeField] private Transform layoutGroup = null;
    private List<Button> buttonsInstantiated = new List<Button>();

    

    public void SetActionButtons()
    {
        Debug.Log("BUILDING TRAINING MENU");
        BarracksTrainingMenu.gameObject.SetActive(true);

        /*
        int unitIndex = 0;

        foreach (UnitScriptableObject unit in unitsToTrain)
        {
            Button btn = Instantiate(buttonPrefabs[unitIndex], layoutGroup);
            btn.name = unit.name;
            Debug.Log(btn.name);
            unitIndex++;
        }
        */

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
        foreach (Button btn in buttonsInstantiated)
        {
            buttonsInstantiated.Remove(btn);
            Destroy(btn);
        }
    }
}
