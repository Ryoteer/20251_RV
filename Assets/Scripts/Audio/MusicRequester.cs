using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicRequester : MonoBehaviour
{
    [Header("Audio")]
    [SerializeField] private AudioClip _musicToPlay;

    private void Start()
    {
        AudioManager.Instance.PlayMusicClip(_musicToPlay);
    }
}
