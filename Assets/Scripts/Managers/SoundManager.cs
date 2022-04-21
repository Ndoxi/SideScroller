using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SoundManager : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] GameObject backgroundMusicGO;
    [SerializeField] GameObject soundEffectsGO;

    [Space]
    [Header("Sound effects")]
    [SerializeField] AudioClip playerGetHit;
    [SerializeField] AudioClip shootingSound;
    [SerializeField] AudioClip enemyKilledSound;
    [SerializeField] AudioClip powerUpPickup;

    private AudioSource _backgroundMusic;
    private AudioSource _soundEffects;


    private void Awake()
    {
        _backgroundMusic = backgroundMusicGO.GetComponent<AudioSource>();
        _soundEffects = soundEffectsGO.GetComponent<AudioSource>();

        BindEvents();
    }


    private void OnDestroy()
    {
        UnbindEvents();
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
        if (_backgroundMusic == null) { return; }
        _backgroundMusic.volume = volume;
    }


    public void SetSoundEffectsVolume(float volume)
    {
        if (_soundEffects == null) { return; }
        _soundEffects.volume = volume;
    }


    private void PlaySoundEffect(AudioClip audioClip)
    {
        if (audioClip == null) { return; }
        _soundEffects.PlayOneShot(audioClip);
    }


    private void PlayerGetHit()
    {
        //Debug.Log("GetHit");
        if (playerGetHit == null) { return; }
        _soundEffects.PlayOneShot(playerGetHit);
    }


    private void PlayerShooting()
    {
        //Debug.Log("Shoot");
        if (shootingSound == null) { return; }
        _soundEffects.PlayOneShot(shootingSound);
    }


    private void EnemyKilled()
    {
       //Debug.Log("EnemyKilled");
        if (enemyKilledSound == null) { return; }
        _soundEffects.PlayOneShot(enemyKilledSound);
    }


    private void PlayerPickupPowerUp()
    {
        //Debug.Log("PowerUpPickedUp");
        if (powerUpPickup == null) { return; }
        _soundEffects.PlayOneShot(powerUpPickup);
    }
}
