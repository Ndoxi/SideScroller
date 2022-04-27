using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DrillAI : MonoBehaviour
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

    private Vector2 target = Vector2.zero;

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

        Move();
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
        float speedMult = 1;

        if (isAggro) { speedMult = 1.75f; }

        float x = transform.position.x + moveDirection.x * enemyStats.speed * speedMult * Time.deltaTime;
        float y = transform.position.y + moveDirection.y * enemyStats.speed * speedMult * Time.deltaTime;
        transform.position = new Vector2(x, y);
    }


    private void ChacePlayer()
    {
        if (playerGO == null) { return; }
        if (Vector2.zero.Equals(target) == false) { return; }

        target = playerGO.transform.position;
        Vector2 direction = (playerGO.transform.position - gameObject.transform.position).normalized;

        Vector2 targetPos = target;
        Vector2 thisPos = transform.position;
        targetPos.x = targetPos.x - thisPos.x;
        targetPos.y = targetPos.y - thisPos.y;
        float angle = Mathf.Atan2(targetPos.y, targetPos.x) * Mathf.Rad2Deg + 180;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        moveDirection = direction;      
    }
}
