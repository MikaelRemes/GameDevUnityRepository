using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    //Stored global variables
    public static int HP=10;
    public static int monies=1000;
    public static int wave=1;

    public GameObject YouLoseText;

    public Text hpText;
    public Text waveText;
    public Text moniesText;

    private void Start()
    {
        //Hides losing text from the view
        YouLoseText.gameObject.SetActive(false);
    }


    void Update()
    {

        //TODO: check current HP, if 0 end game
        if (HP < 1)
        {
            // "Pops" the lose text with buttons
            YouLoseText.SetActive(true);
            //Stops time
            Time.timeScale = 0;
            // Gets script for buttons
            GetComponent<MenuButtons>();

        }
        else
        {
            YouLoseText.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
        UpdateTextBoxes();
    }

    void UpdateTextBoxes()
    {
        hpText.text = "Planet HP: " + HP;
        waveText.text = "Wave: " + (wave-1);
        moniesText.text = "Money: " + monies;
    }
}
