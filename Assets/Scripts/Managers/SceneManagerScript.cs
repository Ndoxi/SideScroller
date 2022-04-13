using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SceneManagerScript : MonoBehaviour
{
    [Header("Explosion effects")]
    public GameObject explosionPrefab;

    [Header("All ammo for curent level")]
    public AllAmmoData allAmmoData;

    private void Awake()
    {
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
        Time.timeScale = 1;
    }
}
