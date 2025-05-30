using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    #region Singleton
    public static AudioManager Instance;

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion

    [Header("Audio")]
    [SerializeField] private AudioMixer _mixer;
    [SerializeField] private string _masterGroupName = "Master";
    [Range(0.0001f, 1.0f)][SerializeField] private float _masterGroupInitVal = 0.75f;
    public float MasterGroupInitVal { get { return _masterGroupInitVal; } }
    [SerializeField] private string _musicGroupName = "Music";
    [Range(0.0001f, 1.0f)][SerializeField] private float _musicGroupInitVal = 0.5f;
    public float MusicGroupInitVal { get { return _musicGroupInitVal; } }
    [SerializeField] private string _sfxGroupName = "SFX";
    [Range(0.0001f, 1.0f)][SerializeField] private float _sfxGroupInitVal = 1.0f;
    public float SfxGroupInitVal { get { return _sfxGroupInitVal; } }
    [SerializeField] private string _uiGroupName = "UI";
    [Range(0.0001f, 1.0f)][SerializeField] private float _uiGroupInitVal = 1.0f;
    public float UIGroupInitVal { get { return _uiGroupInitVal; } }

    private AudioSource _musicSource;

    private void Start()
    {
        _musicSource = GetComponent<AudioSource>();

        SetMasterVolume(_masterGroupInitVal);
        SetMusicVolume(_musicGroupInitVal);
        SetSFXVolume(_sfxGroupInitVal);
        SetUIVolume(_uiGroupInitVal);
    }

    public void SetMasterVolume(float value)
    {
        if (value <= 0.0f) { value = 0.0001f; }

        _mixer.SetFloat(_masterGroupName, Mathf.Log10(value) * 20.0f);
    }

    public void SetMusicVolume(float value)
    {
        if (value <= 0.0f) { value = 0.0001f; }

        _mixer.SetFloat(_musicGroupName, Mathf.Log10(value) * 20.0f);
    }

    public void SetSFXVolume(float value)
    {
        if (value <= 0.0f) { value = 0.0001f; }

        _mixer.SetFloat(_sfxGroupName, Mathf.Log10(value) * 20.0f);
    }

    public void SetUIVolume(float value)
    {
        if (value <= 0.0f) { value = 0.0001f; }

        _mixer.SetFloat(_uiGroupName, Mathf.Log10(value) * 20.0f);
    }

    public void PlayMusicClip(AudioClip clip)
    {
        if (_musicSource.isPlaying)
        {
            _musicSource.Stop();
        }

        _musicSource.clip = clip;

        _musicSource.Play();
    }
}
