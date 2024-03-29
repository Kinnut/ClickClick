using System.Collections;
using System.Collections.Generic;
using UnityEditor;
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


    private List<Note> noteList = new List<Note>();

    void Start()
    {
        for (int i = 0; i < noteMaxNum; i++)
        {
            GameObject noteGameObj = Instantiate(notePref);
            noteGameObj.transform.SetParent(noteSpawn.transform);
            noteGameObj.transform.localPosition = Vector3.up * noteList.Count * noteGap;
            Note note = noteGameObj.GetComponent<Note>();

            noteList.Add(note);
        }
    }

    public void OnInPut(bool y)
    {
        anim.Play();
        btnSpriteRenderer.sprite = selectBtnSprite;
    }

    public void CallAniDone()
    {
        btnSpriteRenderer.sprite = normalBtnSprite;
    }
}
