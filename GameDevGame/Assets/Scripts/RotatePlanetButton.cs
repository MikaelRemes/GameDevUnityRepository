using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotatePlanetButton : MonoBehaviour
{
    private bool pressed;

    void Awake()
    {
        GetComponent<Image>().color = Color.red;
        pressed = RotatePlanet.rotateEnabled;
        if (!pressed) GetComponent<Image>().color = Color.red;
        else GetComponent<Image>().color = Color.green;
    }

    public void PressedButton()
    {
        if (pressed)
        {
            GetComponent<Image>().color = Color.red;
            RotatePlanet.rotateEnabled = false;
            pressed = false;
        }
        else
        {
            GetComponent<Image>().color = Color.green;
            RotatePlanet.rotateEnabled = true;
            pressed = true;
        }
    }

    public void DisablePlanetRotation()
    {
        GetComponent<Image>().color = Color.red;
        RotatePlanet.rotateEnabled = false;
        pressed = false;
    }
}
