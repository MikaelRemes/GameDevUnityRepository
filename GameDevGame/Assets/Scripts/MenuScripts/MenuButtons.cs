using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
        
    public void QuitGame ()
    {
        Debug.Log("The game quits!");
        Application.Quit();
    }

    public void Retry()
    {
        Time.timeScale = 1;
        GetComponent<Player>();
        Player.HP = 10;
        Player.monies = 1000;
        Player.wave = 1;
        Player.score = 0;
        SceneManager.LoadScene(1);
    }


    public void MainMenu()
    {
        Time.timeScale = 1;
        GetComponent<Player>();
        Player.HP = 10;
        Player.monies = 1000;
        Player.wave = 1;
        Player.score = 0;
        SceneManager.LoadScene(0);
    }

    public void Credits()
    {
        SceneManager.LoadScene(2);
    }

}
