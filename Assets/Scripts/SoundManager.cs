using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] List<AudioClip> audioClips = new List<AudioClip>();
    [SerializeField] AudioSource[] sourcesList = new AudioSource[6];
    [SerializeField] AudioSource music;
    [SerializeField] List<AudioSource> loopingSource = new List<AudioSource>();
    [SerializeField] AudioClip[] musicList = new AudioClip[2];
    [SerializeField] Toggle sfxToggle;
    [SerializeField] Toggle musicToggle;
    bool indexMusic;
    public bool sfxEnabled
    {
        get
        {
            return PlayerPrefs.GetInt("sfx", 1) == 1 ? true : false;
        }
        set
        {
            PlayerPrefs.SetInt("sfx", value ? 1 : 0);
        }
    }

    public bool musicEnabled
    {
        get
        {
            return PlayerPrefs.GetInt("music", 1) == 1 ? true : false;
        }
        set
        {
            PlayerPrefs.SetInt("music", value ? 1 : 0);
            music.enabled = musicEnabled;
        }
    }
    public static SoundManager _instance;

    [Button]
    void Reset()
    {
        PlayerPrefs.DeleteKey("music");
        PlayerPrefs.DeleteKey("sfx");
    }

    private void Awake()
    {
        if (_instance == null)
            _instance = this;
        else
            Destroy(gameObject);

        music.enabled = musicEnabled;
        sfxToggle.isOn = sfxEnabled;
        musicToggle.isOn = musicEnabled;
    }

    private void Update()
    {
        if (!music.isPlaying && musicEnabled)
        {
            SwitchMusic();
        }
    }

    [Button]
    void SwitchMusic()
    {
        if (indexMusic)
        {
            music.clip = musicList[0];
            indexMusic = false;
        }
        else
        {
            music.clip = musicList[1];
            indexMusic = true;
        }
        music.Play();
    }

    public void PlaySound(int index)
    {
        if (sfxEnabled)
        {
            for (int i = 0; i < sourcesList.Length; i++)
            {
                if (!sourcesList[i].isPlaying)
                {
                    sourcesList[i].clip = audioClips[index];
                    sourcesList[i].Play();
                    break;
                }
            }
        }
    }

    public void PlaySound(int index, bool loop)
    {
        if (sfxEnabled)
        {
            for (int i = 0; i < sourcesList.Length; i++)
            {
                if (!sourcesList[i].isPlaying)
                {
                    sourcesList[i].clip = audioClips[index];
                    sourcesList[i].loop = loop;
                    loopingSource.Add(sourcesList[i]);
                    sourcesList[i].Play();
                    break;
                }
            }
        }
    }

    public int PlaySoundAndIndex(int index, bool loop)
    {
        if (sfxEnabled)
        {
            for (int i = 0; i < sourcesList.Length; i++)
            {
                if (!sourcesList[i].isPlaying)
                {
                    sourcesList[i].clip = audioClips[index];
                    sourcesList[i].loop = loop;
                    loopingSource.Add(sourcesList[i]);
                    sourcesList[i].Play();
                    return i;
                }

            }
        }
        return 0;
    }

    public void PlaySound(int minIndex, int maxIndex)
    {
        if (sfxEnabled)
        {
            for (int i = 0; i < sourcesList.Length; i++)
            {
                if (!sourcesList[i].isPlaying)
                {
                    int rng = Random.Range(minIndex, maxIndex);
                    sourcesList[i].clip = audioClips[rng];
                    sourcesList[i].Play();
                    break;
                }
            }
        }
    }

    public void StopLoop(int index)
    {
        sourcesList[index].loop = false;
        sourcesList[index].Stop();
    }

    public void StopLoop(AudioSource source)
    {
        source.loop = false;
        source.Stop();
    }

    public void StopAllLoop()
    {
        foreach (AudioSource source in sourcesList)
        {
            source.loop = false;
            source.Stop();
        }
    }
}
