using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ActionFrame : MonoBehaviour
{
    public GameObject BarracksTrainingMenu;
    public Transform spawnTransform;
    public PlayerManager playerManager;

    [SerializeField]
    private Button warriorButton, healerButton, workerButton;

    [SerializeField]
    private List<UnitScriptableObject> unitsToTrain = new List<UnitScriptableObject>();

    [SerializeField] private List<Button> buttonPrefabs = new List<Button>();
    [SerializeField] private Transform layoutGroup = null;
    private List<Button> buttonsInstantiated = new List<Button>();

    private void Start()
    {

        warriorButton.gameObject.SetActive(true);
        //int unitIndex = 0;

        /*foreach (UnitScriptableObject unit in unitsToTrain)
        {
            Button btn = Instantiate(buttonPrefabs[unitIndex], layoutGroup);
            buttonsInstantiated.Add(btn);
            btn.name = unit.name;
            Debug.Log(btn.name);
            unitIndex++;
        }*/

        /*foreach (Button btn in buttonsInstantiated)
        {
            buttonsInstantiated.Remove(btn);
            Destroy(btn);
        }*/


    }

    public void spawnTroop(UnitScriptableObject unit)
    {
        if (playerManager.goldAmount - unit.cost >= 0)
        {
            Vector3 targetPosition = new Vector3(0, 2, 0);
            GameObject troop = Instantiate(unit.unitPrefab, targetPosition, Quaternion.identity);
            Debug.Log(targetPosition);
            playerManager.ChangeText(unit);
        }
        /*else
        {
            Debug.Log("not enough gold");
            /*if (unit.name == "Warrior")
            {
                warriorButton.image.color = Color.black;
            } else if(unit.name == "Healer")
            {
                healerButton.image.color = Color.black;
            } else if (unit.name == "Worker")
            {
                workerButton.image.color = Color.black;
            }*/

            //Set the button to dark
            //Also need somewhere when collecting resources, to check if the button should update to show that you
            //can now make the troop
        //}

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
}

    
