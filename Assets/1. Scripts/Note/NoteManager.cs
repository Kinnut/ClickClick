using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    public static NoteManager instance;

    [SerializeField] private KeyCode[] initKeyCodeArr;
    [SerializeField] private GameObject noteGroupPref;
    [SerializeField] private float noteGroupGap = 1f;

    private List<NoteGroup> noteGroupList = new List<NoteGroup>();
    private void Awake()
    {
        instance = this;
    }

    public void Create()
    {
        foreach (KeyCode keyCode in initKeyCodeArr)
            CreateNoteGroup(keyCode);
    }

    private void CreateNoteGroup(KeyCode keyCode)
    {
        GameObject noteGroupObj = Instantiate(noteGroupPref);
        noteGroupObj.transform.position = Vector3.right * noteGroupList.Count * noteGroupGap;

        NoteGroup noteGroup = noteGroupObj.GetComponent<NoteGroup>();
        noteGroup.Create(keyCode);

        noteGroupList.Add(noteGroup);
    }

    public void OnInput(KeyCode keycode)
    {
        int randld = Random.Range(0, noteGroupList.Count);
        bool isApple = randld == 0 ? true : false;

        foreach (NoteGroup noteGroup in noteGroupList)
        {
            if (keycode == noteGroup.KeyCode) 
            {
                noteGroup.OnInPut(isApple);
            }
        }
    }
}
