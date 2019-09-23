using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HELP : MonoBehaviour
{
    public void displayHelpText()
    {
        Debug.Log("HELP pressed...");
        Debug.Log("Use WASD to rotate planet");
        Debug.Log("Use Q and E to change view distance");
        Debug.Log("Developer mode: ");
        Debug.Log("Use G to spawn enemy wave");
    }
}
