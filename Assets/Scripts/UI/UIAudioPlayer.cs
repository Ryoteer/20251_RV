using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAudioPlayer : MonoBehaviour
{
    private AudioSource _source;

    private void Awake()
    {
        _source = GetComponent<AudioSource>();
    }

    public void PlayAudioClip(AudioClip clip)
    {
        if (_source.isPlaying)
        {
            _source.Stop();
        }

        _source.clip = clip;

        _source.Play();
    }
}
