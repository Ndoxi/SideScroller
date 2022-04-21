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

    public static GameObject playerGameObject { get; set; }

    public static GameDirectorScript Instance { get; set; }
    

    private void Awake()
    {
        Instance = this;     
    }


    private void Start()
    {
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


    private void RestartLevel()
    {
        CleanLevel();
        LoadCheckPoint();
        StartGame();
    }


    private void SpawnPlayer()
    {
        playerGameObject = Instantiate(playerPrefab);
        playerGameObject.transform.position = playerSpawnPosition;
    }


    private void StartSpawnEnemies()
    {
        enemySpawner.StartSpawnEnemies();
    }


    private void CleanLevel()
    {
    }


    private void LoadCheckPoint()
    {
    }
}
