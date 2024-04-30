using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class EndingSceneManager : MonoBehaviour
{
    [Header("오브젝트")]
    public TextMeshProUGUI timerTxt;

    [Header("버튼")]
    public Button retryBtn;
    public Button exitBtn;

    private void Start()
    {
        timerTxt.text = $"클리어 타임 : {GameManager.instance.myTime}";
    }

    private void Awake()
    {
        retryBtn.onClick.AddListener(ClickRetry);
        exitBtn.onClick.AddListener(ClickExit);
    }

    private void ClickRetry()
    {
        SceneManager.LoadScene("1. MainScene");
    }

    public void ClickExit()
    {
        Application.Quit();
    }
}
