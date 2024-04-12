using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private int maxScore;
    [SerializeField] private int noteGroupCreateScore = 10;
    [SerializeField] private GameObject gameClearObj;
    [SerializeField] private GameObject gameOverObj;
        

    private int score;
    private int nextNoteGroupUnlockCnt;

    [SerializeField] private float maxTime = 30f;

    public bool IsGameDone
    {
        get
        {
            if (gameClearObj.activeSelf || gameOverObj.activeSelf)
                return true;
            else
                return false;
        }
    }

    private void Start()
    {
        UIManager.instance.OnScoreChange(this.score, maxScore);
        NoteManager.instance.Create();

        gameClearObj.SetActive(false);
        gameOverObj.SetActive(false);

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

            if(IsGameDone)
            {
                yield break;
            }
        }

        gameOverObj.SetActive(true);
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
                gameClearObj.SetActive(true);
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
