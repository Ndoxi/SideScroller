using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class VolumeSettings : MonoBehaviour
{
    [Header("Sound manager child game objects")]
    [SerializeField] GameObject musicVolumeSliderGO;
    [SerializeField] GameObject soundEffectsVolumeSliderGO;

    [Space]
    [Header("Music and effects input field placeholders")]
    [SerializeField] GameObject masterVolumeInputPlaceholderGo;
    [SerializeField] GameObject musicVolumeInputPlaceholderGo;
    [SerializeField] GameObject soundEffectsVolumeInputPlaceholderGO;

    private Slider _musicVolumeSlider;
    private Slider _soundEffectsVolumeSlider;
    private TextMeshProUGUI _masterVolumeInputText;
    private TextMeshProUGUI _musicVolumeInputText;
    private TextMeshProUGUI _soundEffectsVolumeInputText;


    private void Awake()
    {
        BindComponents();
    }
    

    private void BindComponents()
    {
        _musicVolumeSlider = musicVolumeSliderGO.GetComponent<Slider>();
        _soundEffectsVolumeSlider = soundEffectsVolumeSliderGO.GetComponent<Slider>();

        _masterVolumeInputText = masterVolumeInputPlaceholderGo.GetComponent<TextMeshProUGUI>();
        _musicVolumeInputText = musicVolumeInputPlaceholderGo.GetComponent<TextMeshProUGUI>();
        _soundEffectsVolumeInputText = soundEffectsVolumeInputPlaceholderGO.GetComponent<TextMeshProUGUI>();
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
