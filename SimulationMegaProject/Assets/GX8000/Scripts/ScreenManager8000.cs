using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScreenManager8000 : MonoBehaviour
{
    public GameObject screen;
    public GameObject startingScreen;
    [Space]
    [Header("time-date")]
    public GameObject time;
    public GameObject timeStart;
    public GameObject  date;
    [Space]
    [Header("message screens")]
    public GameObject menuMessage;
    public GameObject ScreenMessage;
    [Space]
    [Header("extras")]
    public GameObject batteryImg;
    public GameObject batteryVolt;
    public GameObject alarmLights;
    public GameObject infoScreen;
    public GameObject oneDScreen;
    public GameObject countdown;
    public GameObject bottleVol;
    public GameObject bottleLel;
    public Bottle volB;
    public Bottle lelB;
    public GameObject barHc;
    public GameObject barO2;
    public GameObject barCo;
    public GameObject barH2s;
    public GameObject meterHC;
    public GameObject meterO2;
    public GameObject meterCo;
    public GameObject meterH2s;
    [Space]
    [Header("names")]
    public GameObject gasNames;
    public GameObject o2n;
    public GameObject h2sn;
    public GameObject con;
    public GameObject hcn;
    public GameObject o2Per;
    public GameObject h2sPpm;
    public GameObject coPpm;
    public GameObject hcVol;
    public GameObject hcLel;
    [Space]
    [Header("numbers")]
    public GameObject gasNumbers;
    public FloatVariable hc;
    public FloatVariable co;
    public FloatVariable h2s;
    public FloatVariable o2;
    public FloatVariable countdownNumber;
    [Header("settings")]
    public GameObject meters;
    public GameObject heart;
    public GameObject Settings;
    public GameObject airTxt;
    public GameObject powerTxt;
    public GameObject resettxt;
    public GameObject displayTxt;
    public GameObject changeMsgTxt;
    public GameObject bars;
    public GameObject backScreen;
    public GameObject propeler;

}
