using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Warning8000 : MonoBehaviour
{
    public ScreenManager8000 screenManager;
    public StartingSq8000 startingSq;
    public DeviceState8000 onOff;

    [Header("Gas Numbers")]
    public float ch4;
    public float o2;
    public float co;
    public float h2s;
    [Header("gas selectors")]
    public int gasSelector;
    public int o2UpDown;
    [Header("gasIncTimer")]
    public float gasInc;
    [Header("checks")]
    public bool warningStart;
    public bool alarmStart;
    [Header("sound timers")]
    public float warningTimer;
    public float alarmTimer;


    public void Awake()
    {
        gasInc = 1.5f;
        warningTimer = 7;
        alarmTimer = 3.5f;
    }
    public void Update()
    {
        //updating the gas numbers
        if(onOff.warning==false && onOff.alarm==false)
        {
            ch4 = screenManager.hc.Value;
            o2 = screenManager.o2.Value;
            co = screenManager.co.Value;
            h2s = screenManager.h2s.Value;
        }
        //////////////////////////

        //updating screen
        if(onOff.warning==true || onOff.alarm==true)
        {
            startingSq.GasNumbers(true, true, true, true, ch4, o2, co, h2s);
        }
        
        
        if(onOff.warning==true || onOff.alarm==true)
        {
            gasInc -= Time.deltaTime;
        }
        if(gasInc<0)
        {
            GasManager(gasSelector,o2UpDown);
            gasInc = 1.5f;
        }

        if(warningStart==true)
        {
            warningTimer -= Time.deltaTime;
        }
        if(warningTimer<0)
        {
            WarningSound();
            warningTimer = 7;
        }

        if(alarmStart==true)
        {
            alarmTimer -= Time.deltaTime;
        }
        if(alarmTimer<0)
        {
            AlarmSound();
            alarmTimer = 3.5f;
        }
        
    }
    public void WarningPress()
    {
       if(onOff.normalMode==true && onOff.alarm==false)
       {
            onOff.warning = true;
            gasSelector = Random.Range(0, 4);
            o2UpDown = Random.Range(0, 2);
       }
    }

    public void AlarmPress()
    {
        if(onOff.normalMode==true && onOff.warning==false)
        {
            onOff.alarm = true;
            gasSelector = Random.Range(0, 4);
            o2UpDown = Random.Range(0, 2);
        }
    }

    public void GasManager(int gasSelection, int o2sel)
    {
        if((ch4<13 && o2<22.5f && o2>19f  && co<28 && h2s<12 && onOff.warning==true) ||
           (ch4 < 52 && o2 < 25.5f && o2 > 17.5 && co < 53 && h2s < 32 && onOff.alarm==true))
        {
            if (gasSelection == 0)
            {
                ch4 += Random.Range(1, 3);
            }
            if (gasSelection == 1)
            {
                if (o2sel == 0)
                {
                    o2 += Random.Range(0.1f, 0.3f);
                }
                if (o2sel == 1)
                {
                    o2 -= Random.Range(0.1f, 0.3f);
                }
            }
            if (gasSelection == 2)
            {
                co += Random.Range(1, 3);
            }
            if (gasSelection == 3)
            {
                h2s += Random.Range(1, 3);
            }
        }

        

        if((ch4>10 || o2>22.0f || o2<19.5f || co>25 || h2s>10) && alarmStart==false)
        {
            screenManager.alarmLights.GetComponent<Lights_Manager8000>().timeSelected = true;
            screenManager.alarmLights.GetComponent<Lights_Manager8000>().TimerSelector(0.7f);
            startingSq.MenuMessage(true, "WARNING");
            if(warningStart==false)
            {
                WarningSound();
                warningStart = true;
            }
            
        }
        if(ch4>50 || o2>23.5f || o2<18.5 || co>50 || h2s>30)
        {
            screenManager.alarmLights.GetComponent<Lights_Manager8000>().timeSelected = true;
            screenManager.alarmLights.GetComponent<Lights_Manager8000>().TimerSelector(0.35f);
            startingSq.MenuMessage(true, "ALARM");
            WarningSoundStop();
            warningStart = false;
            if(alarmStart==false)
            {
                AlarmSound();
                alarmStart = true;
            }
            
        }
    }

    public void WarningSound()
    {
        FindObjectOfType<AudioManager8000>().Play("Warning");
    }
    public void WarningSoundStop()
    {
        FindObjectOfType<AudioManager8000>().Pause("Warning");
    }

    public void AlarmSound()
    {
        FindObjectOfType<AudioManager8000>().Play("Alarm");
    }
    public void AlarmSoundStop()
    {
        FindObjectOfType<AudioManager8000>().Pause("Alarm");
    }
}
