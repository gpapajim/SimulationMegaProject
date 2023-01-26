﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    private void Awake()//maybe a bug here/ awake here and poweronof didnt work/ now gives same error but works
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.loop = s.loop;
            s.source.mute = s.mute;
        }
    }
    //play hxo
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)//blockarei to error se periptwsh lathos name
        {
            return;
        }
        s.source.Play();
    }
    //pause hxo
    public void Pause(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
       if (s==null)
       {
            return;
       }
        s.source.Pause();
    }
   
}
