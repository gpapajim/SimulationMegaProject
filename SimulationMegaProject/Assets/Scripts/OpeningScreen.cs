using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningScreen : MonoBehaviour
{
    
    public GameObject gasNumbers;
    public GameObject buttonManager;
    public GameObject alarmLightsManager;
    public GameObject extrasScreen;

    [Space]
    public bool startingScreenStart;
    [Space]
    public bool lightsOn;
    public bool lightsOff;
    public bool startScreenPageOff;
    public bool dateTimeScreen;
    public bool batteryScreen;
    public bool fullRangeScreen;
    public bool warningScreen;
    public bool alarmScreen;
    public bool stelScreen;
    public bool twaScreen;
    [Space]
    public bool normalOperation;
    [Space]
    public float lightsOnTimer;
    public float lightsOffTimer;
    public float startScreenPageTimer;
    public float dateTimeTimer;
    public float batteryScreenTimer;
    public float fullRangeScreenTimer;
    public float warningScreenTimer;
    public float alarmScreenTimer;
    public float stelScreenTimer;
    public float twaScreenTimer;

    private void Awake()
    {
        lightsOnTimer = 1;
        lightsOffTimer = 1.5f;
        startScreenPageTimer = 0.5f;
        dateTimeTimer = 1.3f;
        batteryScreenTimer = 1.3f;
        fullRangeScreenTimer = 1.3f;
        warningScreenTimer = 1.3f;
        alarmScreenTimer = 1.3f;
        stelScreenTimer = 1.3f;
        twaScreenTimer = 1.3f;
    }
    public void Update()
    {
        if(startingScreenStart==false&gameObject.GetComponent<PowerOnOff>().deviceOn==true&lightsOn==false&normalOperation==false)//initiate starting screens
        {
            startingScreenStart = true;
            
        }

        /////////////////////////////////////////////////////
        ///TIMERS
        /////////////////////////////////////////////////////
        if(lightsOn==true)//1//sto telos na kanw reset ta timers
        {
            lightsOnTimer -= Time.deltaTime;
        }
        if(lightsOff ==true)//2
        {
            lightsOffTimer -= Time.deltaTime;
        }
        if(startScreenPageOff==true)//3
        {
            startScreenPageTimer -= Time.deltaTime;
        }
        if(dateTimeScreen==true)//4
        {
            dateTimeTimer -= Time.deltaTime;
        }
        if(batteryScreen==true)//5
        {
            batteryScreenTimer -= Time.deltaTime;
        }    
        if(fullRangeScreen==true)//6
        {
            fullRangeScreenTimer -= Time.deltaTime;
        }
        if(warningScreen==true)//7
        {
            warningScreenTimer -= Time.deltaTime;
        }
        if(alarmScreen==true)//8
        {
            alarmScreenTimer -= Time.deltaTime;
        }
        if(stelScreen==true)//9
        {
            stelScreenTimer -= Time.deltaTime;
        }
        if(twaScreen==true)//10
        {
            twaScreenTimer -= Time.deltaTime;
        }
        /////////////////////////////////////////////////////
        ///TIMERS
        /////////////////////////////////////////////////////
        
        /////////////////////////////////////////////////////
        ///STARTSCREENRUN
        /////////////////////////////////////////////////////
            if(startingScreenStart==true)
            {
            extrasScreen.transform.Find("StartScreenPage").gameObject.SetActive(true);//arxikh othoni
            //audioManager.GetComponent<AudioManager>().Play("beep");na ftiaksw function edw gia na mhn mas priksei ta arxidia
            lightsOn = true;

            }
            if (lightsOnTimer < 0)//fwta anavoun//1
            {
                alarmLightsManager.GetComponent<Lights_Manager>().LightsOn();
                lightsOn = false;
                lightsOff = true;
                
            }
            if (lightsOffTimer < 0)//2
            {
                alarmLightsManager.GetComponent<Lights_Manager>().LightsOff();
                lightsOff = false;
                startScreenPageOff = true;
                
            }
            if (startScreenPageTimer < 0)//3
            {
                extrasScreen.transform.Find("StartScreenPage").gameObject.SetActive(false);
                startScreenPageOff = false;
                dateTimeScreen = true;
            }
        if (dateTimeScreen == true)//4
        {

            extrasScreen.GetComponent<TimeDate>().ShowDate();
            extrasScreen.GetComponent<TimeDate>().ShowTime();
            extrasScreen.GetComponent<Battery>().ShowBattery();//battery open
        }
        if (dateTimeScreen==true&dateTimeTimer<0)
        {
            
            extrasScreen.GetComponent<TimeDate>().HideDate();
            extrasScreen.GetComponent<TimeDate>().HideTime();
            dateTimeScreen = false;
            batteryScreen = true;
            
        }
        if(batteryScreen==true)//battery screen//5
        {
            extrasScreen.GetComponent<VoltBattery>().ShowVolt();
            
        }
        if(batteryScreen==true&batteryScreenTimer<0)
        {
            
            extrasScreen.GetComponent<VoltBattery>().HideVolt();
            batteryScreen = false;
            fullRangeScreen = true;
        }
        if(fullRangeScreen==true)//6
        {
            extrasScreen.transform.GetChild(0).gameObject.SetActive(true);
            extrasScreen.GetComponent<FullRnageScreen>().ShowFull();

            gasNumbers.GetComponent<GasNumbers>().GasNumbersUpdate(40 , 100 ,100 , 500);
        }
        if(fullRangeScreen==true&fullRangeScreenTimer<0)
        {
            extrasScreen.transform.GetChild(0).gameObject.SetActive(false);
            extrasScreen.GetComponent<FullRnageScreen>().HideFull();
            fullRangeScreen = false;
            warningScreen = true;
        }
        if(warningScreen==true)//7
        {
            extrasScreen.transform.GetChild(0).gameObject.SetActive(true);
            extrasScreen.GetComponent<warningScreen>().ShowWarning();

            gasNumbers.GetComponent<GasNumbers>().GasNumbersUpdate(19.5f, 10, 10, 25); 
        }
        if(warningScreen==true&warningScreenTimer<0)
        {
            extrasScreen.transform.GetChild(0).gameObject.SetActive(false);
            extrasScreen.GetComponent<warningScreen>().HideWarning();
            warningScreen = false;
            alarmScreen = true;
        }
        if(alarmScreen==true)//8
        {
            extrasScreen.transform.GetChild(0).gameObject.SetActive(true);
            extrasScreen.GetComponent<AlarmScreen>().ShowAlarm();

            gasNumbers.GetComponent<GasNumbers>().GasNumbersUpdate(23.5f, 50, 30, 50);
        }
        if(alarmScreen==true&alarmScreenTimer<0)
        {
            extrasScreen.transform.GetChild(0).gameObject.SetActive(false);
            extrasScreen.GetComponent<AlarmScreen>().HideAlarm();
            alarmScreen = false;
            stelScreen = true;
        }
        if(stelScreen==true)//9
        {
            extrasScreen.transform.GetChild(0).gameObject.SetActive(true);
            extrasScreen.transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
            extrasScreen.transform.GetChild(0).transform.GetChild(3).gameObject.SetActive(false);
            extrasScreen.GetComponent<StelScreen>().ShowStel();

            gasNumbers.GetComponent<GasNumbers>().GasNumbersUpdate(0, 0, 15, 200);
        }
        if(stelScreen==true&stelScreenTimer<0)
        {
            extrasScreen.transform.GetChild(0).gameObject.SetActive(false);
            extrasScreen.transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
            extrasScreen.transform.GetChild(0).transform.GetChild(3).gameObject.SetActive(true);
            extrasScreen.GetComponent<StelScreen>().HideStel();
            stelScreen = false;
            twaScreen = true;
        }
        if(twaScreen==true)//10
        {
            extrasScreen.transform.GetChild(0).gameObject.SetActive(true);
            extrasScreen.transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
            extrasScreen.transform.GetChild(0).transform.GetChild(3).gameObject.SetActive(false);
            extrasScreen.GetComponent<TwaScreen>().ShowTwa();

            gasNumbers.GetComponent<GasNumbers>().GasNumbersUpdate(0, 0, 10, 25);
        }
        if(twaScreen==true&twaScreenTimer<0)
        {
            extrasScreen.transform.GetChild(0).gameObject.SetActive(false);
            extrasScreen.transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
            extrasScreen.transform.GetChild(0).transform.GetChild(3).gameObject.SetActive(true);
            extrasScreen.GetComponent<TwaScreen>().HideTwa();
            twaScreen = false;
            normalOperation = true;
            
        }
        if(normalOperation==true)//resetting everything
        {

            lightsOnTimer = 1;
            lightsOffTimer = 1.5f;
            startScreenPageTimer = 0.5f;
            dateTimeTimer = 1.3f;
            batteryScreenTimer = 1.3f;
            fullRangeScreenTimer = 1.3f;
            warningScreenTimer = 1.3f;
            alarmScreenTimer = 1.3f;
            stelScreenTimer = 1.3f;
            twaScreenTimer = 1.3f;

            startingScreenStart = false;
            
        }
    }
}
    

