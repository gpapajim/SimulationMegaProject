using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmSD : MonoBehaviour
{
    public ScreenManagerSD screen;
    public ModeManagerSD mode;

    public bool alarmStart;
    public bool alarmDown;

    public float gasTimer;

    public void Start()
    {
        gasTimer = 1.2f;
    }

    public void Update()
    {
        if (alarmStart || alarmDown)
        {
            gasTimer -= Time.deltaTime;
        }

        if (gasTimer < 0 && alarmStart)
        {
            screen.C4H10.Value += Random.Range(10, 35.5f);
            gasTimer = 1.2f;
        }

        if (gasTimer < 0 && alarmDown)
        {
            screen.C4H10.Value -= Random.Range(10, 35.5f);
            gasTimer = 1.2f;
        }

        if (!alarmStart && !alarmDown)
        {
            gasTimer = 1.2f;
        }

        if (screen.C4H10.Value > 300 && mode.normalMode)
        {
            screen.lights.AlarmLightOn();
        }

        if (screen.C4H10.Value > 400 && mode.normalMode)
        {
            alarmStart = false;
        }

        if (screen.C4H10.Value < 300 && mode.normalMode)
        {
            screen.lights.AlarmLightOff();
        }

        if (alarmDown && screen.C4H10.Value < 50)
        {
            alarmDown = false;
            screen.C4H10.Value = 0;
        }
    }

    public void AlarmStart()
    {
        if (mode.normalMode)
        {
            alarmStart = true;
        }
    }

    public void AlarmDown()
    {
        if (screen.C4H10.Value > 300 && mode.normalMode)
        {
            alarmDown = true;
            alarmStart = false;
        }
    }
}
