using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SceneManagerScript : MonoBehaviour
{
    [Header("Explosion effects")]
    [SerializeField] private GameObject explosionPrefab;

    [Space]
    [Header("All ammo for curent level")]
    [SerializeField] private AllAmmoData allAmmoData;

    [Space]
    [Header("Time scale")]
    [SerializeField] private static float normalTimeScale = 1;

    public static SceneManagerScript Instance { set; get; }


    private void Awake()
    {
        Instance = this;

        PlayerScript.PlayerDies += GameObjectDies;
    }


    private void OnDestroy()
    {
        PlayerScript.PlayerDies -= GameObjectDies;
    }


    /// <summary>
    /// Game object death visual effects
    /// </summary>
    private void GameObjectDies(Vector2 deathPos)
    {
        GameObject explosionGO = Instantiate(explosionPrefab);
        explosionGO.transform.position = deathPos;
        Destroy(explosionGO, 3f);
    }

    
    public void PauseGame()
    {
        Time.timeScale = 0;
    }


    public void ResumeGame()
    {
        Time.timeScale = normalTimeScale;
    }


    public static void SetTimeScale(float timeScale)
    {
        normalTimeScale = timeScale;
        Time.timeScale = timeScale;
    }
}
