using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;


public class SaveLoadManager : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private AudioSource mucisAudioSource;
    [SerializeField] private AudioSource soundEffectsAudioSource;

    public const string playerControlsKey = "playerControls";
    public const string masterVolumeKey = "masterVolumeSettings";
    public const string musicVolumeKey = "musicSettings";
    public const string soundEffectsVolumeKey = "soundEffectsSettings";


    private void Awake()
    {
        LoadBindings();
        LoadSoundSettings();
    }


    private void LoadBindings()
    {
        string binds = PlayerPrefs.GetString(playerControlsKey, string.Empty);

        if (string.IsNullOrEmpty(binds)) { return; }

        playerInput.actions.LoadBindingOverridesFromJson(binds);
    }


    public static void SaveSoundSettings(string key, float value)
    {
        if (value < 0 || value > 1) { return; }

        PlayerPrefs.SetFloat(key, value);
    }


    private void LoadSoundSettings()
    {
        float musicVolume = PlayerPrefs.GetFloat(musicVolumeKey, -1);
        float soundEffectsVolume = PlayerPrefs.GetFloat(soundEffectsVolumeKey, -1);

        if (musicVolume == -1 || soundEffectsVolume == -1) { return; }


        mucisAudioSource.volume = musicVolume;
        soundEffectsAudioSource.volume = soundEffectsVolume;
    }
}
