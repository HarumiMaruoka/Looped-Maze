using System;
using UnityEngine;

public class Item : MonoBehaviour
{
    private void Start()
    {
        GameSystem.Instance.RegisterItem(this);
    }

    internal void Collect()
    {
        GameSystem.Instance.CollectItem(this);
        Destroy(gameObject);
    }
}
