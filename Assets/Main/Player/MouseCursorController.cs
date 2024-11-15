using Cinemachine;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseCursorController : MonoBehaviour
{
    [SerializeField]
    private PlayerMovement _playerMovement;
    [SerializeField]
    private CinemachineVirtualCamera _cinemachineVirtualCamera;
    [SerializeField]
    private GameObject _ui;

    private void Start()
    {
        GameSystem.Instance.OnGameCleared += OnGameCleared;
        Config.OnMouseSensitivityChanged += OnMouseSensitivityChanged;

        OnMouseSensitivityChanged(Config.MouseSensitivity);
        UnlockCursor();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !IsPointerOverUI()) // 左クリック時にロック
        {
            LockCursor();
        }

        if (Input.GetKeyDown(KeyCode.Escape)) // エスケープキーでロック解除
        {
            UnlockCursor();
        }
    }

    private void OnDestroy()
    {
        UnlockCursor();

        GameSystem.Instance.OnGameCleared -= OnGameCleared;
        Config.OnMouseSensitivityChanged -= OnMouseSensitivityChanged;
    }

    public void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        _cinemachineVirtualCamera.enabled = true;
        _playerMovement.enabled = true;
    }

    public void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        _cinemachineVirtualCamera.enabled = false;
        _playerMovement.enabled = false;
    }

    private void OnGameCleared()
    {
        Destroy(this);
    }

    private void OnMouseSensitivityChanged(float value)
    {
        var pov = _cinemachineVirtualCamera.GetCinemachineComponent<CinemachinePOV>();
        pov.m_HorizontalAxis.m_MaxSpeed = 100 + value * 100;
        pov.m_VerticalAxis.m_MaxSpeed = 100 + value * 100;
    }

    private bool IsPointerOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }
}
