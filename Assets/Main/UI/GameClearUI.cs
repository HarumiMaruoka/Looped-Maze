using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameClearUI : MonoBehaviour
{
    [SerializeField]
    private GameObject _gameClearUI;
    [SerializeField]
    private Image _background;
    [SerializeField]
    private TMPro.TextMeshProUGUI _message;
    [SerializeField]
    private Button _restartButton;
    [SerializeField]
    private TMPro.TextMeshProUGUI _restartButtonText;

    [SerializeField]
    private float _backgroundDuration = 1.0f;
    [SerializeField]
    private float _messageDuration = 1.0f;
    [SerializeField]
    private float _restartButtonDuration = 1.0f;

    private void Start()
    {
        GameSystem.Instance.OnGameCleared += Show;
        _restartButton.onClick.AddListener(GameSystem.Instance.Restart);
    }

    private void OnDestroy()
    {
        GameSystem.Instance.OnGameCleared -= Show;
    }

    public void Show()
    {
        StartCoroutine(ShowAsync());
    }

    private IEnumerator ShowAsync()
    {
        _gameClearUI.SetActive(true);
        var tempColor = _background.color;
        _background.color = new Color(tempColor.r, tempColor.g, tempColor.b, 0);
        tempColor = _message.color;
        _message.color = new Color(tempColor.r, tempColor.g, tempColor.b, 0);
        tempColor = _restartButton.image.color;
        _restartButton.image.color = new Color(tempColor.r, tempColor.g, tempColor.b, 0);
        tempColor = _restartButtonText.color;
        _restartButtonText.color = new Color(tempColor.r, tempColor.g, tempColor.b, 0);

        _restartButton.interactable = false;

        var duration = _backgroundDuration;
        for (float t = 0; t < duration; t += Time.deltaTime)
        {
            _background.color = new Color(_background.color.r, _background.color.g, _background.color.b, t / duration);
            yield return null;
        }
        _background.color = new Color(_background.color.r, _background.color.g, _background.color.b, 1);

        duration = _messageDuration;
        for (float t = 0; t < duration; t += Time.deltaTime)
        {
            _message.color = new Color(_message.color.r, _message.color.g, _message.color.b, t / duration);
            yield return null;
        }
        _message.color = new Color(_message.color.r, _message.color.g, _message.color.b, 1);

        duration = _restartButtonDuration;
        for (float t = 0; t < duration; t += Time.deltaTime)
        {
            _restartButton.image.color = new Color(_restartButton.image.color.r, _restartButton.image.color.g, _restartButton.image.color.b, t / duration);
            _restartButtonText.color = new Color(_restartButtonText.color.r, _restartButtonText.color.g, _restartButtonText.color.b, t / duration);
            yield return null;
        }
        _restartButton.image.color = new Color(_restartButton.image.color.r, _restartButton.image.color.g, _restartButton.image.color.b, 1);
        _restartButtonText.color = new Color(_restartButtonText.color.r, _restartButtonText.color.g, _restartButtonText.color.b, 1);

        _restartButton.interactable = true;
    }
}