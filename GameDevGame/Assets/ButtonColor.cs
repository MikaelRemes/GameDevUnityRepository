using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonColor : MonoBehaviour
{
    private bool pressedState = false;

    void Start()
    {
        GetComponent<Image>().color = Color.red;
    }
    public void ChangeColor()
    {
        if (pressedState)
        {
            GetComponent<Image>().color = Color.red;
            pressedState = false;
        }
        else
        {
            GetComponent<Image>().color = Color.green;
            pressedState = true;
        }
    }
}
