using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScreenManager805 : MonoBehaviour
{
    public ModeManager805 modeManager;
    public LightManager805 lightManager;
    public Bottle805 bottleS;
    [Header("Visual")]
    public GameObject normalMode;
    public int gas;
    public int set;
    public int al1;
    public int al2;
    public int al1New;
    public int al2New;
    public int f1Old;
    public int f1New;
    public GameObject fail;
    public GameObject zero;
    public GameObject span;
    public GameObject cal;
    public GameObject ouT;
    public GameObject test;
    public GameObject al;
    public GameObject f1;
    public GameObject f11;
    public GameObject bottle;

    public GameObject cOn;
    public GameObject cOff;

    public GameObject simulation;

    public GameObject adj;
    public GameObject adj1;


    [Header("timer")]
    public bool failOn;
    public bool calFixOn;
    public bool calOn;
    public bool blinking;
    public bool open;
    public float timer;
    public float calTimer;
    public float calFix;
    public float failTimer;


    public void Start()
    {
        SetAlarm();
        SetF1();
        SetZero();
        calFix = 1.5f;
        failTimer = 2.5f;
    }

    public void Update()
    {


        /* ////////////////////////////////activation
         if (modeManager.expired == true && modeManager.activation == false)
         {
             simulation.SetActive(false);
             activation.SetActive(false);
             expired.SetActive(true);
         }
         if (modeManager.activation == true)
         {
             simulation.SetActive(true);
             activation.SetActive(false);
             expired.SetActive(false);
         }
         if (modeManager.activation == false && modeManager.expired==false)
         {
             simulation.SetActive(false);
             activation.SetActive(true);
             expired.SetActive(false);
         }
         /////////////////////////////////////
         */

        if (modeManager.activated.activated == true)
        {
            simulation.SetActive(true);

        }
        
        ///////////////////////////////// adj message
        
        if (modeManager.zeroSet == 1)
        {
            adj.SetActive(true);
            adj1.SetActive(false);
        }

        if (modeManager.zeroSet == 0)
        {
            adj.SetActive(false);
            adj1.SetActive(true);
        }

        /////////////////////////////////cal fix
        if(calFixOn)
        {
            calFix -= Time.deltaTime;
            bottleS.targetNumber = 0;
        }
        if(calFix<0)
        {
            gas -= Random.Range(1, 2);
            calFix = 1.5f;
        }
        if(gas==0)
        {
            
            calFixOn = false;
            calFix = 1.5f;
        }

        /////////////////////////////////
        
        ///////////////////////////////// failscreen
        
        if(failOn)
        {
            failTimer -= Time.deltaTime;
        }
        if(failTimer<0)
        {
            fail.SetActive(false);
            normalMode.SetActive(true);
            modeManager.inMode2 = false;
            modeManager.inMode = true;
            failOn = false;
            failTimer = 2.5f;
        }

        /////////////////////////////////

        ///////////////////////////////// cal screen
        if (calOn==true)
        {
            calTimer -= Time.deltaTime;
            normalMode.SetActive(false);
            cal.SetActive(true);
        }
        if(calTimer<0)
        {
            calOn = false;
            normalMode.SetActive(true);
            cal.SetActive(false);
            calTimer = 2.5f;
            calFixOn = true;
        }
        ///////////////////////////////////////////

        /////////////////map float to screen text
        normalMode.GetComponent<TextMeshProUGUI>().text = gas.ToString("0.0");
        ///////////////////////////////////////////////////////////////////////
        if(modeManager.menuMode==true && modeManager.al==true && modeManager.al1==true && modeManager.inMode2==true)
        {
            normalMode.GetComponent<TextMeshProUGUI>().text = al1New.ToString("0.0");
        }
        if(modeManager.menuMode == true && modeManager.al == true && modeManager.al2 == true && modeManager.inMode2 == true)
        {
            normalMode.GetComponent<TextMeshProUGUI>().text = al2New.ToString("0.0");
        }
        if(modeManager.menuMode == true && modeManager.f1==true && modeManager.inMode2==true)
        {
            normalMode.GetComponent<TextMeshProUGUI>().text = f1New.ToString("");
        }
        if(modeManager.menuMode == true && modeManager.f1==true && modeManager.inMode == true)/////ftiaksimo thelei gia mou gyrnaei se auto afou to stusw
        {
           // gas = f1Old;
        }
        if(modeManager.menuMode == true && modeManager.zero == true && (modeManager.zeroSet == 1 || modeManager.zeroSet ==  0) && (modeManager.inMode==true || modeManager.inMode2==true))
        {
            normalMode.GetComponent<TextMeshProUGUI>().text = set.ToString("0.0");
        }
        ///////////////////////////////////////////////////////////////////////reseting gas below 0
        if(gas<0)
        {
            gas = 0;
        }
        if(al1<0)
        {
            al1 = 0;
        }
        if(al2<0)
        {
            al2 = 0;
        }
        if(al1New<0)
        {
            al1New = 0;
        }
        if(al2New<0)
        {
            al2New = 0;
        }
        if(f1Old<0)
        {
            f1Old = 0;
        }
        if(f1New<0)
        {
            f1New = 0;
        }
        /////////////////map float in alarms
        if(modeManager.menuMode==true && modeManager.al==true && modeManager.al1==true && modeManager.inMode == true)
        {
            gas = al1;
        }
        if(modeManager.menuMode==true && modeManager.al==true && modeManager.al2==true && modeManager.inMode == true)
        {
            gas = al2;
        }
        ////////////////////////////////////
        
        if(modeManager.inMode == false && modeManager.inMode2==false && !modeManager.alarmTesting)
        {
            gas = 0;
        }

        if(blinking==true)
        {
            timer -= Time.deltaTime;
        }
        if(timer<0 && blinking==true)
        {
            timer = 0.5f;
            if(open==true)
            {
                open = false;
            }
            else
            {
                open = true;
            }
        }
        if(blinking==false)
        {
            timer = 0.5f;
        }


        if(modeManager.normalMode==true)
        {
            normalMode.SetActive(true);
            zero.SetActive(false);
            span.SetActive(false);
            ouT.SetActive(false);
            al.SetActive(false);
            f1.SetActive(false);
            test.SetActive(false);
            lightManager.blinking = false;
            lightManager.blinkingLel = false;
            lightManager.blinkingSkip = false;
            lightManager.pw = true;
            lightManager.lel = true;
            lightManager.al = false;
            lightManager.al2 = false;
            lightManager.span = false;
            lightManager.ma = false;
            lightManager.skip = false;
            lightManager.zero = false;
            lightManager.open = false;
        }
        if(modeManager.normalMode==false)
        {
            normalMode.SetActive(false);
            lightManager.pw = false;
            lightManager.lel = false;
        }
        //////////////////////////////////////// menu
        if(modeManager.menuMode==true && modeManager.zero==true)//zero
        {
            zero.SetActive(true);
            span.SetActive(false);
            ouT.SetActive(false);
            al.SetActive(false);
            test.SetActive(false);
            f1.SetActive(false);
            lightManager.pw = true;
            lightManager.skip = true;
            lightManager.blinking = true;
            lightManager.blinkingSkip = true;
        }

        if(modeManager.menuMode==true && modeManager.span==true)//span
        {
            zero.SetActive(false);
            span.SetActive(true);
            ouT.SetActive(false);
            al.SetActive(false);
            test.SetActive(false);
            f1.SetActive(false);
            lightManager.pw = true;
            lightManager.skip = true;
            lightManager.blinking = true;
            lightManager.blinkingSkip = true;
            
        }

        if(modeManager.menuMode==true && modeManager.ouT==true)//out
        {
            zero.SetActive(false);
            span.SetActive(false);
            ouT.SetActive(true);
            al.SetActive(false);
            test.SetActive(false);
            f1.SetActive(false);
            lightManager.pw = true;
            lightManager.skip = true;
            lightManager.blinking = true;
            lightManager.blinkingSkip = true;
            lightManager.blinkingZero = false;
        }

        if(modeManager.menuMode==true && modeManager.al==true)//al
        {
            zero.SetActive(false);
            span.SetActive(false);
            ouT.SetActive(false);
            al.SetActive(true);
            test.SetActive(false);
            f1.SetActive(false);
            lightManager.pw = true;
            lightManager.skip = true;
            lightManager.blinking = true;
            lightManager.blinkingSkip = true;
            
        }

        if (modeManager.menuMode && modeManager.test) // test
        {
            normalMode.SetActive(false);
            cOff.SetActive(false);
            cOn.SetActive(false);
            zero.SetActive(false);
            span.SetActive(false);
            ouT.SetActive(false);
            al.SetActive(false);
            test.SetActive(true);
            f1.SetActive(false);
            modeManager.modeSelector2 = 0;
            lightManager.pw = true;
            lightManager.skip = true;
            lightManager.blinking = true;
            lightManager.blinkingSkip = true;
            lightManager.span = false;
            lightManager.zero = false;
            lightManager.blinkingSpan = false;
            lightManager.blinkingZero = false;
        }

        if (modeManager.menuMode==true && modeManager.f1 == true)//F1
        {
            zero.SetActive(false);
            span.SetActive(false);
            ouT.SetActive(false);
            al.SetActive(false);
            test.SetActive(false);
            f1.SetActive(true);
            lightManager.pw = true;
            lightManager.skip = true;
            lightManager.blinking = true;
            lightManager.blinkingSkip = true;
        }
        //////////////////////////////////////////////

        ////////////////////////////////////////////// test menu

        if (modeManager.testMenuMode && modeManager.modeSelector2 == 0)
        {
            test.SetActive(false);
            cOff.SetActive(true);
            cOn.SetActive(false);
            lightManager.pw = true;
            lightManager.skip = true;
            lightManager.blinking = true;
            lightManager.blinkingSkip = true;
        }

        if (modeManager.testMenuMode && modeManager.modeSelector2 == 1)
        {
            test.SetActive(false);
            cOff.SetActive(false);
            cOn.SetActive(true);
            lightManager.pw = true;
            lightManager.skip = true;
            lightManager.blinking = true;
            lightManager.blinkingSkip = true;
        }


        //////////////////////////////////////////////

        ////////////////////////////////////////////// alarm Testing

        if (modeManager.alarmTesting)
        {
            normalMode.SetActive(true);
            cOn.SetActive(false);
            lightManager.pw = true;
            lightManager.skip = true;
            lightManager.span = true;
            lightManager.zero = true;
            lightManager.blinking = true;
            lightManager.blinkingSkip = true;
            lightManager.blinkingLel = true;
            lightManager.blinkingSpan = true;
            lightManager.blinkingZero = true;
        }

        //////////////////////////////////////////// alarm opening

        if (modeManager.alarmTesting && gas > 10)
        {
            lightManager.al = true;

        }

        if (modeManager.alarmTesting && gas > 30)
        {
            lightManager.al2 = true;
        }

        if (modeManager.alarmTesting && gas < 30)
        {
            lightManager.al2 = false;
        }

        if (modeManager.alarmTesting && gas < 10)
        {
            lightManager.al = false;
        }

        ////////////////////////////////////////////// in mode

        if (modeManager.menuMode==true && modeManager.zero==true && modeManager.inMode==true)//zero
        {
            
            zero.SetActive(false);
            span.SetActive(false);
            ouT.SetActive(false);
            al.SetActive(false);
            f1.SetActive(false);
            lightManager.pw = true;
            lightManager.skip = true;
            lightManager.zero = true;
            lightManager.blinking = true;
            lightManager.blinkingSkip = true;
            lightManager.blinkingZero = true;
            blinking = true;
        }

        if(modeManager.menuMode==true && modeManager.span==true && modeManager.inMode==true)//span
        {
            zero.SetActive(false);
            span.SetActive(false);
            ouT.SetActive(false);
            al.SetActive(false);
            f1.SetActive(false);
            lightManager.pw = true;
            lightManager.skip = true;
            lightManager.span = true;
            lightManager.blinking = true;
            lightManager.blinkingSkip = true;
            lightManager.blinkingSpan = true;
            blinking = true;
            calTimer = 2.5f;
            bottle.SetActive(true);// edw tha valw kai to cap
        }

        if(modeManager.menuMode == true && modeManager.al == true && modeManager.al1 == true && modeManager.inMode == true)//al1
        {
            zero.SetActive(false);
            span.SetActive(false);
            ouT.SetActive(false);
            al.SetActive(false);
            f1.SetActive(false);
            lightManager.pw = true;
            lightManager.skip = true;
            lightManager.al = true;
            lightManager.al2 = false;
            lightManager.blinking = true;
            lightManager.blinkingSkip = true;
            normalMode.SetActive(true);
            lightManager.blinkingAl = false;
            lightManager.blinkingAl2 = false;
            blinking = false;
        }
        if(modeManager.menuMode==true && modeManager.al==true && modeManager.al2==true && modeManager.inMode == true)//al2
        {
            zero.SetActive(false);
            span.SetActive(false);
            ouT.SetActive(false);
            al.SetActive(false);
            f1.SetActive(false);
            lightManager.pw = true;
            lightManager.skip = true;
            lightManager.al = false;
            lightManager.al2 = true;
            lightManager.blinking = true;
            lightManager.blinkingSkip = true;
            normalMode.SetActive(true);
            lightManager.blinkingAl = false;
            lightManager.blinkingAl2 = false;
            blinking = false;
        }

        if (modeManager.menuMode == true && modeManager.f1 == true && modeManager.inMode == true)//F1
        {

            zero.SetActive(false);
            span.SetActive(false);
            ouT.SetActive(false);
            al.SetActive(false);
            f1.SetActive(false);
            f11.SetActive(true);
            lightManager.pw = true;
            lightManager.skip = true;
            lightManager.blinking = true;
            lightManager.blinkingSkip = true;
            lightManager.blinkingPw = false;
            blinking = false;
            
        }
        ///////////////////////////////////////////////

        ///////////////////////////////////////////////in mode2

        if (modeManager.menuMode == true && modeManager.zero == true && modeManager.inMode2 == true)//zero
        {
            normalMode.SetActive(true);
            zero.SetActive(false);
            span.SetActive(false);
            ouT.SetActive(false);
            al.SetActive(false);
            f1.SetActive(false);
            lightManager.pw = true;
            lightManager.skip = true;
            lightManager.zero = true;
            lightManager.blinking = true;
            lightManager.blinkingSkip = true;
            lightManager.blinkingZero = false;
            open = false;
            blinking = false;
        }

        if(modeManager.menuMode==true && modeManager.span == true && modeManager.inMode2 ==true)//span
        {
            if (calOn == false &! failOn)
            {
                normalMode.SetActive(true);
            }
            zero.SetActive(false);
            span.SetActive(false);
            ouT.SetActive(false);
            al.SetActive(false);
            f1.SetActive(false);
            lightManager.pw = true;
            lightManager.skip = true;
            lightManager.span = true;
            lightManager.blinking = true;
            lightManager.blinkingSkip = true;
            lightManager.blinkingSpan = false;
            blinking = false;
            bottle.SetActive(false);///kai to cup
            bottleS.gased = false;
            //bottleS.targetNumber = 0;
            bottleS.timer=1.2f;
            
        }

        if(modeManager.menuMode == true && modeManager.al == true && modeManager.al1 == true && modeManager.inMode2 == true)//al1
        {
            zero.SetActive(false);
            span.SetActive(false);
            ouT.SetActive(false);
            al.SetActive(false);
            f1.SetActive(false);
            lightManager.pw = true;
            lightManager.skip = true;
            lightManager.al = true;
            lightManager.al2 = false;
            lightManager.blinking = true;
            lightManager.blinkingSkip = true;
            lightManager.blinkingAl = true;
            lightManager.blinkingAl2 = false;
            blinking = true;
        }
        if (modeManager.menuMode == true && modeManager.al == true && modeManager.al2 == true && modeManager.inMode2 == true)//al2
        {
            zero.SetActive(false);
            span.SetActive(false);
            ouT.SetActive(false);
            al.SetActive(false);
            f1.SetActive(false);
            lightManager.pw = true;
            lightManager.skip = true;
            lightManager.al = false;
            lightManager.al2 = true;
            lightManager.blinking = true;
            lightManager.blinkingSkip = true;
            lightManager.blinkingAl = false;
            lightManager.blinkingAl2 = true;
            blinking = true;
        }

        if (modeManager.menuMode == true && modeManager.f1 == true && modeManager.inMode2 == true)//F1
        {
            zero.SetActive(false);
            span.SetActive(false);
            ouT.SetActive(false);
            al.SetActive(false);
            f1.SetActive(false);
            f11.SetActive(false);
            lightManager.pw = true;
            lightManager.skip = true;
            lightManager.blinking = true;
            lightManager.blinkingSkip = true;
            lightManager.blinkingPw = true;
            blinking = false;
            normalMode.SetActive(true);

        }
        ////////////////////////////////////////////////////
        
        /////blinking screen
        if (modeManager.zero==true && blinking==true && open==false)
        {
            normalMode.SetActive(true);
        }
        if(modeManager.zero==true && blinking==true && open==true)
        {
            normalMode.SetActive(false);
        }

        if(modeManager.span == true && blinking == true && open == false)
        {
            normalMode.SetActive(true);
        }
        if (modeManager.span == true && blinking == true && open == true)
        {
            normalMode.SetActive(false);
        }

        if (modeManager.al == true && blinking == true && open == false)
        {
            normalMode.SetActive(true);
        }
        if (modeManager.al == true && blinking == true && open == true)
        {
            normalMode.SetActive(false);
        }
       
        


        ///////////////////////////////////////////// closing
        if(modeManager.menuMode==false && modeManager.normalMode==false && !modeManager.testMenuMode && !modeManager.alarmTesting)
        {
            zero.SetActive(false);
            span.SetActive(false);
            ouT.SetActive(false);
            al.SetActive(false);
            f1.SetActive(false);
            lightManager.pw = false;
            lightManager.skip = false;
            lightManager.blinking = false;
            lightManager.open = false;
            lightManager.blinkingSkip = false;
        }

        if(modeManager.menuMode==true && modeManager.inMode==false && modeManager.inMode2==false)
        {
            normalMode.SetActive(false);
            f11.SetActive(false);
            lightManager.blinkingZero = false;
            blinking = false;
            lightManager.zero = false;
            lightManager.span = false;
            lightManager.al = false;
            lightManager.al2 = false;
            lightManager.blinkingPw = false;
            bottle.SetActive(false);
        }
    }

    public void SetAlarm()
    {
        al1 = 20;
        al2 = 60;
        al1New = al1;
        al2New = al2;
    }

    public void SetF1()
    {
        if(modeManager.zeroSet==0)
        {
            f1Old = 3000;
            f1New = f1Old;
        }

        if(modeManager.zeroSet==1)
        {
            f1Old = Random.Range(2850, 2901);
            f1New = f1Old;
        }
        // an den einai 
        
    }

    public void SetZero()
    {
        if(modeManager.zeroSet==1)
        {
            set = Random.Range(1, 9);
        }
        if(modeManager.zeroSet==0)
        {
            set = 0;
        }
    }

    public void ZeroAdj()
    {
        if (modeManager.zeroSet == 0)
        {
            modeManager.zeroSet = 1;
            SetZero();
            SetF1();
            return;
        }

        if (modeManager.zeroSet == 1)
        {
            modeManager.zeroSet = 0;
            SetZero();
            SetF1();
            return;
        }
    }
}
