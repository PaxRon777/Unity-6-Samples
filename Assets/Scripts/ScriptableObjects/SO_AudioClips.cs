using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AudioClips", menuName = "Add SO/Audio/Audio Clips")]

public class SO_AudioClips : ScriptableObject
{
    [Header("ALL AUDIO CLIPS")]
    public List<SfxClip> AudioClips = new List<SfxClip>();
}

