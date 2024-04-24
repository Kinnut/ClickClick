using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResolutionSetting : MonoBehaviour
{
    List<Resolution> resolutions = new List<Resolution>();

    FullScreenMode screenMode;

    public GameObject panel;

    public TMP_Dropdown resolutionDropdown;
    public Toggle fullscreenBtn;

    public int resolutionNum;

    void Start()
    {
        InitUI();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            panel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    void InitUI()
    {
        resolutions.Clear();

        foreach (Resolution res in Screen.resolutions)
        {
            if (res.refreshRate == 60)
            {
                resolutions.Add(res);

                if (res.width == 1200 && res.height == 600)
                    break;
            }
        }

        if (!resolutions.Exists(r => r.width == 1200 && r.height == 600))
        {
            Resolution customRes = new Resolution();
            customRes.width = 1200;
            customRes.height = 600;
            customRes.refreshRate = 60;
            resolutions.Add(customRes);
        }

        resolutionDropdown.options.Clear();

        int optionNum = 0;
        foreach (Resolution item in resolutions)
        {
            TMP_Dropdown.OptionData option = new TMP_Dropdown.OptionData();
            option.text = item.width + "x" + item.height + " " + item.refreshRate + "hz";
            resolutionDropdown.options.Add(option);

            if (item.width == Screen.width && item.height == Screen.height)
                resolutionDropdown.value = optionNum;

            optionNum++;
        }

        resolutionDropdown.RefreshShownValue();

        fullscreenBtn.isOn = Screen.fullScreenMode.Equals(FullScreenMode.FullScreenWindow);
    }

    public void DropboxOptionChange(int x)
    {
        resolutionNum = x;
    }

    public void FullScreenBtn(bool isFull)
    {
        screenMode = isFull ? FullScreenMode.FullScreenWindow : FullScreenMode.Windowed;
    }

    public void CheckBtn()
    {
        Screen.SetResolution(resolutions[resolutionNum].width, resolutions[resolutionNum].height, screenMode);
        panel.SetActive(false);
        Time.timeScale = 1;
    }

}
