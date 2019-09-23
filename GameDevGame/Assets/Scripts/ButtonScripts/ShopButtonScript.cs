using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopButtonScript : MonoBehaviour
{
    public string shopButtonTag = "ShopButton";

    public void showHideShop()
    {
        GameObject[] buttons =  GameObject.FindGameObjectsWithTag("ShopButton");
        foreach(GameObject button in buttons)
        {
            button.GetComponent<Button>().enabled = !button.GetComponent<Button>().enabled;
            button.GetComponent<Image>().enabled = !button.GetComponent<Image>().enabled;
            button.GetComponentInChildren<Text>().enabled = !button.GetComponentInChildren<Text>().enabled;
            //else Show(button);
        }
    }
}
