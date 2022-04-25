using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LoadingScreen : MonoBehaviour
{
    [SerializeField] private Slider progressBar;

    private AsyncOperation loadingOperation;


    private void Awake()
    {
        loadingOperation = SceneManager.LoadSceneAsync(LoadSceneManager.sceneToLoadIndex);
    }


    private void Update()
    {
        progressBar.value = Mathf.Clamp01(loadingOperation.progress / 0.9f);
    }
}
