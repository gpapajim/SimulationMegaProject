using UnityEngine.Audio;
using UnityEngine;

/// <summary>
/// class that creates a sound
/// </summary>

[System.Serializable]
public class Sound 
{
    public string name;
    public AudioClip clip;


    public bool mute;
    [Range(0,1)]
    public float volume;
    [Range(0.1f, 3)]
    public float pitch;
    public bool loop;


    [HideInInspector]
    public AudioSource source;
}
