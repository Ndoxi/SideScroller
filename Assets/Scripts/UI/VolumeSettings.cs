using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class VolumeSettings : MonoBehaviour
{
    [Header("Audio sources")]
    [SerializeField] private AudioSource mucisAudioSource;
    [SerializeField] private AudioSource soundEffectsAudioSource;

    [Space]
    [Header("Sound manager child game objects")]
    [SerializeField] private GameObject masterVolumeSliderGO;
    [SerializeField] private GameObject musicVolumeSliderGO;
    [SerializeField] private GameObject soundEffectsVolumeSliderGO;

    [Space]
    [Header("Music and effects input field placeholders")]
    [SerializeField] private GameObject masterVolumeInputPlaceholderGo;
    [SerializeField] private GameObject musicVolumeInputPlaceholderGo;
    [SerializeField] private GameObject soundEffectsVolumeInputPlaceholderGO;

    private Slider _masterVolumeSlider;
    private Slider _musicVolumeSlider;
    private Slider _soundEffectsVolumeSlider;
    private TextMeshProUGUI _masterVolumeInputText;
    private TextMeshProUGUI _musicVolumeInputText;
    private TextMeshProUGUI _soundEffectsVolumeInputText;


    private void Awake()
    {
        BindComponents();
        SetSlidersValues();
        AddListenersToSliders();
    }
    

    private void BindComponents()
    {
        _masterVolumeSlider = masterVolumeSliderGO.GetComponent<Slider>();
        _musicVolumeSlider = musicVolumeSliderGO.GetComponent<Slider>();
        _soundEffectsVolumeSlider = soundEffectsVolumeSliderGO.GetComponent<Slider>();

        _masterVolumeInputText = masterVolumeInputPlaceholderGo.GetComponent<TextMeshProUGUI>();
        _musicVolumeInputText = musicVolumeInputPlaceholderGo.GetComponent<TextMeshProUGUI>();
        _soundEffectsVolumeInputText = soundEffectsVolumeInputPlaceholderGO.GetComponent<TextMeshProUGUI>();
    }


    private void SetSlidersValues()
    {
        _masterVolumeSlider.value = PlayerPrefs.GetFloat(SaveLoadManager.masterVolumeKey, 1);
        _musicVolumeSlider.value = mucisAudioSource.volume;
        _soundEffectsVolumeSlider.value = soundEffectsAudioSource.volume;
    }


    private void AddListenersToSliders()
    {
        _masterVolumeSlider.onValueChanged.AddListener(operation =>
        {
            SaveLoadManager.SaveSoundSettings(SaveLoadManager.masterVolumeKey, _masterVolumeSlider.value);
        });

        _musicVolumeSlider.onValueChanged.AddListener(operation =>
        {
            SaveLoadManager.SaveSoundSettings(SaveLoadManager.musicVolumeKey, _musicVolumeSlider.value);
        });

        _soundEffectsVolumeSlider.onValueChanged.AddListener(operation =>
        {
            SaveLoadManager.SaveSoundSettings(SaveLoadManager.soundEffectsVolumeKey, _soundEffectsVolumeSlider.value);
        });
    }


    public void SetMasterVolume(float volume)
    {
        _musicVolumeSlider.value = volume;
        _soundEffectsVolumeSlider.value = volume;
    }


    public void SetMasterVolumeFieldText(float volume)
    {
        if (_masterVolumeInputText == null) { return; }

        int volumeInt = (int)(volume * 100);
        _masterVolumeInputText.text = volumeInt.ToString();
    }


    public void SetMusicVolumeFieldText(float volume)
    {
        if (_musicVolumeInputText == null) { return; }

        int volumeInt = (int)(volume * 100);
        _musicVolumeInputText.text = volumeInt.ToString();
    }


    public void SetSoundEffectsVolumeFieldText(float volume)
    {
        if (_soundEffectsVolumeInputText == null) { return; }

        int volumeInt = (int)(volume * 100);
        _soundEffectsVolumeInputText.text = volumeInt.ToString();
    }
}
