using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirectorScript : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Vector2 playerSpawnPosition;

    [Header("Enemy spawner")]
    [SerializeField] private SpawnerScript enemySpawner;

    [Header("Menu manager")]
    [SerializeField] private MenuManager menuManager;

    public static GameObject playerGameObject { get; set; }

    public static GameDirectorScript Instance { get; set; }

    public static Action RestartGame;

    private void Awake()
    {
        Instance = this;
        StartGame();
    }


    private void OnEnable()
    {
        Instance = this;
    }


    private void StartGame()
    {
        SpawnPlayer();
        StartSpawnEnemies();
    }


    public void RestartLevel()
    {
        RestartGame?.Invoke();
        CleanLevel();
        StartGame();
        MenuManager.CloseMenuAction?.Invoke();
    }


    private void SpawnPlayer()
    {
        playerGameObject = Instantiate(playerPrefab);
        ConfigurePlayer();
        playerGameObject.transform.position = playerSpawnPosition;
    }


    private void ConfigurePlayer()
    {
        PlayerScript playerScript = playerGameObject.GetComponentInChildren<PlayerScript>();
        playerScript.RestoreAllHealth();

        PlayerControls playerControls = playerGameObject.GetComponent<PlayerControls>();
        playerControls.ConfigureCancel(menuManager);
    }


    private void StartSpawnEnemies()
    {
        enemySpawner.StartSpawnEnemies();
    }


    private void CleanLevel()
    {
        Destroy(playerGameObject);
        GameObject[] activeEnemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in activeEnemies)
        {
            Destroy(enemy);
        }
    }
}
