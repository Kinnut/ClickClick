using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioSource btnSource;

    public void SetMusicVolume(float volume) // 배경음악을 출력하는 함수
    {
        musicSource.volume = volume;
    }

    public void SetButtonVolume(float volume) // 버튼 효과음을 출력하는 함수
    {
        btnSource.volume = volume;
    }

    public void OnSfx() // 효과음 함수 이거 켜지면 버튼 효과음 나옴
    {
        btnSource.Play();
    }
}
