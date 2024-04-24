using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    public static NoteManager instance;

    [SerializeField] private GameObject noteGroupPref;
    [SerializeField] private float noteGroupGap = 1f;
    [SerializeField]
    private KeyCode[] wholeKeyCodesArr = new KeyCode[]
    {
        KeyCode.A, KeyCode.B, KeyCode.D, KeyCode.F, KeyCode.G, KeyCode.H, KeyCode.J, KeyCode.K, KeyCode.L
    };

    [SerializeField] private int initNoteGroupNum = 2;


    private List<NoteGroup> noteGroupList = new List<NoteGroup>();
    private void Awake()
    {
        instance = this;
    }

    public void Create()
    {
        for (int i = 0; i < initNoteGroupNum; i++)
        {
            CreateNoteGroup(wholeKeyCodesArr[i]);
        }
    }

    public void CreateNoteGroup()
    {
        int noteGroupCount = noteGroupList.Count;
        if (wholeKeyCodesArr.Length <= noteGroupCount)
            return;

        KeyCode keycode = this.wholeKeyCodesArr[noteGroupCount];
        CreateNoteGroup(keycode);
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
        int randld = Random.Range(0, 2);
        bool isApple = randld == 0 ? true : false;

        foreach (NoteGroup noteGroup in noteGroupList)
        {
            if (keycode == noteGroup.KeyCode) 
            {
                noteGroup.OnInPut(isApple);
                break;
            }
        }
    }
}
