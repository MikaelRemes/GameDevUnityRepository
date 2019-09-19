using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretPlacerButton : MonoBehaviour
{
    private bool pressed;

    void Awake()
    {
        GetComponent<Image>().color = Color.red;
        pressed = TurretPlacerV2.placingTurret;
        if (!pressed) GetComponent<Image>().color = Color.red;
        else GetComponent<Image>().color = Color.green;
    }

    public void PressedButton()
    {
        if (pressed)
        {
            GetComponent<Image>().color = Color.red;
            TurretPlacerV2.placingTurret = false;
            pressed = false;
        }
        else
        {
            GetComponent<Image>().color = Color.green;
            TurretPlacerV2.placingTurret = true;
            pressed = true;
        }
    }

    public void DisableTurretPlacement()
    {
        GetComponent<Image>().color = Color.red;
        TurretPlacerV2.placingTurret = false;
        pressed = false;
    }
}
