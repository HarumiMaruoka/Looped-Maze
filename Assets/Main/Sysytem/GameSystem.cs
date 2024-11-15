using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSystem
{
    public static GameSystem Instance { get; } = new GameSystem();
    private GameSystem() { }

    private HashSet<int> _itemList = new HashSet<int>();

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Initialize()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private static void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        Instance.Reset();
    }

    public void RegisterItem(int id)
    {
        // アイテムを登録し、重複チェックを行う。
        if (!_itemList.Add(id))
        {
            Debug.LogError($"Item {id} already exists.");
        }
    }

    private HashSet<int> _collectedItems = new HashSet<int>();

    public void CollectItem(int id)
    {
        _collectedItems.Add(id);

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
