using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class GameRTSController : MonoBehaviour
{

    private Vector3 startPosition;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //left mouse button pressed
            startPosition = UtilsClass.GetMouseWorldPosition();
        }

        if (Input.GetMouseButtonUp(0))
        {
            //left mouse button up
            Debug.Log(UtilsClass.GetMouseWorldPosition() + " " + startPosition);
            Collider2D[] colldierArray = Physics2D.OverlapAreaAll(startPosition, UtilsClass.GetMouseWorldPosition());
            Debug.Log("#########");
            foreach (Collider2D collider in colldierArray)
            {
                Debug.Log(collider);
            }
        }
    }
}
