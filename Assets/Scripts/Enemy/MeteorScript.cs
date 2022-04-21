using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorScript : EnemyTemplate
{
    public static event EventManager.AddAmmoToPlayerAction AddAmmoToPlayer;

    public GameObject meteorPiecesPrefab;

    public GameObject loot { set; get; }

    private GameObject _sceneManager;
    
   
    private void Awake()
    {
        _sceneManager = GameObject.FindGameObjectWithTag("SceneManager");
        //_loot = _sceneManager.GetComponent<SceneManagerScript>().GetRandomAmmo();
        curentHealth = enemyStats.health;
    }


    private void Update()
    {
        Move();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) { return; }

        PlayerScript playerScript = collision.gameObject.GetComponentInChildren<PlayerScript>();

        if (playerScript == null) { return; }
        playerScript.TakeDamage(enemyStats.damage);
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        OnTriggerEnter2D(collision);
    }


    /// <summary>
    /// Caled whet meteor health &lt;= 0
    /// </summary>
    public override void Death()
    {
        Destroy(gameObject);
        GameObject meteorPiecesGO = Instantiate(meteorPiecesPrefab);
        meteorPiecesGO.transform.position = gameObject.transform.position;

        if (loot != null) { AddAmmoToPlayer(loot); }
        Destroy(meteorPiecesGO, 2f);
    }


    private void Move()
    {
        transform.position = new Vector2(gameObject.transform.position.x - enemyStats.speed * Time.deltaTime, transform.position.y);
    }
}
