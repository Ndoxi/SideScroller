using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LaserAttack : Attack
{
    [Header("Turret")]
    [SerializeField] private GameObject turret;

    [Header("Prefabs")]
    [SerializeField] private GameObject laserPrefab;

    [Header("Attack stats")]
    [SerializeField] private AmmoData laserStats;

    [Header("Sound effects")]
    [SerializeField] private AudioClip preparingLaserSound;
    [SerializeField] private AudioClip shootLaserSound;

    private SpriteRenderer laserSprite;


    private void OnEnable()
    {
        LaserStateMachine.FireLaserAction += PlayShootingLaserSound;    
    }


    private void OnDisable()
    {
        LaserStateMachine.FireLaserAction -= PlayShootingLaserSound;
    }


    public override void DoAttack()
    {
        if (turret == null) { return; }

        GameObject laser = Instantiate(laserPrefab, turret.transform);
        laserSprite = laser.GetComponentInChildren<SpriteRenderer>();

        float spriteWidht = 0;

        if (laserSprite != null) 
        {
            spriteWidht = laserSprite.size.x;
        }

        Vector2 pos = turret.transform.position;
        pos.x -= spriteWidht / 2;
        laser.transform.position = pos;

        PlayPreparingLaserSound();

        LaserScript laserScript = laser.GetComponent<LaserScript>();

        if (laserScript == null) { return; }
        laserScript.SetLaserDamage(laserStats.damage);
    }


    private void PlayPreparingLaserSound()
    {
        SoundManager.PlaySoundEffect(preparingLaserSound);
    }


    private void PlayShootingLaserSound()
    {
        SoundManager.PlaySoundEffect(shootLaserSound);
    }
}
