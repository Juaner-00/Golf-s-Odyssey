using UnityEngine.Audio;
using UnityEngine;
using System;
using DG.Tweening;

public class AudioManager : MonoBehaviour
{

    [SerializeField]
    float finalValueFadeIn;
    [SerializeField]
    float durationFadeIn;

    [SerializeField]
    float finalValueFadeOut;
    [SerializeField]
    float durationFadeOut;

    public Sound[] sounds;

    public static AudioManager instance;

    


    private void Awake()
    {

        if (instance == null)
            instance = this;
        else 
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            
        }

    }
/*
    private void Start()
    {
        Play("Win");
    }*/

    public void Play(string name)
    {
       Sound s =  Array.Find(sounds, sound => sound.nombre == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found");
            return;
        }
            
        s.source.Play();
    }

    public void PlayFade(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.nombre == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found");
            return;
        }

        s.source.Play();
        s.source.DOFade(finalValueFadeIn, durationFadeIn);
    }

    public void FadeIn(string audio)
    {
        PlayFade(audio);              
        
    }

    public void ContinuePlaying(string audio)
    {
        Sound s = Array.Find(sounds, sound => sound.nombre == audio);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found");
            return;
        }

        s.source.DOFade(finalValueFadeIn, durationFadeIn);

    }

    public void FadeOut(string audio)
    {
        Sound s = Array.Find(sounds, sound => sound.nombre == audio);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found");
            return;
        }

        s.source.DOFade(finalValueFadeOut, durationFadeOut);
    }

    public void Stop()
    {
        foreach (Sound s in sounds)
        {
            s.source.Stop();
        }
    
    }

}
