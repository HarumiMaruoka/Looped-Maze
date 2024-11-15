using System;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private int _id;

    private void Start()
    {
        GameSystem.Instance.RegisterItem(_id);
    }

    internal void Collect()
    {
        GameSystem.Instance.CollectItem(_id);
        Destroy(gameObject);
    }
}
