using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TestUI : MonoBehaviour
{
    public TextMeshProUGUI text;

    public void testUi()
    {
        text.text = "Changed text";
        Debug.Log("hello");
    }
    
}
