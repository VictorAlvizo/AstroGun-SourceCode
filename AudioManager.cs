using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour {

    public static AudioManager Instance = null;

    [System.Serializable]
    public class SoundClips
    {
        public AudioClip clip;
        public string name;

        [Range(0, 1)]
        public float volume;
        [Range(0, 3)]
        public float pitch;

        public bool loop;

        [HideInInspector]
        public float maxVolume;

        [HideInInspector]
        public AudioSource soundSource;
    }

    public SoundClips[] sound;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        foreach(SoundClips initiate in sound)
        {
            initiate.soundSource = gameObject.AddComponent<AudioSource>();
            initiate.soundSource.clip = initiate.clip;
            initiate.soundSource.loop = initiate.loop;

            initiate.soundSource.volume = initiate.volume;
            initiate.maxVolume = initiate.volume;
            initiate.soundSource.pitch = initiate.pitch;
        }
    }

    void Start()
    {
        PlaySound("Theme");
    }

    public void PlaySound(string audioName)
    {
        foreach(SoundClips search in sound)
        {
            if(search.name == audioName)
            {
                search.soundSource.Play();
                break;
            }
        }
    }

    public void ChangeVolume(float volumeValue)
    {
        foreach(SoundClips adjustSound in sound)
        {
            if(volumeValue < adjustSound.maxVolume && volumeValue != adjustSound.soundSource.volume)
            {
                adjustSound.soundSource.volume = volumeValue;
            }
        }
    }

    public void MuteSound(int option)
    {
        foreach(SoundClips muteSound in sound)
        {
            if(option == 1)
            {
                muteSound.soundSource.mute = true;
            }
            else
            {
                muteSound.soundSource.mute = false;
            }
        }
    }
}
