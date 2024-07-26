using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

//Use of a ScriptableObject for a audio manager instead of a Singleton, gets placed inside the Resources folder where an instance is initialised.

[CreateAssetMenu(fileName = "Audio", menuName = "Add SO/Audio/Audio Manager")]

public class Audio : ScriptableObject
{
    private static Audio _instance;
   
    public static Audio Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = Resources.Load<Audio>("AudioManager");
            }
            return _instance;
        }
    }
        
    public enum SfxName
    {
        Walk,
        Die,
        Attack1,
        Attack2,
        Attack3,
        Attack4,
        UIButton
    }

    [Header("AUDIO MIXER")]
    [SerializeField] AudioMixer _audioMixer;
    [Range(-80f, 0f)]
    [SerializeField] float _masterVolume;
    [Range(-80f, 0f)]
    [SerializeField] float _effectsVolume;
    [Range(-80, 0f)]
    [SerializeField] float _musicVolume;
    [SerializeField] private AudioMixerGroup _mixerSFX;
    [SerializeField] private AudioMixerGroup _mixerMusic;

    [Header("AUDIO SOURCES")]
    [SerializeField] AudioSource _audioSource;

    [Header("SFX CLIPS")]
    public SO_AudioClips SfxClips;
    public Dictionary<SfxName, AudioClip> Clips = new Dictionary<SfxName, AudioClip>();

    private void OnEnable()
    {
        //Add sfx to dictionary
        foreach (SfxClip clip in SfxClips.AudioClips)
        {
            Clips.Add(clip.Name, clip.Clip);
        }
    }

    public float MasterVolume
    {
        get => _masterVolume;
        set
        {
            _masterVolume = value;
            if (_masterVolume <= -50) { _masterVolume = -80; }
            _audioMixer.SetFloat("Master Volume", _masterVolume);
        }
    }
    public float EffectsVolume
    {
        get => _effectsVolume;
        set
        {
            _effectsVolume = value;
            if (_effectsVolume <= -50) { _effectsVolume = -80; }
            _audioMixer.SetFloat("Effects Volume", _effectsVolume);
        }
    }
    public float MusicVolume
    {
        get => _musicVolume;
        set
        {
            _musicVolume = value;
            if (_musicVolume <= -50) { _musicVolume = -80; }
            _audioMixer.SetFloat("Music Volume", _musicVolume);
        }
    }

    //Position parameter can be passed for 3D sound positioning
    public void PlaySfx(SfxName clipName, Vector3 position = default, bool loop = default, float delay = default)
    {
        AudioClip audioClip;
        if (Clips.TryGetValue(clipName, out audioClip))
        {
            AudioSource audioSource = Instantiate(Instance._audioSource, position, Quaternion.identity); // Ideally a audio pool should be used for the AdioSource
            audioSource.outputAudioMixerGroup = _mixerSFX;
            audioSource.clip = audioClip;
            audioSource.loop = loop;
            audioSource.PlayDelayed(delay);
            Debug.Log("Played " + clipName + " sound");
        }
    }  
}
