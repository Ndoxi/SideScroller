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
        Debug.Log("Start game");

        sceneToLoadIndex = 2;
        SceneManager.LoadScene(1); //Show loading screen
    }


    public void LoadMainMenu()
    {
        Debug.Log("Load Main Menu");
        SceneManager.LoadScene(0);
    }


    public void QuitGame()
    {
        Debug.Log("Qiut game");
        Application.Quit();
    }
}
