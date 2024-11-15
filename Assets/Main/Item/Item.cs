using System;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    private AudioClip _collectSound;

    private void Start()
    {
        GameSystem.Instance.RegisterItem(this);
    }

    internal void Collect()
    {
        AudioSource.PlayClipAtPoint(_collectSound, transform.position, Config.AudioVolume);
        GameSystem.Instance.CollectItem(this);
        Destroy(gameObject);
    }
}
