using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NoteGroup : MonoBehaviour
{

    [SerializeField] private int noteMaxNum = 5;
    [SerializeField] private GameObject notePref;
    [SerializeField] private GameObject noteSpawn;
    [SerializeField] private float noteGap = 6;

    [SerializeField] private SpriteRenderer btnSpriteRenderer;
    [SerializeField] private Sprite normalBtnSprite;
    [SerializeField] private Sprite selectBtnSprite;
    [SerializeField] private Animation anim;
    [SerializeField] private TextMeshPro keyCodeTMp;
    private KeyCode keyCode;

    private List<Note> noteList = new List<Note>();

    public KeyCode KeyCode
    {
        get {
        return keyCode;}
    }

    public void Create(KeyCode _Keycode)
    {
        this.keyCode = _Keycode;
        keyCodeTMp.text = _Keycode.ToString();

        for (int i = 0; i < noteMaxNum; i++)
        {
            CreateNote(true);
        }

        InputManager.instance.AddKeyCode(keyCode);
    }

    private void CreateNote(bool isApple)
    {
        GameObject noteGameObj = Instantiate(notePref);

        noteGameObj.transform.SetParent(noteSpawn.transform);
        noteGameObj.transform.localPosition = Vector3.up * noteList.Count * noteGap;

        Note note = noteGameObj.GetComponent<Note>();
        note.SetSprite(isApple);

        noteList.Add(note);
    }

    public void OnInPut(bool isApple)
    {
        if (noteList.Count == 0)
            return;

        Note delNote = noteList[0];
        delNote.DeleteNote();
        noteList.RemoveAt(0);

        for (int i = 0; i < noteList.Count; i++)
            noteList[i].transform.localPosition = Vector3.up * i * noteGap;

        CreateNote(isApple);

        anim.Play();
        btnSpriteRenderer.sprite = selectBtnSprite;
    }

    public void CallAniDone()
    {
        btnSpriteRenderer.sprite = normalBtnSprite;
    }
}
