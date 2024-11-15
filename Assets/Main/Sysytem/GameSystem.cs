using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSystem
{
    public static GameSystem Instance { get; } = new GameSystem();
    private GameSystem() { }

    private HashSet<Item> _itemList = new HashSet<Item>();

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Initialize()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private static void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        Instance.Reset();
    }

    public void RegisterItem(Item item)
    {
        // アイテムを登録し、重複チェックを行う。
        if (!_itemList.Add(item))
        {
            Debug.LogError($"Item {item} already exists.");
        }
    }

    private HashSet<Item> _collectedItems = new HashSet<Item>();

    public void CollectItem(Item item)
    {
        _collectedItems.Add(item);

        if (_itemList.Count == _collectedItems.Count)
        {
            GameClear();
        }
    }

    public void Reset()
    {
        _itemList.Clear();
        _collectedItems.Clear();
    }

    public event Action OnGameCleared;

    private void GameClear()
    {
        Debug.Log("Game Clear!");
        OnGameCleared?.Invoke();
    }

    internal void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
