using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject setting;

    public static GameManager instance;

    [SerializeField] private int maxScore;
    [SerializeField] private int noteGroupCreateScore = 10;

    private int score;
    private int nextNoteGroupUnlockCnt;

    [SerializeField] private float maxTime = 30f;

    private void Start()
    {
        UIManager.instance.OnScoreChange(this.score, maxScore);
        NoteManager.instance.Create();

        StartCoroutine(TimerCoroutine());
    }

    IEnumerator TimerCoroutine()
    {
        float currentTime = 0;

        while (currentTime < maxTime)
        {
            currentTime += Time.deltaTime;
            UIManager.instance.OnTimerChange(currentTime, maxTime);
            yield return null;
        }

        SceneManager.LoadScene("2. EndingScene");
    }

    internal void CalculateScore(bool isApple)
    {
        if (isApple)
        {
            score++;
            nextNoteGroupUnlockCnt++;

            if (noteGroupCreateScore <= nextNoteGroupUnlockCnt)
            {
                nextNoteGroupUnlockCnt = 0;
                NoteManager.instance.CreateNoteGroup();
            }

            if (maxScore <= score)
            {
                SceneManager.LoadScene("2. ClearScene");
            }
        }
        else
            score--;

        UIManager.instance.OnScoreChange(this.score, maxScore);
    }

    private void Awake()
    {
        instance = this;
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
