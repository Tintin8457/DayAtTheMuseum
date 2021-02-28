using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour
{
    public void MainMenu()
    {
        SceneManager.LoadScene("Introduction");
    }

    public void Intro()
    {
        SceneManager.LoadScene("HowToPlay");
    } 

    public void PlayLevel()
    {
        SceneManager.LoadScene("Level");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
