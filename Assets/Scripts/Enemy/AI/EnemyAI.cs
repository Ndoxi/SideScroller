using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyAI : MonoBehaviour
{
    [Header("Enemy data")]
    [SerializeField] private EnemyStats enemyStats;
    [SerializeField] private float aggroRange;
    [SerializeField] private bool isAggro;

    //Movement
    private Vector2 moveDirection;

    //AI
    private GameObject playerGO;
    private float distanceToPlayer = 0;


    private void Awake()
    {
        moveDirection = new Vector2(-1, 0).normalized;
    }


    private void Start()
    {
        playerGO = GameObject.FindGameObjectWithTag("Player");
    }


    private void Update()
    {
        CalculateDoctanceToPlayer();

        if (distanceToPlayer <= aggroRange) { isAggro = true; }

        if (isAggro && playerGO != null)
        {
            ChacePlayer();
        }
        else
        {
            Move();
        }
    }


    public void SetMoveDirection(Vector2 direction)
    {
        moveDirection = direction.normalized;
    }


    private void CalculateDoctanceToPlayer()
    {
        if (playerGO == null) { return; }

        distanceToPlayer = Vector2.Distance(transform.position, playerGO.transform.position);
    }


    private void Move()
    {
        float x = transform.position.x + moveDirection.x * enemyStats.speed * Time.deltaTime;
        float y = transform.position.y + moveDirection.y * enemyStats.speed * Time.deltaTime;

        transform.position = new Vector2(x, y);
    }


    private void ChacePlayer()
    {
        if (playerGO == null) { return; }
        transform.position = Vector2.MoveTowards(transform.position,
            playerGO.transform.position, enemyStats.speed * 1.5f * Time.deltaTime);
    }
}
