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

    private ShootingSystem shootingSystem;
    private Vector2 playerDirection;
    private bool shootAmmo;


    private void Awake()
    {
        shootingSystem = shootingSystemGO.GetComponent<ShootingSystem>();
    }


    private void Update()
    {
        PerformActions();
    }


    public void ConfigureCancel(MenuManager menuManager)
    {
        PlayerInput playerInput = gameObject.GetComponent<PlayerInput>();
        InputAction inputActionCancel = playerInput.actions.FindAction("Cancel");

        inputActionCancel.performed += menuManager.OnCancel;
    }


    private void PerformActions()
    {
        transform.Translate(playerDirection * rocketStats.speed * Time.deltaTime);

        if (shootAmmo)
        {
            shootingSystem.ShootAmmo();
        }
    }


    public void OnMovement(InputAction.CallbackContext context)
    {
        playerDirection = context.ReadValue<Vector2>();
    }


    public void OnFire(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Started:
                {
                    shootAmmo = true;
                    break;
                }

            case InputActionPhase.Canceled:
                {
                    shootAmmo = false;
                    break;
                }
        }
    }
}