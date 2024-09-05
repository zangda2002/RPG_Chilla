using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : SingleTon<AudioManager>
{
    [Header("-------------Audio Source----------")]
    [SerializeField] AudioSource musics;
    [SerializeField] AudioSource SFXs;
    [Header("-------------Audio Clip------------")]
    public AudioClip bgm;
    public AudioClip slash;
    public AudioClip death;
    public AudioClip grassWalk;
    private void Start()
    {
        musics.clip = bgm;
        musics.Play();
    }

    public void PlayerSFX(AudioClip clip)
    {
        SFXs.PlayOneShot(clip);
    }
}
