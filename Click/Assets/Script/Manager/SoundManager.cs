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
    public void SetEffectSoundClip(AudioClip clip)
    {
        efectsound.Stop();
        efectsound.clip = clip;
        efectsound.Play();
    }
    public void bgmSetVolume(bool value)
    {
        bgm.volume = value ? 1 : 0;
    }
    public void efectSetVolume(bool value)
    {
        efectsound.volume = value ? 1 : 0;
    }
    //º¼·ý°ª ÀúÀå
}
