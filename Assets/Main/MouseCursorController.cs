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
        if (Input.GetMouseButtonDown(0)) // ���N���b�N���Ƀ��b�N
        {
            LockCursor();
        }

        if (Input.GetKeyDown(KeyCode.Escape)) // �G�X�P�[�v�L�[�Ń��b�N����
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
