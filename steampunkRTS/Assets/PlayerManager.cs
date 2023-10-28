using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerManager : MonoBehaviour
{
    public float goldAmount = 1000;
    public float woodAmount = 200;
    public float copperAmount = 300;

    public Text goldAmountText, woodAmountText, copperAmountText;

    public void Start()
    {
        goldAmountText.text = goldAmount.ToString();
        woodAmountText.text = woodAmount.ToString();
        copperAmountText.text = copperAmount.ToString();
    }


    public void UpdateStats(UnitScriptableObject unit)
    {
        Debug.Log(unit.name);
        float cost = unit.cost;
        goldAmount -= cost;

        if (goldAmountText != null)
        {
            goldAmountText.text = goldAmount.ToString();
        }
        else
        {
            Debug.LogError("goldAmountText is not assigned.");
        }
    }

}
