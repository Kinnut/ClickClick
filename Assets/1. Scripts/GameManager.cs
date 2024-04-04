using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private int maxScore;
    private int score;

    private void Start()
    {
        UIManager.Instance.OnScoreChange(this.score, maxScore);
    }

    internal void CalculateScore(bool isApple)
    {
        if (isApple)
            score++;
        else
            score--;


        UIManager.Instance.OnScoreChange(this.score, maxScore);
    }

    private void Awake()
    {
        instance = this;
    }
}
