using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartingSq8000 : MonoBehaviour
{
    public  ScreenManager8000 screenManager;
    public DeviceState8000 deviceState;
    [Space]
    [Header("CHECKS")]
    public bool lights;
    public bool timeDate;
    public bool batteryVolt;
    public bool info;
    public bool fullScale;
    public bool warning;
    public bool alarm;
    public bool stel;
    public bool twa;
    public bool oned;
    public bool beepPlayed;
    [Space]
    [Header("TIMERS")]
    public float startingScreenTimer;
    public float lightsTimer;
    public float timeDateTimer;
    public float infoTimer;
    public float batteryVoltTimer;
    public float fullScaleTimer;
    public float warningTimer;
    public float alarmTimer;
    public float stelTimer;
    public float twaTimer;
    public float onedtimer;
    public float beepTimer;
    public void Awake()
    {
        startingScreenTimer = 3f;
        lightsTimer = 1.5f;
        timeDateTimer = 1.3f;
        infoTimer = 1.3f;
        batteryVoltTimer = 1.3f;
        fullScaleTimer = 1.3f;
        warningTimer = 1.3f;
        alarmTimer = 1.3f;
        stelTimer = 1.3f;
        twaTimer = 1.3f;
        onedtimer = 1.5f;
        beepTimer = 0.5f;
    }
    public void Update()
    {
        if( deviceState.startingSq == true)//open screen
        {
            startingScreenTimer -= Time.deltaTime;
            StartingScreenOn();
        }
        if(startingScreenTimer<0)//close
        {
            timeDate = true;
        }

        if(startingScreenTimer<2)//open lights
        {
            lightsTimer -= Time.deltaTime;
            screenManager.alarmLights.GetComponent<Lights_Manager8000>().LightsOn();
        }
        if(lightsTimer<0)//close
        {
            screenManager.alarmLights.GetComponent<Lights_Manager8000>().LightsOff();
        }

        if (timeDateTimer>0.5 && timeDateTimer<0.7)
        {
            deviceState.PumpSound();
        }

        if(timeDate==true)//open time-date
        {
            PropOn();
            HeartOn();
            timeDateTimer -= Time.deltaTime;
            StartingScreenOff();
            DateOn();
            TimeOn();
            BatteryOn();
        }
        if(timeDateTimer<0)//close
        {
            timeDate = false;
            batteryVolt = true;
        }

        if(batteryVolt==true)//open battery volt
        {
            batteryVoltTimer -= Time.deltaTime;
            DateOff();
            TimeOff();
            BatteryVoltOn();
            ScreenMessage(true, "BATT.");
            MenuMessage(true, "AL -- H");
        }
        if(batteryVoltTimer<0)//close
        {
            batteryVolt = false;
            info=true;
        }

        if (info==true)
        {
            infoTimer -= Time.deltaTime;
            ScreenMessage(false, "");
            BatteryVoltOff();
            MenuMessage(true, "--- CH4 10");
            infoOn();
        }

        if (infoTimer<0)
        {
            info = false;
            fullScale = true;
        }


        if(fullScale==true)//open fulscale
        {
            fullScaleTimer -= Time.deltaTime;
            infoOff();
            MenuMessage(true, "F.S");
            GasNames(true, true, true, true);
            GasNumbers(true, true, true, true, 100, 40.0f, 500, 100.0f); ;
        }
        if(fullScaleTimer<0)//close
        {
            fullScale = false;
            warning = true;
        }

        if(warning==true)//open warning
        {
            warningTimer -= Time.deltaTime;
            MenuMessage(true, "WARNING");
            GasNames(true, true, true, true);
            GasNumbers(true, true, true, true, 10, 19.5f, 25, 10.0f);
        }
        if(warningTimer<0)//close
        {
            warning = false;
            alarm = true;
        }

        if(alarm==true)//open alarm 
        {
            alarmTimer -= Time.deltaTime;
            MenuMessage(true, "ALARM");
            GasNames(true, true, true, true);
            GasNumbers(true, true, true, true, 50, 23.5f, 50, 30.0f);
        }
        if(alarmTimer<0)
        {
            alarm = false;
            stel = true;
        }

        if(stel==true)//open stel
        {
            stelTimer -= Time.deltaTime;
            MenuMessage(true, "STEL");
            GasNames(false, false, true, true);
            GasNumbers(false, false, true, true, 0, 0, 200, 15.0f);
        }
        if(stelTimer<0)//close
        {
            stel = false;
            twa = true;
        }

        if(twa==true)//open twa
        {
            twaTimer -= Time.deltaTime;
            MenuMessage(true, "TWA");
            GasNames(false, false, true, true);
            GasNumbers(false, false, true, true, 0, 0, 25, 10.0f);
        }
        if (twaTimer<0)
        {
            twa = false;
            oned = true;
        }
        if (oned==true)
        {
            onedtimer -= Time.deltaTime;
            MenuMessage(true, "-- -- -- -- -- -- --");
            oneDScreenOn();
            GasNames(false, false, false, false);
            GasNumbers(false, false, false, false, 0, 0, 0, 0);
        }

      
        if(onedtimer<0)//close
        {   
            oned = false;
            deviceState.startingSq = false;
            deviceState.normalMode = true;
            oneDScreenOff();
            ButtonSound();
            GasNumbers(true, true, true, true, 0, 20.9f, 0, 0);//put here so warning and alarm can freally change the numbers
        }

        if (deviceState.normalMode &! beepPlayed)
        {
            beepTimer -= Time.deltaTime;
        }

        if (deviceState.normalMode == true && deviceState.warning==false && deviceState.alarm==false && deviceState.airClean==false && deviceState.menu==false)//open normal screen
        {
            TimeOn();
            MenuMessage(false,"");
            GasNames(true, true, true, true);


            //reseting all timers;
            ResetTimers();
            
        }

        if(deviceState.on==false)//closing the device
        {
            beepPlayed = false;
            TimeOff();
            MenuMessage(false, "0");
            GasNames(false, false, false, false);
            GasNumbers(false, false, false, false, 0, 0, 0, 0);
            BatteryOff();
        }

       
    }

    public void FixedUpdate()
    {
        if (beepTimer<0)
        {
            ButtonSound();
            beepPlayed = true;
            beepTimer = 0.5f;
        }
    }

    public void StartingScreenOn()
    {
        screenManager.startingScreen.SetActive(true);
    }
    public void StartingScreenOff()
    {
        screenManager.startingScreen.SetActive(false);
        
    }
    public void DateOn()
    {
        screenManager.date.SetActive(true);
    }
    public void DateOff()
    {
        screenManager.date.SetActive(false);
    }
    public void TimeOn()
    {
        screenManager.time.SetActive(true);
    }
    public void TimeOff()
    {
        screenManager.time.SetActive(false);
    }
    public void BatteryOn()
    {
        screenManager.batteryImg.SetActive(true);
    }
    public void BatteryOff()
    {
        screenManager.batteryImg.SetActive(false);
    }
    public void BatteryVoltOn()
    {
        screenManager.batteryVolt.SetActive(true);
    }
    public void BatteryVoltOff()
    {
        screenManager.batteryVolt.SetActive(false);
    }
    public void ScreenMessage(bool onOff,string content)
    {
        if(onOff==true)
        {
            screenManager.ScreenMessage.SetActive(true);
        }
        else
        {
            screenManager.ScreenMessage.SetActive(false);
        }

        screenManager.ScreenMessage.GetComponent<TextMeshProUGUI>().text = content;
    }
    public void MenuMessage(bool onOff,string content)
    {
        if(onOff == true)
        {
            screenManager.menuMessage.SetActive(true);
        }
        else
        {
            screenManager.menuMessage.SetActive(false);
        }

        screenManager.menuMessage.GetComponent<TextMeshProUGUI>().text = content;
    }
    public void GasNames(bool ch4,bool o2,bool co,bool h2s)
    {
        if(ch4==true)
        {
            screenManager.gasNames.transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            screenManager.gasNames.transform.GetChild(0).gameObject.SetActive(false);
        }

        if(o2==true)
        {
            screenManager.gasNames.transform.GetChild(1).gameObject.SetActive(true);
        }
        else
        {
            screenManager.gasNames.transform.GetChild(1).gameObject.SetActive(false);
        }

        if(co==true)
        {
            screenManager.gasNames.transform.GetChild(2).gameObject.SetActive(true);
        }
        else
        {
            screenManager.gasNames.transform.GetChild(2).gameObject.SetActive(false);
        }

        if(h2s==true)
        {
            screenManager.gasNames.transform.GetChild(3).gameObject.SetActive(true);
        }
        else
        {
            screenManager.gasNames.transform.GetChild(3).gameObject.SetActive(false);
        }
    }
    public void GasNumbers(bool ch4,bool o2,bool co,bool h2s,float ch4c,float o2c,float coc,float h2sc)
    {
        if (ch4 == true)
        {
            screenManager.gasNumbers.transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            screenManager.gasNumbers.transform.GetChild(0).gameObject.SetActive(false);
        }

        if (o2 == true)
        {
            screenManager.gasNumbers.transform.GetChild(1).gameObject.SetActive(true);
        }
        else
        {
            screenManager.gasNumbers.transform.GetChild(1).gameObject.SetActive(false);
        }

        if (co == true)
        {
            screenManager.gasNumbers.transform.GetChild(2).gameObject.SetActive(true);
        }
        else
        {
            screenManager.gasNumbers.transform.GetChild(2).gameObject.SetActive(false);
        }

        if (h2s == true)
        {
            screenManager.gasNumbers.transform.GetChild(3).gameObject.SetActive(true);
        }
        else
        {
            screenManager.gasNumbers.transform.GetChild(3).gameObject.SetActive(false);
        }

        screenManager.hc.Value = ch4c;
        screenManager.o2.Value = o2c;
        screenManager.co.Value = coc;
        screenManager.h2s.Value = h2sc;
    }
    public void MetersOn()
    {
        screenManager.meters.SetActive(true);
    }
    public void MetersOff()
    {
        screenManager.meters.SetActive(false);
    }
    public void HeartOn()
    {
        screenManager.heart.SetActive(true);
    }
    public void heartOff()
    {
        screenManager.heart.SetActive(false);
    }
    public void PropOn()
    {
        screenManager.propeler.SetActive(true);
    }
    public void PropOff()
    {
        screenManager.propeler.SetActive(false);
    }
    public void infoOn()
    {
        screenManager.infoScreen.SetActive(true);
    }
    public void infoOff()
    {
        screenManager.infoScreen.SetActive(false);
    }
    public void oneDScreenOn()
    {
        screenManager.oneDScreen.SetActive(true);
    }
    public void oneDScreenOff()
    {
        screenManager.oneDScreen.SetActive(false);
    }
    public void ResetTimers()
    {
        startingScreenTimer = 3f;
        lightsTimer = 1.5f;
        timeDateTimer = 1.3f;
        batteryVoltTimer = 1.3f;
        fullScaleTimer = 1.3f;
        warningTimer = 1.3f;
        alarmTimer = 1.3f;
        stelTimer = 1.3f;
        twaTimer = 1.3f;
        infoTimer = 1.3f;
        onedtimer = 1.3f;
        
    }

    public void ButtonSound()
    {
        FindObjectOfType<AudioManager8000>().Play("Beep");
    }
}
