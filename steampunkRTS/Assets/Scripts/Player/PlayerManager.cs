using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI goldAmountText, copperAmountText, woodAmountText;

    [SerializeField]
    private UnitScriptableObject warrior, healer, worker;

    [SerializeField]
    private Button warriorButton, healerButton, workerButton;


    public float goldAmount = 1000;
    public float woodAmount = 200;
    public float copperAmount = 300;



    public void Awake()
    {
        goldAmount = goldAmount;
        woodAmount = woodAmount;
        copperAmount = copperAmount;
        goldAmountText.text = "Gold: " + goldAmount.ToString(); //Based on selected difficulty
        woodAmountText.text = "Wood: " + woodAmount.ToString();
        copperAmountText.text = "Copper: " + copperAmount.ToString();
    }

    public void ChangeText(UnitScriptableObject unit)
    {
        Debug.Log("Trying to change text");
        float cost = unit.cost;
        goldAmount -= cost;
        goldAmountText.text = "Gold: " + goldAmount.ToString();
        float copper = unit.copper;
        copperAmount -= copper;
        copperAmountText.text = "Copper: " + copperAmount.ToString();
        float wood = unit.wood;
        woodAmount -= wood;
        woodAmountText.text = "Wood: " + woodAmount.ToString();

        if (goldAmount < warrior.cost || copperAmount < warrior.copper || woodAmount < warrior.wood)
        {
            warriorButton.image.color = Color.black;
            warriorButton.interactable = false;

        }
        if (goldAmount < worker.cost || copperAmount < worker.copper || woodAmount < worker.wood)
        {
            workerButton.image.color = Color.black;
            workerButton.interactable = false;

        }
        if (goldAmount < healer.cost || copperAmount < healer.copper || woodAmount < healer.wood)
        {
            healerButton.image.color = Color.black;
            healerButton.interactable = false;

        }
    }


}
