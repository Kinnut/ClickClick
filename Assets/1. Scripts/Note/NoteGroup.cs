using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.PackageManager.UI;
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
    [SerializeField] private KeyCode keyCode;

    private List<Note> noteList = new List<Note>();

    public KeyCode KeyCode
    {
        get {
        return keyCode;}
    }


    void Start()
    {
        for (int i = 0; i < noteMaxNum; i++)
        {
            SpawnNote(true);
        }
    }

    private void SpawnNote(bool isApple)
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

        SpawnNote(isApple);

        Note delNote = noteList[0];
        delNote.Destroy();
        noteList.RemoveAt(0);

        for (int i = 0; i < noteList.Count; i++)
            noteList[i].transform.localPosition = Vector3.up * i * noteGap;

        anim.Play();
        btnSpriteRenderer.sprite = selectBtnSprite;
    }

    public void CallAniDone()
    {
        btnSpriteRenderer.sprite = normalBtnSprite;
    }
}
