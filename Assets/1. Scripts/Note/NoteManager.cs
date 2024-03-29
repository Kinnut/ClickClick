using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    public static NoteManager instance;

    [SerializeField] private NoteGroup[] noteGroupArr;

    private void Awake()
    {
        instance = this;
    }

    public void OnInput(KeyCode keycode)
    {
        if (keycode == KeyCode.A)
        {
            noteGroupArr[0].OnInPut(true);
        }

        if (keycode == KeyCode.S)
        {
            noteGroupArr[1].OnInPut(true);
        }
    }
}
