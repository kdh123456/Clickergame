using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoSingleton<SoundManager>
{
    [SerializeField]
    private AudioClip[] EfectClip;

    private AudioSource bgm;
    private AudioSource efectsound;
    private void Awake()
    {
        bgm = GetComponent<AudioSource>();
        efectsound = transform.GetChild(0).GetComponent<AudioSource>();
    }
    public void SetEffectSoundClip(int num)
    {
        efectsound.Stop();
        efectsound.clip = EfectClip[num];
        efectsound.Play();
    }
    public void bgmSetVolume(float value)
    {
        bgm.volume = value;
    }
    public void efectSetVolume(float value)
    {
        efectsound.volume = value;
    }
    //볼륨값 저장
}
