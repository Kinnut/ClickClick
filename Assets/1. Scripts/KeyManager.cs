using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    public static KeyManager instance;

    private List<KeyCode> keyCodeList = new List<KeyCode>();

    private void Awake()
    {
        instance = this;
    }

    public void AddKeyCode(KeyCode _keyCode)
    {
        keyCodeList.Add(_keyCode);
    }

    private void Update()
    {
        if (GameManager.instance.IsGameDone)
        {
            return;
        }

        foreach (KeyCode keyCode in keyCodeList)
        {
            if (Input.GetKeyDown(keyCode) == true)
            {
                NoteManager.instance.OnInput(keyCode);
                break;
            }
        }
    }
}

