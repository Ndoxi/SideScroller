using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [Header("Rocket stats")]
    public RocketStats rocketStats;

    [Space]
    [Header("Shooting system")]
    public GameObject shootingSystemGO;

    private ShootingSystem _shootingSystem;
    private float _playerSpeed;
    private Vector2 _playerDirection;
    private bool _shootAmmo = false;

    private void Awake()
    {
        _shootingSystem = shootingSystemGO.GetComponent<ShootingSystem>();
        _playerSpeed = rocketStats.speed;
    }


    void Update()
    {
        HandleInput();
        Move();
        Shoot();
    }


    private void HandleInput()
    {
        float directionX = Input.GetAxisRaw("Horizontal");
        float directionY = Input.GetAxisRaw("Vertical");
        _playerDirection = new Vector2(directionX, directionY).normalized;

        if (Input.GetMouseButton(0))
        {
            _shootAmmo = true;
        } else
        {
            _shootAmmo = false;
        }
    }


    private void Move()
    {
        float x = transform.position.x + _playerDirection.x * _playerSpeed * Time.deltaTime;
        float y = transform.position.y + _playerDirection.y * _playerSpeed * Time.deltaTime;

        transform.position = new Vector2(x, y);
    }


    private void Shoot()
    {
        if (!_shootAmmo) { return; }
        _shootingSystem.ShootAmmo();
    }
}