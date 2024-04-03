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
        int randld = Random.Range(0, noteGroupArr.Length);
        bool isApple = randld == 0 ? true : false;

        foreach (NoteGroup noteGroup in noteGroupArr)
        {
            if (keycode == noteGroup.KeyCode) 
            {
                noteGroup.OnInPut(isApple);
            }
        }


        if (keycode == KeyCode.A)
            noteGroupArr[0].OnInPut(isApple);
        else if (keycode == KeyCode.S)
            noteGroupArr[1].OnInPut(isApple);
        else if (keycode == KeyCode.D)
            noteGroupArr[2].OnInPut(isApple);
    }
}
