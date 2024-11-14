using UnityEngine;

public class MouseCursorController : MonoBehaviour
{
    private bool cursorLocked = true;

    void Start()
    {
        LockCursor();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 左クリック時にロック
        {
            LockCursor();
        }

        if (Input.GetKeyDown(KeyCode.Escape)) // エスケープキーでロック解除
        {
            UnlockCursor();
        }
    }

    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        cursorLocked = true;
    }

    private void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        cursorLocked = false;
    }
}
