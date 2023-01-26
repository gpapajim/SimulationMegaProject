using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class AudioManager8000 : MonoBehaviour
{
    public Sound8000[] clips;// needs stuff

    private void Awake()//maybe a bug here/ awake here and poweronof didnt work/ now gives same error but works
    {
        foreach (Sound8000 sound in clips)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume;
            sound.source.loop = sound.loop;
            sound.source.mute = sound.mute;
        }
    }
    //play hxo
    public void Play(string name)
    {
        Sound8000 sound = Array.Find(clips, sound => sound.name == name);
        if (sound == null)//blockarei to error se periptwsh lathos name
        {
            return;
        }
        sound.source.Play();
    }
    //pause hxo
    public void Pause(string name)
    {
        Sound8000 sound = Array.Find(clips, sound => sound.name == name);
        if (sound == null)
        {
            return;
        }
        sound.source.Pause();
    }

    public void Stop(string name)
    {
        Sound8000 sound = Array.Find(clips, sound => sound.name == name);
        if (sound == null)
        {
            return;
        }
        sound.source.Stop();
    }
}
