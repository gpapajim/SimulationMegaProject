using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DeviceState8000 : MonoBehaviour
{
    public ButtonManager8000 buttonManager;
    public ScreenManager8000 screenManager;

    public bool on;
    public bool startingSq;
    public bool normalMode;
    public bool warning;
    public bool alarm;
    public bool airClean;
    public bool menu;
    public bool pump;
    public bool noMode;
    public bool inMode;
    public bool airCal;
    public bool volZCal;
    public bool oneCal;
    public bool autoCal;
    public bool inSettings;

    public float pumpTimer;
    public float onTimer;
    public float offTimer;


    public void Awake()
    {
        pumpTimer = 0.5f;
        onTimer = 2f;
        offTimer = 3f;
    }


    public void Update()
    {
        if (buttonManager.P && !on &! inSettings)
        {
            onTimer -= Time.deltaTime;
        }
        else
        {
            onTimer = 2f;
        }

        if (buttonManager.P && on && !startingSq &! inSettings)
        {
            offTimer -= Time.deltaTime;
        }
        else
        {
            offTimer = 3f;
        }


        if(onTimer<0)
        {
            PowerOn();
        }
        if(offTimer<0)
        {
            PowerOff();
        }

        if (pump)
        {
            pumpTimer -= Time.deltaTime;
            
        }
        if (pumpTimer<0)
        {
            PumpSound();
            pumpTimer = 13f;
        }
        
        if (!pump)
        {
            PumpSoundOff();
            pumpTimer = 13f;
        }

    }

    public void PowerOn()
    {
        
        screenManager.backScreen.SetActive(true);
        screenManager.screen.SetActive(true);
        this.gameObject.GetComponent<ButtonManager8000>().ButtonSound();
        on = true;
        startingSq = true;
        onTimer = 2;
    }

    public void PowerOff()
    {
        screenManager.backScreen.SetActive(false);
        screenManager.screen.SetActive(false);
        this.gameObject.GetComponent<ButtonManager8000>().ButtonSound();
        on = false;
        normalMode = false;
        offTimer = 3;
    }

    public void PumpSound()
    {
        pump = true;
        FindObjectOfType<AudioManager8000>().Play("Pump");
    }

    public void PumpSoundOff()
    {
        pump = false;
        FindObjectOfType<AudioManager8000>().Stop("Pump");
    }
}
