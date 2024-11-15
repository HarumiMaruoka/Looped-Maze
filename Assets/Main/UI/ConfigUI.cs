using Cinemachine;
using System;
using UnityEngine;

public class ConfigUI : MonoBehaviour
{
    [SerializeField]
    private UnityEngine.UI.Slider _audioVolumeSlider;
    [SerializeField]
    private UnityEngine.UI.Slider _mouseSensitivitySlider;
    [SerializeField]
    private UnityEngine.UI.Toggle _crosshairVisibilityToggle;

    [SerializeField]
    private float _minAudioVolume = 0f;
    [SerializeField]
    private float _maxAudioVolume = 1f;

    [SerializeField]
    private float _minMouseSensitivity = 0.1f;
    [SerializeField]
    private float _maxMouseSensitivity = 10f;

    private void Start()
    {
        _audioVolumeSlider.minValue = _minAudioVolume;
        _audioVolumeSlider.maxValue = _maxAudioVolume;
        _audioVolumeSlider.value = Config.AudioVolume;
        _audioVolumeSlider.onValueChanged.AddListener(OnAudioVolumeChanged);

        _mouseSensitivitySlider.minValue = _minMouseSensitivity;
        _mouseSensitivitySlider.maxValue = _maxMouseSensitivity;
        _mouseSensitivitySlider.value = Config.MouseSensitivity;
        _mouseSensitivitySlider.onValueChanged.AddListener(OnMouseSensitivityChanged);

        _crosshairVisibilityToggle.isOn = Config.CrosshairVisibility;
        _crosshairVisibilityToggle.onValueChanged.AddListener(OnCrosshairVisibilityChanged);
    }

    private void OnAudioVolumeChanged(float value)
    {
        Config.AudioVolume = value;
    }

    private void OnMouseSensitivityChanged(float value)
    {
        Config.MouseSensitivity = value;
    }

    private void OnCrosshairVisibilityChanged(bool value)
    {
        Config.CrosshairVisibility = value;
    }
}
