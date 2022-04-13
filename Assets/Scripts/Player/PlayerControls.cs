using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerControls : MonoBehaviour
{
    [Header("Rocket stats")]
    public RocketStats rocketStats;

    [Space]
    [Header("Shooting system")]
    public GameObject shootingSystemGO;

    private ShootingSystem _shootingSystem;
    private Vector2 _playerDirection;
    private bool _shootAmmo;


    private void Awake()
    {
        _shootingSystem = shootingSystemGO.GetComponent<ShootingSystem>();
    }


    private void Update()
    {
        PerformActions();
    }


    private void PerformActions()
    {
        transform.Translate(_playerDirection * rocketStats.speed * Time.deltaTime);

        if (_shootAmmo)
        {
            _shootingSystem.ShootAmmo();
        }
    }


    public void OnMovement(InputAction.CallbackContext context)
    {
        _playerDirection = context.ReadValue<Vector2>();
    }


    public void OnFire(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Started:
                {
                    _shootAmmo = true;
                    break;
                }

            case InputActionPhase.Canceled:
                {
                    _shootAmmo = false;
                    break;
                }
        }
    }
}