using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioSource btnSource;

    public void SetMusicVolume(float volume) // ��������� ����ϴ� �Լ�
    {
        musicSource.volume = volume;
    }

    public void SetButtonVolume(float volume) // ��ư ȿ������ ����ϴ� �Լ�
    {
        btnSource.volume = volume;
    }

    public void OnSfx() // ȿ���� �Լ� �̰� ������ ��ư ȿ���� ����
    {
        btnSource.Play();
    }
}
