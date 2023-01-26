using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeManager750 : MonoBehaviour
{
    [Header("modes")]
    public ActivationState activated;
    public ExpirationState expired;
    public bool normalMode;
    public bool menuMode;
    public bool inMode;
    public bool inMode2;
    public bool inMode3;
    [Header("menu")]
    public float modeSelector;
    public float modeSelectorAlarm;
    public bool zero;
    public bool span;
    public bool ouT;
    public bool al;
    public bool f1;
    public bool al1;
    public bool al2;
    public int zeroSet;


    public void Awake()
    {
        zeroSet = 0;
        normalMode = true;
    }


    public void Update()
    {

        if (expired.expired == true)
        {
            activated.activated = false;
        }

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
                    f1 = false;
                    break;
                case 1:
                    zero = false;
                    span = true;
                    ouT = false;
                    al = false;
                    f1 = false;
                    break;
                case 2:
                    zero = false;
                    span = false;
                    ouT = true;
                    al = false;
                    f1 = false;
                    break;
                case 3:
                    zero = false;
                    span = false;
                    ouT = false;
                    al = true;
                    f1 = false;
                    break;
                /*case 4:
                    zero = false;
                    span = false;
                    ouT = false;
                    al = false;
                    f1 = true;
                    break;*/

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
            inMode3 = false;
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
        if (modeSelector == 4)
        {
            modeSelector = 0;
        }
    }
    public void CircleMenuDown()
    {
        modeSelector -= 1;
        if (modeSelector == -1)
        {
            modeSelector = 3;
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
