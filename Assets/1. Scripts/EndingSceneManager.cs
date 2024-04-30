using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class EndingSceneManager : MonoBehaviour
{
    [Header("������Ʈ")]
    public TextMeshProUGUI timerTxt;

    [Header("��ư")]
    public Button retryBtn;
    public Button exitBtn;

    private void Start()
    {
        timerTxt.text = $"Ŭ���� Ÿ�� : {GameManager.instance.myTime}";
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
