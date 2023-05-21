using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouseUnlock : MonoBehaviour
{
    private bool cursorLocked = true;

    void Start()
    {
        LockCursor();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            cursorLocked = !cursorLocked;
            if (cursorLocked)
            {
                LockCursor();
            }
            else
            {
                UnlockCursor();
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            LockCursor();
        }
    }

    void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}