using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Class for shooting ammo.
/// <br></br>
/// <description>
/// Shoot ammo on mouse input. 
/// </description>
/// </summary>
public class Shooting : MonoBehaviour
{

    public GameObject shootingSystemGO;
    private ShootingSystem _shootingSystem;


    private void Awake()
    {
        _shootingSystem = shootingSystemGO.GetComponent<ShootingSystem>();
    }


    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (_shootingSystem is null) return;

            _shootingSystem.ShootAmmo();
        }
    }
}

