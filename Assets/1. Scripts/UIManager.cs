using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    private void Awake()
    {
        instance = this;
    }

    [SerializeField] private Image scoreImg;
    [SerializeField] private TextMeshProUGUI scoreTmp;

    [SerializeField] private Image timerImg;
    public TextMeshProUGUI timerTmp;

    public void OnScoreChange(int currentScore, int maxScore)
    {
        scoreTmp.text = $"{currentScore}/{maxScore}";
        scoreImg.fillAmount = (float)currentScore / maxScore;
    }

    public void OnTimerChange(float currentTimer, float maxTimer)
    {
        timerTmp.text = $"{currentTimer:N1}/{maxTimer:N1}";
        timerImg.fillAmount = currentTimer / maxTimer;
    }
}
