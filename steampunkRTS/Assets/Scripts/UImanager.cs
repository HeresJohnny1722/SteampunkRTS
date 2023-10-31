using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UImanager : MonoBehaviour
{
    [SerializeField]
    private TextMeshPro textMeshProUGUI;

    public void ChangeText()
    {
        textMeshProUGUI.text = "New Text Here";
    }
}
