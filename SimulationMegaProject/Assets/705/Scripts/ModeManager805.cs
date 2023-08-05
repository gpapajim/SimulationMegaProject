using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeManager805 : MonoBehaviour
{
    [Header("modes")]
    public ActivationState activated;
    public ExpirationState expired;
    public bool normalMode;
    public bool menuMode;
    public bool testMenuMode;
    public bool inMode;
    public bool inMode2;
    [Header("menu")]
    public float modeSelector;
    public float modeSelector2;
    public float modeSelectorAlarm;
    public bool zero;
    public bool span;
    public bool ouT;
    public bool al;
    public bool test;
    public bool f1;
    public bool al1;
    public bool al2;
    public int zeroSet;

    public bool cOn;
    public bool cOff;

    public bool alarmTesting;


    public void Awake()
    {
        zeroSet = 0;
        normalMode = true;
    }


    public void Update()
    {

        

        if (menuMode == true)
        {
            normalMode = false;
        }

        ///////////////////////////menu selection
        if (menuMode == true)
        {

            switch (modeSelector)
            {
                case 0:
                    zero = true;
                    span = false;
                    ouT = false;
                    al = false;
                    test = false;
                    f1 = false;
                    break;
                case 1:
                    zero = false;
                    span = true;
                    ouT = false;
                    al = false;
                    test = false;
                    f1 = false;
                    break;
                case 2:
                    zero = false;
                    span = false;
                    ouT = true;
                    al = false;
                    test = false;
                    f1 = false;
                    break;
                case 3:
                    zero = false;
                    span = false;
                    ouT = false;
                    al = true;
                    test = false;
                    f1 = false;
                    break;
                case 4:
                    zero = false;
                    span = false;
                    ouT = false;
                    al = false;
                    test = true;
                    f1 = false;
                    break;
                case 5:
                    zero = false;
                    span = false;
                    ouT = false;
                    al = false;
                    test = false;
                    f1 = true;
                    break;

            }
        }

        //////////////////////////////////// test menu selection

        if (testMenuMode)
        {
            switch (modeSelector2)
            {
                case 0:
                    test = false;
                    cOff = true;
                    cOn = false;
                    break;
                case 1:
                    test = false;
                    cOff = false;
                    cOn = true;
                    break;
            }
        }


        /////////////////////////////////////////

        if (al == true && inMode==true)
        {
            switch (modeSelectorAlarm)
            {
                case 0:
                    al1 = true;
                    al2 = false;
                    break;
                case 1:
                    al1 = false;
                    al2 = true;
                    break;
            }
        }


        ////////////////////closing menu
        if (menuMode == false)
        {
            zero = false;
            span = false;
            ouT = false;
            al = false;
            al1 = false;
            al2 = false;
            inMode = false;
            inMode2 = false;
            f1 = false;
            modeSelector = 0;
            modeSelectorAlarm = 0;
        }
        ///////////////////////////////
    }

    
    ///////////////////moving up and down in menus
    
    public void CircleMenuUp()
    {
        modeSelector += 1;
        if (modeSelector == 6)
        {
            modeSelector = 0;
        }
    }
    public void CircleMenuDown()
    {
        modeSelector -= 1;
        if (modeSelector == -1)
        {
            modeSelector = 5;
        }
    }

    public void CircleMenuUp2()
    {
        modeSelector2 += 1;
        if (modeSelector2 == 2)
        {
            modeSelector2 = 0;
        }

    }

    public void CircleMenuDown2()
    {
        modeSelector2 -= 1;
        if (modeSelector2 == -1)
        {
            modeSelector2 = 1;
        }

    }

    public void CircleAlarmUp()
    {
        modeSelectorAlarm += 1;
        if (modeSelectorAlarm == 2)
        {
            modeSelectorAlarm = 0;
        }
    }
    public void CircleAlarmDown()
    {
        modeSelectorAlarm -= 1;
        if (modeSelectorAlarm == -1)
        {
            modeSelectorAlarm = 1;
        }
    }
}
