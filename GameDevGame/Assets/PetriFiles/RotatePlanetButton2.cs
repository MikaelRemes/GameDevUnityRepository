using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotatePlanetButton2 : MonoBehaviour
{
    private bool pressed;

    void Awake()
    {
        GetComponent<Image>().color = Color.red;
        pressed = RotatePlanet2.rotateEnabled2;
        if (!pressed) GetComponent<Image>().color = Color.red;
        else GetComponent<Image>().color = Color.green;
    }

    public void PressedButton()
    {
        if (pressed)
        {
            GetComponent<Image>().color = Color.red;
            RotatePlanet2.rotateEnabled2 = false;
            pressed = false;
        }
        else
        {
            GetComponent<Image>().color = Color.green;
            RotatePlanet2.rotateEnabled2 = true;
            pressed = true;
        }
    }

    public void DisablePlanetRotation()
    {
        GetComponent<Image>().color = Color.red;
        RotatePlanet2.rotateEnabled2 = false;
        pressed = false;
    }
}
