using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirClean : MonoBehaviour
{
    public GameObject gx2009;
    public GameObject screenManager;
    public GameObject extras;
    public GameObject buttonManager;
    public GameObject warning;
    public GameObject alarm;
    public GameObject lightsManager;
    [Space]
    public float airCleanTimer;
    public float airAdjTimer;
    public float endAirCalTimer;
    [Space]
    public bool airCalStart;
    public bool endAirCal;

    // Update is called once per frame
    void Update()
    {
        foreach (CustomButton b in buttonManager.GetComponent<ButtonManager>().buttons)//psaxnei mesa sto button manager
        {
            if(b.name=="Air")//pianei to air button
            {
                if(b.isPressed==true&(gx2009.GetComponent<OpeningScreen>().normalOperation==true||gx2009.GetComponent<CalibrationMode>().menuSelection==1))
                {
                    AirCleanSeq();
                }
                if(b.isPressed==false)
                {
                    ResetTimer();
                }
            }
        }
        if(airCleanTimer<2.5f)
        {
            AirCal();
            
            airCalStart = true;//apo edw kovw to normal operation screen
        }
        if(airCleanTimer<0)
        {
            AirAdj();
        }
        if(endAirCal==true)
        {
            endAirCalTimer -= Time.deltaTime;
        }
        if(endAirCalTimer<0)
        {
            ReturnToNormal();
        }
    }
    private void AirCleanSeq()
    {
        airCleanTimer -= Time.deltaTime;
    }
    private void ResetTimer()
    {
        if(airCalStart==false)//na mhn kanei reset sthn mesh tou air cal/prepei na gia na gurnaei
        {
            airCleanTimer = 4.5f;
        }
        
    }
    private void AirCal()//mporei na xreiastei na ginei public gia na to xrhsimopoihsw kai sto calibration
    {
        extras.transform.GetChild(3).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "HOLD   AIR";
        extras.transform.GetChild(4).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "AIR     CAL";
        screenManager.transform.transform.GetChild(0).gameObject.SetActive(false);
        extras.transform.GetChild(0).gameObject.SetActive(false);
        extras.transform.GetChild(5).gameObject.SetActive(false);
        extras.transform.GetChild(1).gameObject.SetActive(false);
    }
    private void AirAdj()//to idio
    {
        extras.transform.GetChild(3).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "RELEASE";
        extras.transform.GetChild(4).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "ADJ";
        airCalStart = false;
        endAirCal = true;
        endAirCalTimer = 2;
        ///////////////////////////////////////////////////////////////////////reseting warning
        warning.GetComponent<Warning>().warningStart = false;
        warning.GetComponent<Warning>().warningOn = false;
        warning.GetComponent<Warning>().gasSelected = 0;
        warning.GetComponent<Warning>().o2Selected = false;
        warning.GetComponent<Warning>().ch4Selected = false;
        warning.GetComponent<Warning>().h2sSelected = false;
        warning.GetComponent<Warning>().coSelected = false;
        warning.GetComponent<Warning>().WarningSoundPause();
        warning.GetComponent<Warning>().airCleaned = true;
        lightsManager.GetComponent<Lights_Manager>().timeSelected = false;
        lightsManager.GetComponent<Lights_Manager>().LightsOff();
        //////////////////////////////////////////////////////////////////////reseting warning
        //////////////////////////////////////////////////////////////////////reseting alarm
        alarm.GetComponent<Alarm>().warningStart = false;
        alarm.GetComponent<Alarm>().warningOn = false;
        alarm.GetComponent<Alarm>().alarmOn = false;
        alarm.GetComponent<Alarm>().alarmFinish = false;
        alarm.GetComponent<Alarm>().gasSelected = 0;
        alarm.GetComponent<Alarm>().o2Selected = false;
        alarm.GetComponent<Alarm>().ch4Selected = false;
        alarm.GetComponent<Alarm>().h2sSelected = false;
        alarm.GetComponent<Alarm>().coSelected = false;
        alarm.GetComponent<Alarm>().WarningSoundPause();
        alarm.GetComponent<Alarm>().AlarmSoundPause();
        alarm.GetComponent<Alarm>().airCleaned = true;
        alarm.GetComponent<Alarm>().airCleanedAlarm = true;
        lightsManager.GetComponent<Lights_Manager>().timeSelected = false;
        lightsManager.GetComponent<Lights_Manager>().LightsOff();
        //////////////////////////////////////////////////////////////////////reseting alarm
        
    }
    private void ReturnToNormal()//to idio
    {
        
        endAirCal = false;
        endAirCalTimer = 2;
        if(gx2009.GetComponent<CalibrationMode>().menuSelection==1)
        {
            gx2009.GetComponent<CalibrationMode>().endSkip = true;
        }
        if(endAirCal==false&airCalStart==false&gameObject.GetComponent<OpeningScreen>().startingScreenStart==false)
        {
            extras.transform.GetChild(3).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "";
            extras.transform.GetChild(4).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "";
        }
    }
       
}
