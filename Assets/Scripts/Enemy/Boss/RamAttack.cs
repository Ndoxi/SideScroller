using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RamAttack : Attack
{
    [Header("Boss stats")]
    [SerializeField] private EnemyStats bossStats;

    [Header("Danger zone")]
    [SerializeField] private GameObject dangerZoneGO;
    [SerializeField] private Animation dangerZoneAnimation;

    private Vector2 posBeforeRam;


    public override void DoAttack()
    {
        posBeforeRam = gameObject.transform.position;

        dangerZoneGO.SetActive(true);

        StartCoroutine(PrepareForRam());
    }


    IEnumerator PrepareForRam()
    {
        while (true)
        {
            if (dangerZoneAnimation.isPlaying == false) { break; }
            yield return new WaitForEndOfFrame();
        }

        dangerZoneGO.SetActive(false);
        StartCoroutine(StartRam());
    }


    IEnumerator StartRam()
    {
        while (true)
        {
            Vector2 newPos = gameObject.transform.position;
            newPos.x -= 6 * bossStats.speed * Time.deltaTime;

            if (newPos.x <= -8) { break; }

            gameObject.transform.position = newPos;
            
            yield return new WaitForEndOfFrame();
        }

        StartCoroutine(RecoverFromRam());
    }


    IEnumerator RecoverFromRam()
    {
        while (true)
        {
            gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, posBeforeRam, 2 * bossStats.speed * Time.deltaTime);

            if (gameObject.transform.position.Equals(posBeforeRam)) { break; }

            yield return new WaitForEndOfFrame();
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") == false) { return; }

        PlayerScript playerScript = collision.gameObject.GetComponentInChildren<PlayerScript>();

        if (playerScript == null) { return; }
        playerScript.TakeDamage(bossStats.damage * 2);
    }
}
