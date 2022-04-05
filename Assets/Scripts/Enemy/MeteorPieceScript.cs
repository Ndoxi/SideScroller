using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorPieceScript : EnemyTemplate
{
    public Vector2 moveDirection;
    public int rotation;

    private void Update()
    {
        Move();
    }


    private void Move()
    {
        float posX = transform.position.x + moveDirection.x * enemyStats.speed * Time.deltaTime;
        float posY = transform.position.y + moveDirection.y * enemyStats.speed * Time.deltaTime;
        Vector2 pos = new Vector2(posX, posY);

        gameObject.transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 
            transform.eulerAngles.z + rotation);

        gameObject.transform.position = pos;

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) { return; }

        collision.gameObject.GetComponent<PlayerScript>()?.TakeDamage(enemyStats.damage);
    }


    public override void Death()
    {
        Destroy(gameObject);
    }
}
