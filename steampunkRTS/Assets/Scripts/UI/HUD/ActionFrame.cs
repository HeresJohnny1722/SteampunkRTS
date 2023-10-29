using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.AI;

public class ActionFrame : MonoBehaviour
{
    public TextMeshProUGUI timeLeftText;
    public TextMeshProUGUI queueSizeText;
    public TextMeshProUGUI unitNameText;

    public GameObject BarracksTrainingMenu;
    public Transform spawnTransform;
    public PlayerManager playerManager;
    public Selections selections;


    
    private Transform unitSpawnPoint;
    private Transform unitMovePoint;


    [SerializeField]
    private Button warriorButton, healerButton, workerButton;

    [SerializeField]
    private List<UnitScriptableObject> unitsToTrain = new List<UnitScriptableObject>();

    [SerializeField] private List<Button> buttonPrefabs = new List<Button>();
    [SerializeField] private Transform layoutGroup = null;
    private List<Button> buttonsInstantiated = new List<Button>();

    private void Start()
    {

        timeLeftText.text = "Training Time: 0s";
        queueSizeText.text = "Queue Size: 0";

        warriorButton.gameObject.SetActive(true);
        


    }

    private Queue<UnitScriptableObject> troopQueue = new Queue<UnitScriptableObject>();
    private bool isTraining = false;

    public void spawnTroop(UnitScriptableObject unit)
    {
        //unitSpawnPoint = selections.selectedBuilding.transform;
        unitSpawnPoint = selections.selectedBuilding.GetChild(1).transform;
        unitMovePoint = selections.selectedBuilding.GetChild(2).transform;

        

        if ((playerManager.goldAmount - unit.cost >= 0) && (playerManager.woodAmount - unit.wood >= 0) && (playerManager.copperAmount - unit.copper >= 0))
        {
            troopQueue.Enqueue(unit);
            UpdateQueueSizeText();
            playerManager.ChangeText(unit);// Update the queue size text when a new troop is enqueued

            UpdateQueueSizeText();
            if (!isTraining)
            {
                UpdateQueueSizeText();
                StartCoroutine(TrainTroops());
            }
        }
    }

    private IEnumerator TrainTroops()
    {
        UpdateQueueSizeText();
        isTraining = true;

        while (troopQueue.Count > 0)
        {
            UpdateQueueSizeText();
            UnitScriptableObject unit = troopQueue.Dequeue();

            
                //and other materials too

                unitNameText.text = unit.name;
                Debug.Log("Training " + unit.name);
                

                float trainingTime = unit.trainingTime;
                while (trainingTime > 0)
                {
                    // Update time left text
                    timeLeftText.text = "Training Time: " + trainingTime.ToString("0") + "s";
                    yield return new WaitForSeconds(1);
                    trainingTime -= 1;
                UpdateQueueSizeText();
            }

            
            
                //Vector3 targetPosition = new Vector3(0, 2, 0);
                GameObject troop = Instantiate(unit.unitPrefab, unitSpawnPoint.position, Quaternion.identity);
            NavMeshAgent unitAgent = troop.GetComponent<NavMeshAgent>();
            //unitAgent.SetDestination(unitAnimationPoint.position);
            //StartCoroutine(WaitForOneSecond());
            
            unitAgent.SetDestination(unitMovePoint.position);
                

                // Reset time left text and unit name
                timeLeftText.text = "Training Time: 0s";
                unitNameText.text = "No unit training";

                UpdateQueueSizeText(); // Update the queue size text when a troop is done training
            }
        

        isTraining = false;
        UpdateQueueSizeText(); // Update the queue size text when all troops are done training
    }

    private void UpdateQueueSizeText()
    {
        queueSizeText.text = "Queue Size: " + troopQueue.Count;
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

    
