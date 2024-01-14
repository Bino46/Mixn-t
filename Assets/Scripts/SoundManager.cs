using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class SoundManager : MonoBehaviour
{
    [SerializeField] List<AudioClip> SFXList = new List<AudioClip>();
    [SerializeField] List<AudioSource> chaudronSources = new List<AudioSource>();
    [SerializeField] List<AudioSource> rockSources = new List<AudioSource>();
    [SerializeField] List<AudioSource> otherSources = new List<AudioSource>();
    public static SoundManager _instance;

    private void Awake()
    {
        if (_instance == null)
            _instance = this;
    }

    public void PlayChaudronSound(int index)
    {
        for (int i = 0; i < chaudronSources.Count; i++)
        {
            if (!chaudronSources[i].isPlaying)
            {
                chaudronSources[i].clip = SFXList[index];
                chaudronSources[i].Play();
            }
        }
    }

    public void PlayRockSound(int index)
    {
        for (int i = 0; i < rockSources.Count; i++)
        {
            if (!rockSources[i].isPlaying)
            {
                rockSources[i].clip = SFXList[index];
                rockSources[i].Play();
            }
        }
    }

    public void PlayOtherSource(int indexSFX, int indexSource)
    {
        otherSources[indexSource].clip = SFXList[indexSFX];
        otherSources[indexSource].Play();
    }
}
