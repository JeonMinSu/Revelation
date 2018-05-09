using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioSound : MonoBehaviour {

    AudioSource audioSource;
    bool isPlay = false;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void SetClip(AudioClip _audioClip)
    {
        audioSource.clip = _audioClip;
    }

    public void Play()
    {
        audioSource.Play();
        isPlay = true;
    }

    public void LoopOn()
    {
        audioSource.loop = true;
    }

    private void Update()
    {
        if(!audioSource.isPlaying && isPlay)
        {
            SoundManager.Instance.AddEmptyAudioSourceObject(this.gameObject);
        }
    }

    public void Reset()
    {
        isPlay = false;
        audioSource.Stop();
        audioSource.loop = false;
    }
}