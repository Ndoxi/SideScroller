using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class LoadSceneManager : MonoBehaviour
{
    public static int sceneToLoadIndex;
  

    public void StartGame()
    {
        sceneToLoadIndex = 2;
        SceneManager.LoadScene(1); //Show loading screen
    }


    public static void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }


    public void QuitGame()
    {
        Application.Quit();
    }
}
