using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class BossAI : MonoBehaviour
{
    public static Action StartAimAction;
    public static Action StopAimAction;

    [Header("Boss stats")]
    [SerializeField] private EnemyStats bossStats;

    [Header("Attacks")]
    [SerializeField] private ShootAttack shootAttack;
    [SerializeField] private LaserAttack laserAttack;
    [SerializeField] private RamAttack ramAttack;

    private GameObject playerGo;
    private IEnumerator aimingCoroutine;


    private void Start()
    {
        playerGo = GameObject.FindGameObjectWithTag("Player");
    }


    private void OnEnable()
    {
        StartAimAction += StartAim;
        StopAimAction += StopAim;
    }


    private void OnDisable()
    {
        StartAimAction -= StartAim;
        StopAimAction -= StopAim;
    }


    private void ShootAttack()
    {
        shootAttack.DoAttack();
    }


    private void LaserAttack()
    {
        laserAttack.DoAttack();
    }


    private void RamAttack()
    {
        ramAttack.DoAttack();
    }

    
    public void StartAim()
    {
        aimingCoroutine = Aiming();
        StartCoroutine(aimingCoroutine);
    }


    public void StopAim()
    {
        StopCoroutine(aimingCoroutine);
    }


    IEnumerator Aiming()
    {
        while (true)
        {
            Vector2 playerPosX = new Vector2(gameObject.transform.position.x, playerGo.transform.position.y);
            Vector2 newPos = Vector2.MoveTowards(gameObject.transform.position, playerPosX, 0.4f * bossStats.speed * Time.deltaTime);
            gameObject.transform.position = newPos;

            yield return new WaitForEndOfFrame();
        }
    }
}