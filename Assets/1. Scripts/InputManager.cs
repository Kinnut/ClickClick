using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            NoteManager.instance.OnInput(KeyCode.A);

        if (Input.GetKeyDown(KeyCode.S))
            NoteManager.instance.OnInput(KeyCode.S);

        if (Input.GetKeyDown(KeyCode.D))
            NoteManager.instance.OnInput(KeyCode.D);
    }
}

