using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Standart emeny class.
/// </summary>
public class EnemyScript : EnemyTemplate
{
    [SerializeField] private float _aggroRange;
    [SerializeField] private bool _isAggro;

    //Movement
    private Vector2 _moveDirection;

    //AI
    private GameObject _playerGO;
    private float _distanceToPlayer = 0; 
    

    private void Awake()
    {
        maxHealth = enemyStats.health;
        curentHealth = maxHealth;
        _moveDirection = new Vector2(-1, 0).normalized;
    }


    private void Start()
    {
        _playerGO = GameObject.FindGameObjectWithTag("Player");
    }


    private void Update()
    {
        CalculateDoctanceToPlayer();

        if (_distanceToPlayer <= _aggroRange) { _isAggro = true; }

        if (_isAggro && _playerGO != null)
        {
            ChacePlayer();
        } else
        {
            Move();
        }   
    }


    public void SetMoveDirection(Vector2 direction)
    {
        _moveDirection = direction.normalized;
    }


    private void CalculateDoctanceToPlayer()
    {
        if (_playerGO == null) { return; }

        _distanceToPlayer = Vector2.Distance(transform.position, _playerGO.transform.position);
    }


    private void Move()
    {
        float x = transform.position.x + _moveDirection.x * enemyStats.speed * Time.deltaTime;
        float y = transform.position.y + _moveDirection.y * enemyStats.speed * Time.deltaTime;

        transform.position = new Vector2(x, y);
    }


    private void ChacePlayer()
    {
        if (_playerGO == null) { return; }
        transform.position = Vector2.MoveTowards(transform.position, 
            _playerGO.transform.position, enemyStats.speed * 1.5f * Time.deltaTime);
    }


    public override void Death()
    {
        Destroy(gameObject);
    }
}
