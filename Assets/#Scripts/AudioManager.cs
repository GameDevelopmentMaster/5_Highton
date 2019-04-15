using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource bgmSource;
    public AudioSource shotSource;
    public AudioSource clickSource;

    public AudioClip[] bgmClip = new AudioClip[5];

    private void Awake()
    {
        if (AudioManager.Instance == null)
            AudioManager.Instance = this;
        else
            Destroy(gameObject);
    }

    public void PlayBgm(int index)
    {
        bgmSource.clip = bgmClip[index];
        bgmSource.Play();
    }

    public void StopBgm()
    {
        bgmSource.Stop();
    }

    public void PlayClick()
    {
        clickSource.Play();
    }

    public void PlayShot()
    {
        shotSource.Play();
    }
}
