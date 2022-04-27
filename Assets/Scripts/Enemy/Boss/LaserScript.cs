using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using System;


public class LaserScript : MonoBehaviour
{
    [Header("Colliders")]
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private CircleCollider2D circleCollider;

    [Header("Animation")]
    [SerializeField] private Animator laserAnimator;

    private int laserDamage;


    private void Awake()
    {
        TurnOffColliders();

        BossAI.StartAimAction?.Invoke();
    }

    private void OnEnable()
    {
        LaserStateMachine.FireLaserAction += FireLaser;
    }


    private void OnDisable()
    {
        LaserStateMachine.FireLaserAction -= FireLaser;
    }


    private void TurnOnColliders()
    {
        boxCollider.enabled = true;
        circleCollider.enabled = true;
    }


    private void TurnOffColliders()
    {
        boxCollider.enabled = false;
        circleCollider.enabled = false;
    }


    public void SetLaserDamage(int laserDamage)
    {
        this.laserDamage = laserDamage;
    }


    public void FireLaser()
    {
        BossAI.StopAimAction?.Invoke();
        TurnOnColliders();
        StartCoroutine(StopLiser());
    }


    IEnumerator StopLiser()
    {
        yield return new WaitForSeconds(2.5f);
        Destroy(gameObject);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") == false) { return; }

        PlayerScript playerScript = collision.gameObject.GetComponentInChildren<PlayerScript>();

        if (playerScript == null) { return; }
        playerScript.TakeDamage(laserDamage);
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        OnTriggerEnter2D(collision);
    }
}
