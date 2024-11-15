using System;
using UnityEngine;

public static class Config
{
    private static string _audioVolumeKey = "audioVolume";
    private static string _mouseSensitivityKey = "mouseSensitivity";
    private static string _crosshairVisibilityKey = "crosshairVisibility";

    public static float AudioVolume
    {
        get => PlayerPrefs.GetFloat(_audioVolumeKey, 1f);
        set => PlayerPrefs.SetFloat(_audioVolumeKey, value);
    }

    public static float MouseSensitivity
    {
        get => PlayerPrefs.GetFloat(_mouseSensitivityKey, 1f);
        set
        {
            PlayerPrefs.SetFloat(_mouseSensitivityKey, value);
            OnMouseSensitivityChanged?.Invoke(value);
        }
    }

    public static bool CrosshairVisibility
    {
        get => PlayerPrefs.GetInt(_crosshairVisibilityKey, 1) == 1;
        set
        {
            PlayerPrefs.SetInt(_crosshairVisibilityKey, value ? 1 : 0);
            OnCrosshairVisibilityChanged?.Invoke(value);
        }
    }

    public static event Action<float> OnMouseSensitivityChanged;
    public static event Action<bool> OnCrosshairVisibilityChanged;
}
