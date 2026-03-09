using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    [Header("BGM")]
    public AudioClip bgmClip;
    [SerializeField] private float bgmVolume;
    AudioSource bgmPlayer;
    AudioHighPassFilter bgmEffect;

    [Header("SFX")]
    public AudioClip[] sfxClips;
    [SerializeField] private float sfxVolume;
    [SerializeField] int channels;
    AudioSource[] sfxPlayers;
    int channelIndex;

    public enum sfx {JumpSound,Lose }

    private void Start()
    {
       
    }

    private void Awake()
    {        
        playeSound();
    }

    public void playeSound()
    {
        GameObject bgmObject = new GameObject("BgmPlayer");
        bgmObject.transform.parent = transform;
        bgmPlayer = bgmObject.AddComponent<AudioSource>();
        bgmPlayer.playOnAwake = false;
        bgmPlayer.loop = true;
        bgmPlayer.volume = bgmVolume;
        bgmPlayer.clip = bgmClip;
        bgmEffect = Camera.main.GetComponent<AudioHighPassFilter>();

        GameObject sfxObject = new GameObject("sfxPlayer");
        sfxObject.transform.parent = transform;
        sfxPlayers = new AudioSource[channels];

        for(int i = 0; i < sfxPlayers.Length; i++)
        {
            sfxPlayers[i] = sfxObject.AddComponent<AudioSource>();
            sfxPlayers[i].playOnAwake = false;
            sfxPlayers[i].bypassListenerEffects = true;
            sfxPlayers[i].volume = sfxVolume;
        }

        bgmPlayer.Play();
    }
    public void OnOff(bool isplay)
    {
        if(isplay)
        {
            if(!bgmPlayer.isPlaying)
            {
                bgmPlayer.Play();
            }
        }
        else
        {
            if(bgmPlayer.isPlaying)
            {
                bgmPlayer.Stop();
            }
        }
    }
    public void PlaySfx(sfx sfx)
    {
        for(int i = 0; i < sfxPlayers.Length; i++)
        {
            int loopIndex = (i + channelIndex) % sfxPlayers.Length;

            if (sfxPlayers[loopIndex].isPlaying)
            {
                continue;
            }
            int ranI = 0;

            channelIndex = loopIndex;
            sfxPlayers[loopIndex].clip = sfxClips[(int)sfx + ranI];
            sfxPlayers[loopIndex].Play();
            break;
        }
    }
}
