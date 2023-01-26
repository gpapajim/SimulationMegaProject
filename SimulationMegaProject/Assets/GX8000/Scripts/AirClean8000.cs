using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirClean8000 : MonoBehaviour
{
    public ScreenManager8000 screenManager;
    public StartingSq8000 startingSq;
    public ButtonManager8000 buttonManager;
    //public CalibrationMenu calibration;
    public DeviceState8000 deviceState;
    public Warning8000 warningAlarm;
    public Lights_Manager8000 lightsManager;

    [Header("timers")]
    public float airCalTimer;
    public float adjHoldTimer;
    public float releaseTimer;
    public float waitTimer;
    public float endTimer;
    public float countdownTimer;

    [Header("checks")]
    public bool adjHold;
    public bool release;
    public bool airCleanDone;
    public bool end;
    public bool countdown;
    


    public void Awake()
    {
        airCalTimer = 0.5f; 
        adjHoldTimer = 2f;
        releaseTimer = 2;
        waitTimer = 1f;
        endTimer = 1.5f;
        countdownTimer = 1f;
        screenManager.countdownNumber.Value = 30f;
    }

    public void Update()
    {
        if ((buttonManager.A == true && deviceState.normalMode == true && deviceState.menu == false) || (deviceState.airCal==true && buttonManager.A == true))
        {
            airCalTimer -= Time.deltaTime;
        }
        if (buttonManager.A == false && deviceState.normalMode == true && deviceState.menu == false)
        {
            airCalTimer = 0.5f;
        }
        if (airCalTimer<0)
        {
            AirCal();
        }

        if(buttonManager.A==true && deviceState.airClean == true)
        {
            airCalTimer = 0.5f;
            adjHoldTimer -= Time.deltaTime;
        }
        if(adjHoldTimer<0)
        {
            AirCal();
        }

        if(adjHold==true && deviceState.airClean==true)
        {
            adjHoldTimer = 2;
            releaseTimer -= Time.deltaTime;
        }
        if(releaseTimer<0)
        {
            AirCal();
        }

        if(release==true)
        {
            releaseTimer = 2;
            countdown = true;
        }
        if (end == true && release==false)
        {
            endTimer -= Time.deltaTime;
        }

        if (waitTimer<0)
        {
            AirCal();
        }

        if (countdown)
        {
            countdownTimer -= Time.deltaTime;
        }

        if(countdownTimer<0)
        {
            screenManager.countdownNumber.Value -= 1;
            countdownTimer = 1f;
        }
        if (countdown)
        {

            screenManager.countdown.SetActive(true);
        }

        if (screenManager.countdownNumber.Value==0)
        {
            end = true;
        }
        if (end)
        {
            endTimer -= Time.deltaTime;
            startingSq.ScreenMessage(false, "");
            startingSq.MenuMessage(true, " END");
            screenManager.countdown.SetActive(false);
            
        }

        if (end == true && endTimer < 0 )
        {
            countdown = false;
            
            end = false;
            startingSq.BatteryOn();
            
            startingSq.MenuMessage(false, "");
            startingSq.GasNumbers(true, true, true, true, screenManager.hc.Value, 0.2f, screenManager.co.Value, screenManager.h2s.Value);
            startingSq.GasNames(true, true, true, true);

            screenManager.hc.Value = 0;
            screenManager.o2.Value = 20.9f;
            screenManager.hc.Value = 0;
            screenManager.hc.Value = 0;
            screenManager.countdownNumber.Value = 30;
            countdownTimer = 1f;//

            deviceState.alarm = false;
            deviceState.warning = false;
            warningAlarm.alarmStart = false;
            warningAlarm.warningStart = false;
            lightsManager.timeSelected = false;
            lightsManager.LightsOff();

            deviceState.airClean = false;

            waitTimer = 1f;
            deviceState.airClean = false;
            adjHold = false;
            release = false;
            airCleanDone = false;
            deviceState.noMode = false;
            endTimer = 1.5f;

            deviceState.inMode = false;//

            ButtonSound();

            if (!deviceState.menu)//
            {
                deviceState.normalMode = true;
            }
        }
    }

    public void AirCal()
    {
        if(deviceState.airClean==false)
        {
            screenManager.bars.SetActive(false);
            deviceState.airCal = false;
            deviceState.airClean = true;
            deviceState.warning = false;
            deviceState.alarm = false;
            startingSq.TimeOff();
            startingSq.MenuMessage(true, "HOLD AIR");
            startingSq.ScreenMessage(true, "AIR CAL");
            startingSq.GasNumbers(false, false, false, false, 0, 0, 0, 0);
            startingSq.GasNames(false, false, false, false);
        }
        if(deviceState.airClean==true && adjHold==false && adjHoldTimer<0)
        {
            adjHold = true;
            startingSq.ScreenMessage(true, "ADJ");


            deviceState.alarm = false;
            deviceState.warning = false;
            warningAlarm.alarmStart = false;
            warningAlarm.warningStart = false;
            lightsManager.timeSelected = false;
            lightsManager.LightsOff();
            warningAlarm.WarningSoundStop();
            warningAlarm.AlarmSoundStop();

        }
        if(adjHold==true && releaseTimer<0)
        {
            release = true;
            startingSq.MenuMessage(true, "RELEASE");
            countdown = true;
        }




        /*if(release==true &&  deviceState.menu==true)
        {
            release = false;
            end = true;
            startingSq.ScreenMessage(false, "");
            startingSq.MenuMessage(true, " END");
        }

        if (countdown)
        {
            
            screenManager.countdown.SetActive(true);
        }

        if(end==true && endTimer<0  && waitTimer<0)
        {
            end = false;
            deviceState.normalMode = true;
        }
        
        if(release == true && waitTimer < 0 &! end==true)
        {
            //oti xreiazetai katharisma
            startingSq.GasNumbers(true, true, true, true, 0, 20.9f, 0, 0);
            startingSq.MenuMessage(true, "");
            startingSq.ScreenMessage(true, "");
            ////////////////////////////

            
            airCleanDone = true;
            release = false;
        }
        if(airCleanDone==true)
        {
            waitTimer = 1f;
            deviceState.airClean = false;
            adjHold = false;
            release = false;
            airCleanDone = false;
            deviceState.noMode = false;
            endTimer = 1.5f;
        }*/


        
    }

    public void ButtonSound()
    {
        FindObjectOfType<AudioManager8000>().Play("Beep");
    }
}
