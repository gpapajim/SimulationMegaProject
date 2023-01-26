using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmSD10X : MonoBehaviour
{
    public ScreenManagerSD10X screen;
    public ModeManagerSD10X mode;

    public bool alarmStart;
    public bool alarmDown;

    public bool gasUp;
    public int selector;

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

        if (gasTimer < 0 && gasUp && !alarmDown)
        {
            screen.C4H10.Value += Random.Range(1.2f, 5.4f);
            gasTimer = 1.2f;
        }

        if (gasTimer < 0 && !gasUp && !alarmDown)
        {
            screen.C4H10.Value -= Random.Range(1.2f, 5.4f);
            gasTimer = 1.2f;
        }

        if (!alarmStart && !alarmDown)
        {
            gasTimer = 1.2f;
        }

        if ((screen.C4H10.Value > 230 || screen.C4H10.Value < 195) && mode.normalMode)
        {
            screen.lights.AlarmLightOn();
        }

        if ((screen.C4H10.Value > 245 || screen.C4H10.Value < 175) && mode.normalMode)
        {
            alarmStart = false;
        }

        if ((screen.C4H10.Value < 230 && screen.C4H10.Value > 195) && mode.normalMode)
        {
            screen.lights.AlarmLightOff();
        }

        if (alarmDown && (screen.C4H10.Value < 210 && screen.C4H10.Value > 200))
        {
            alarmDown = false;
            screen.C4H10.Value = 209;
        }

        if (alarmDown && gasUp && gasTimer < 0)
        {
            screen.C4H10.Value -= Random.Range(1.2f, 5.4f);
            gasTimer = 1.2f;
        }

        if (alarmDown && !gasUp && gasTimer < 0)
        {
            screen.C4H10.Value += Random.Range(1.2f, 5.4f);
            gasTimer = 1.2f;
        }



        /*if (gasTimer < 0 && alarmStart && gasUp)
        {
            screen.C4H10.Value += Random.Range(10, 35.5f);
            gasTimer = 1.2f;
        }

        if (gasTimer < 0 && alarmDown && !gasUp)
        {
            screen.C4H10.Value -= Random.Range(10, 35.5f);
            gasTimer = 1.2f;
        }

        

        if ((screen.C4H10.Value > 230 || screen.C4H10.Value < 195) && mode.normalMode)
        {
            screen.lights.AlarmLightOn();
        }

        if ((screen.C4H10.Value > 300 || screen.C4H10.Value < 150) && mode.normalMode)
        {
            alarmStart = false;
        }

        

       */
    }

    public void AlarmStart()
    {
        selector = Random.Range(0, 2);

        if (selector > 0)
        {
            gasUp = true;
        }

        if (mode.normalMode)
        {
            alarmStart = true;
        }
    }

    public void AlarmDown()
    {
        if ((screen.C4H10.Value > 230 || screen.C4H10.Value <195) && mode.normalMode)
        {
            alarmDown = true;
            alarmStart = false;
        }
    }
}
