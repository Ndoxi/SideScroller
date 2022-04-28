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
    //[SerializeField] private BossScript bossScript;

    [Header("Start fight position")]
    [SerializeField] private Vector2 startFightPos;

    [Header("Attacks")]
    [SerializeField] private ShootAttack shootAttack;
    [SerializeField] private LaserAttack laserAttack;
    [SerializeField] private RamAttack ramAttack;

    private GameObject playerGo;

    private float recoverTime;

    private IEnumerator aimingCoroutine;


    private void Start()
    {
        playerGo = GameObject.FindGameObjectWithTag("Player");
        StartFight();
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


    private void StartFight()
    {
        StartCoroutine(Appear());
    }


    IEnumerator Appear()
    {
        while (true)
        {
            Vector2 newPos = Vector2.MoveTowards(gameObject.transform.position, startFightPos, 1.25f * bossStats.speed * Time.deltaTime);
            gameObject.transform.position = newPos;
            if (startFightPos.Equals(gameObject.transform.position)) { break; }

            yield return new WaitForEndOfFrame();
        }   

        StartCoroutine(StartThink());
    }


    IEnumerator StartThink()
    {
        while (true)
        {
            ChoiceRandomAttack();
            yield return new WaitForSeconds(recoverTime);
        }
    }


    private void ChoiceRandomAttack()
    {
        int shootAttackProbability = 25;
        int laserAttackProbability = 30;
        int ramAttackProbability = 25;
        int max = shootAttackProbability + laserAttackProbability + ramAttackProbability;

        int randomNumber = UnityEngine.Random.Range(0, max);

        if (InRange(randomNumber, 0, shootAttackProbability)) { ShootAttack(); return; }

        if (InRange(randomNumber, shootAttackProbability, 
            shootAttackProbability + laserAttackProbability)) { LaserAttack(); return; }

        if (InRange(randomNumber, shootAttackProbability + laserAttackProbability, 
            shootAttackProbability + laserAttackProbability + ramAttackProbability)) { RamAttack(); return; }
    }


    private bool InRange(int number, int min, int max)
    {
        if (number > min && number <= max) { return true; }
        return false;
    }


    private void ShootAttack()
    {
        recoverTime = 4;
        StartCoroutine(ShootAttackCoroutine());
    }


    IEnumerator ShootAttackCoroutine()
    {
        StartAim();
        StartShootingAttack();

        yield return new WaitForSeconds(3);

        StopAim();
        StopShootingAttack();
    }


    private void StartShootingAttack()
    {
        shootAttack.StartShooting();
    }


    private void StopShootingAttack()
    {
        shootAttack.StopShooting();
    }


    private void LaserAttack()
    {
        recoverTime = 3.5f;
        laserAttack.DoAttack();
    }


    private void RamAttack()
    {
        recoverTime = 4f;
        ramAttack.DoAttack();
    }

    
    public void StartAim()
    {
        aimingCoroutine = Aiming();
        StartCoroutine(aimingCoroutine);
    }


    public void StopAim()
    {
        if (aimingCoroutine == null) { return; }
        StopCoroutine(aimingCoroutine);
    }


    IEnumerator Aiming()
    {
        while (true)
        {
            Vector2 playerPosX = new Vector2(gameObject.transform.position.x, playerGo.transform.position.y);
            Vector2 newPos = Vector2.MoveTowards(gameObject.transform.position, playerPosX, 0.5f * bossStats.speed * Time.deltaTime);
            gameObject.transform.position = newPos;

            yield return new WaitForEndOfFrame();
        }
    }
}