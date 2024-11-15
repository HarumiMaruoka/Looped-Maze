using System;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    private void Start()
    {
        Config.OnCrosshairVisibilityChanged += OnCrosshairVisibilityChanged;
        gameObject.SetActive(Config.CrosshairVisibility);
    }

    private void OnCrosshairVisibilityChanged(bool value)
    {
        gameObject.SetActive(value);
    }
}
