using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SoundManager : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] private AudioSource backgroundMusic;
    [SerializeField] private AudioSource soundEffects;

    [Space]
    [Header("Sound effects")]
    [SerializeField] AudioClip playerGetHit;
    [SerializeField] AudioClip shootingSound;
    [SerializeField] AudioClip enemyKilledSound;
    [SerializeField] AudioClip powerUpPickup;


    public static SoundManager Instance { get; set; }

    private void Awake()
    {
        BindEvents();
    }


    private void OnDestroy()
    {
        UnbindEvents();
    }


    private void OnEnable()
    {
        Instance = this;
    }


    private void BindEvents()
    {
        AmmoTemplate.PlayerShoot += PlayerShooting;
        PlayerScript.PlayerGetHit += PlayerGetHit;
        ShootingSystem.PlayerPickUpPowerUp += PlayerPickupPowerUp;
        EnemyTemplate.enemyKilled += EnemyKilled;
    }


    private void UnbindEvents()
    {
        AmmoTemplate.PlayerShoot -= PlayerShooting;
        PlayerScript.PlayerGetHit -= PlayerGetHit;
        ShootingSystem.PlayerPickUpPowerUp -= PlayerPickupPowerUp;
        EnemyTemplate.enemyKilled -= EnemyKilled;
    }


    public void SetBackGroundMusicVolume(float volume)
    {
        if (backgroundMusic == null) { return; }
        backgroundMusic.volume = volume;
    }


    public void SetSoundEffectsVolume(float volume)
    {
        if (soundEffects == null) { return; }
        soundEffects.volume = volume;
    }


    public static void PlaySoundEffect(AudioClip audioClip)
    {
        if (audioClip == null) { return; }
        Instance.soundEffects.PlayOneShot(audioClip);
    }


    private void PlayerGetHit()
    {
        //Debug.Log("GetHit");
        if (playerGetHit == null) { return; }
        soundEffects.PlayOneShot(playerGetHit);
    }


    private void PlayerShooting()
    {
        //Debug.Log("Shoot");
        if (shootingSound == null) { return; }
        soundEffects.PlayOneShot(shootingSound);
    }


    private void EnemyKilled()
    {
       //Debug.Log("EnemyKilled");
        if (enemyKilledSound == null) { return; }
        soundEffects.PlayOneShot(enemyKilledSound);
    }


    private void PlayerPickupPowerUp()
    {
        //Debug.Log("PowerUpPickedUp");
        if (powerUpPickup == null) { return; }
        soundEffects.PlayOneShot(powerUpPickup);
    }
}
