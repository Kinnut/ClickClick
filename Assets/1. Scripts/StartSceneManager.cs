using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartSceneManager : MonoBehaviour
{
    [Header("��ư")]
    public Button startBtn;
    public Button settingBtn;
    public Button quitBtn;
    public Button exitBtn;

    [Header("������Ʈ")]
    public GameObject setting;

    private void Awake()
    {
        startBtn.onClick.AddListener(ClickStart);
        settingBtn.onClick.AddListener(ClickSetitng);
        exitBtn.onClick.AddListener(ClickExit);
        quitBtn.onClick.AddListener(ClickQuit);
    }

    void ClickStart()
    {
        SceneManager.LoadScene("1. MainScene");
    }

    void ClickSetitng()
    {
        setting.SetActive(true);
    }

    void ClickExit()
    {
        setting.SetActive(false);
    }

    void ClickQuit()
    {
        Application.Quit();
    }
}
