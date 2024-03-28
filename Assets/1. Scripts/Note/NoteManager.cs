using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    public static NoteManager instance;

    private void Awake()
    {
        instance = this;
    }

    public void OnInput(KeyCode keycode)
    {
        Debug.Log("keycode = " + keycode);
    }
}