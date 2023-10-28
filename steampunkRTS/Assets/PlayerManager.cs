using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;


public class PlayerManager : MonoBehaviour
{
    public Text myText;

    public void ChangeText()
    {
        myText.text = "New Text Here";
    }

    /*public float goldAmount = 1000;
    public float woodAmount = 200;
    public float copperAmount = 300;

    public Text goldAmountText;
    //woodAmountText, copperAmountText;

    public void Awake()
    {
        //goldAmountText.text = "jello";
        //woodAmountText.text = woodAmount.ToString();
        //copperAmountText.text = copperAmount.ToString();
    }



    public void UpdateStats(UnitScriptableObject unit)
    {
        //Debug.Log(unit.name);
        float cost = unit.cost;
        goldAmount -= cost;
        Debug.Log(goldAmount);
        changeText();
        
    }

    public void changeText()
    {
        Debug.Log("TRYING TO CHANGE TEXT!!!");
        goldAmountText.text = "HIIIII";
    }*/

}
