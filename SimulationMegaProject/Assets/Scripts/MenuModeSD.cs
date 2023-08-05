using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MenuModeSD : MonoBehaviour
{
    public ModeManagerSD mode;
    public Lightssd1rdi lights;
    public ButtonPressSD buttons;
    public ScreenManagerSD screenManager;
    public Error error;

    public bool getInMode;
    public bool getInModeHand;
    public bool getFixHand;
    public bool inMode;
    public bool inMode2;
    public bool inMode3;
    public bool inMode4;
    public bool inMode4a;
    public bool inMode4h;
    public bool inMode4hf;
    public bool in2_2Manual;
    public bool inCalZero;
    public bool gasIn;
    public bool gasInDone;
    public bool inAuto;
    public bool inHand;
    
    
    

    public int menuSelector;
    public int menuSelector2;
    public int menuSelector3;
    public int menuSelector4;
    public int menuSelector2_0;
    public int menuSelector2_0Menu;

    public float inModeW8;
    public float inModeW8h;
    public float inModeFix;
    public float menu2Timer;
    public float calTimer;
    public float gasInTimer;
    public float autoTimer;

    public float gasNumber;

    public void Awake()
    {
        //menu2Timer = 3.5f;
    }

    public void Start()
    {
        menu2Timer = 3.5f;
        inModeW8 = 0.3f;
        inModeW8h = 0.3f;
        inModeFix = 0.3f;
        calTimer = 4.5f;
        gasInTimer = 1.5f;
        autoTimer = 3.0f;
        menuSelector4 = 2; //// gia na mhn mpainei me thn mia
    }

    public void Update()
    {   
        if (!mode.normalMode)
        {
            lights.blinkingPower = true;
        }
        
        ////////////////////menu selector zeroing
        
        if (mode.normalMode)
        {
            menuSelector = 0;
            menuSelector2 = 0;
            menuSelector3 = 0;
            menuSelector4 = 0;
            menuSelector2_0 = 0;
            menuSelector2_0Menu = 0;
        }

        if (in2_2Manual)    ////////////call function
        {
            In2_2Manual();
        }

        if (mode.maintenanceMode)
        {
            lights.blinkingPower = true;
        }
        /////////////////////
        /////////////////////////////1-3
        if (inMode && menuSelector == 3 && buttons.set)
        {
            menu2Timer -= Time.deltaTime;
            screenManager.dot.DotsControl(true, true, true, true);
        }

        if (menu2Timer < 0)
        {
            mode.maintenanceMode2 = true;
            mode.maintenanceMode = false;
            inMode = false;
            screenManager.dot.DotsControl(false, false, false, false);
            screenManager.scores.SetActive(false);
            menu2Timer = 3.5f;
        }

        if (inMode && menuSelector == 3 && !buttons.set)
        {
            menu2Timer = 3.5f;
            screenManager.dot.DotsControl(false, false, false, false);
        }
        ///////////////////////////////1-3
        
        ///////////////////////////////W8
        if (getInMode)
        {
            screenManager.m10.SetActive(false);
            screenManager.m11.SetActive(false);
            screenManager.m12.SetActive(false);
            screenManager.m13.SetActive(false);

            inModeW8 -= Time.deltaTime;
        }

        if (inModeW8 <0)
        {
            

            if (mode.maintenanceMode && menuSelector == 3)//1-3
            {
                InMode13();// me if gia na ksexwrisw apo alla modes
                inMode = true;
            }
            
            if (mode.maintenanceMode2 && menuSelector2 == 1 && !inCalZero && !error.error2 && !error.error1)//2-1
            {
                InMode21();
                inMode2 = true;
                ClearScreen();
            }

            if (mode.maintenanceMode2 && menuSelector2 == 2 && !error.error2 && !error.error1 && !in2_2Manual)//2-2
            {
                InMode22();
                inMode2 = true;
                ClearScreen();
            }

            if (mode.maintenanceMode2 && menuSelector2 == 4)//2-4
            {
                ClearScreen();
                mode.maintenanceMode3 = true;
                screenManager.dot.DotsControl(false, true, false, false);

                mode.maintenanceMode2 = false;
            }
            if (mode.maintenanceMode3 && menuSelector3 == 16)
            {

                if (!inMode4hf)
                {
                    mode.maintenanceMode4 = true;
                    mode.maintenanceMode3 = false;

                    getInModeHand = true;
                    ClearScreen();
                }

               
            }
            if (mode.maintenanceMode4 && menuSelector4 == 1)
            {
                inMode4a = true;
                InMode24ha();
                ClearScreen();
            }

            /*if (mode.maintenanceMode4 && menuSelector4 == 0)
            {
                inMode4h = true;
                InMode24hh();
                ClearScreen();
            }    */

            inMode4hf = false;
            getInMode = false;
            inModeW8 = 0.3f;
        }
        //////////////////////////// w8 hand
        
        if (getInModeHand)
        {
            inModeW8h -= Time.deltaTime;
        }

        if (inModeW8h < 0)
        {
            inMode4 = true;
            getInModeHand = false;
            inModeW8h = 0.3f;
        }
        ////////////////////////// w8 hand fix
        
        if (getFixHand)
        {
            inModeFix -= Time.deltaTime;
        }
        if (inModeFix < 0)
        {
            inMode4hf = true;
            getFixHand = false;
            inModeFix = 0.3f;
        }

        ////////////////////////////autoFix
        if (inAuto)
        {
            autoTimer -= Time.deltaTime;
        }
        if (inAuto && autoTimer < 1.5f)
        {
            AutoFix();
        }
        if (inAuto && autoTimer <0)///////////////edw tha kleinw ta bool twn faults meta apo auto
        {
            AutoFix();
            menuSelector4 = 0;
            mode.maintenanceMode4 = false;
            mode.maintenanceMode3 = true;
            autoTimer = 3.0f;
            inMode4 = false;
            inMode4a = false;
            inAuto = false;
            screenManager.dot.DotsControl(false, true, false, false);
        }

        ////////////////////////////cal  start
        if (inCalZero && !inMode2)
        {
            CalZero();
            ClearScreen();
            inMode2 = true;//
        }
        //////////////////////////////////////////cal Screens
        if (inCalZero)
        {
            calTimer -= Time.deltaTime;
        }
        if (inCalZero && calTimer >2.5f)
        {
            CalZero();
        }
        if (inCalZero && calTimer <2.5f)
        {
            CalZero();
        }
        if (inCalZero && calTimer <0)
        {
            CalZero();
            inCalZero = false;
            inMode2 = false;//
            gasInDone = false;//
            calTimer = 4.5f;
        }

        /////////////////////////////////////////gasIn
        if (gasIn)
        {
            gasInTimer -= Time.deltaTime;
        }
        if (gasInTimer <0)
        {
            Gased();
            gasInTimer = 1.5f;
        }
        if (!gasIn)
        {
            gasInTimer = 1.5f;
        }

        ////////////////////////// Conn Mode
        
        if (mode.Conn && screenManager.C4H10.Value > 100)
        {
            lights.AlarmLightOn();
        }

        if (mode.Conn && screenManager.C4H10.Value < 100)
        {
            lights.AlarmLightOff();
        }
      
        ///////////////////////////menu selection
        if (mode.maintenanceMode && !inMode)
        {

            switch (menuSelector)
            {
                case 0://1-0
                    screenManager.m10.SetActive(true);
                    screenManager.m11.SetActive(false);
                    screenManager.m12.SetActive(false);
                    screenManager.m13.SetActive(false);
                    break;
                case 1://1-1
                    screenManager.m10.SetActive(false);
                    screenManager.m11.SetActive(true);
                    screenManager.m12.SetActive(false);
                    screenManager.m13.SetActive(false);
                    break;
                case 2://1-2
                    screenManager.m10.SetActive(false);
                    screenManager.m11.SetActive(false);
                    screenManager.m12.SetActive(true);
                    screenManager.m13.SetActive(false);
                    break;
                case 3://1-3
                    screenManager.m10.SetActive(false);
                    screenManager.m11.SetActive(false);
                    screenManager.m12.SetActive(false);
                    screenManager.m13.SetActive(true);
                    break;

            }
        }

        if (mode.maintenanceMode2 && !inMode2 && !inCalZero && !in2_2Manual)
        {
            switch (menuSelector2)
            {
                case 0://2-0
                    screenManager.m20.SetActive(true);
                    screenManager.m21.SetActive(false);
                    screenManager.m27.SetActive(false);
                    break;
                case 1://2-1
                    screenManager.m21.SetActive(true);
                    screenManager.m22.SetActive(false);
                    screenManager.m20.SetActive(false);
                    break;
                case 2://2-2
                    screenManager.m22.SetActive(true);
                    screenManager.m21.SetActive(false);
                    screenManager.m23.SetActive(false);
                    break;
                case 3://2-3
                    screenManager.m23.SetActive(true);
                    screenManager.m24.SetActive(false);
                    screenManager.m22.SetActive(false);
                    break;
                case 4://2-4
                    screenManager.m24.SetActive(true);
                    screenManager.m23.SetActive(false);
                    screenManager.m25.SetActive(false);
                    break;
                case 5://2-5
                    screenManager.m25.SetActive(true);
                    screenManager.m26.SetActive(false);
                    screenManager.m24.SetActive(false);
                    break;
                case 6://2-6
                    screenManager.m26.SetActive(true);
                    screenManager.m25.SetActive(false);
                    screenManager.m27.SetActive(false);
                    break;
                case 7://2-7
                    screenManager.m27.SetActive(true);
                    screenManager.m26.SetActive(false);
                    screenManager.m20.SetActive(false);
                    break;
            }
        }

        if (mode.maintenanceMode3 && !inMode3)
        {
            //screenManager.dot.DotsControl(false, true, false, false);

            switch (menuSelector3)
            {
                case 0://2-4-0
                    screenManager.m240.SetActive(true);
                    screenManager.m24i.SetActive(false);
                    screenManager.m241.SetActive(false);
                    break;
                case 1://2-4-0
                    screenManager.m241.SetActive(true);
                    screenManager.m240.SetActive(false);
                    screenManager.m242.SetActive(false);
                    break;
                case 2://2-4-0
                    screenManager.m242.SetActive(true);
                    screenManager.m241.SetActive(false);
                    screenManager.m243.SetActive(false);
                    break;
                case 3://2-4-0
                    screenManager.m243.SetActive(true);
                    screenManager.m242.SetActive(false);
                    screenManager.m244.SetActive(false);
                    break;
                case 4://2-4-0
                    screenManager.m244.SetActive(true);
                    screenManager.m243.SetActive(false);
                    screenManager.m245.SetActive(false);
                    break;
                case 5://2-4-0
                    screenManager.m245.SetActive(true);
                    screenManager.m244.SetActive(false);
                    screenManager.m246.SetActive(false);
                    break;
                case 6://2-4-0
                    screenManager.m246.SetActive(true);
                    screenManager.m245.SetActive(false);
                    screenManager.m247.SetActive(false);
                    break;
                case 7://2-4-0
                    screenManager.m247.SetActive(true);
                    screenManager.m246.SetActive(false);
                    screenManager.m248.SetActive(false);
                    break;
                case 8://2-4-0
                    screenManager.m248.SetActive(true);
                    screenManager.m247.SetActive(false);
                    screenManager.m249.SetActive(false);
                    break;
                case 9://2-4-0
                    screenManager.m249.SetActive(true);
                    screenManager.m248.SetActive(false);
                    screenManager.m24a.SetActive(false);
                    break;
                case 10://2-4-0
                    screenManager.m24a.SetActive(true);
                    screenManager.m249.SetActive(false);
                    screenManager.m24b.SetActive(false);
                    break;
                case 11://2-4-0
                    screenManager.m24b.SetActive(true);
                    screenManager.m24a.SetActive(false);
                    screenManager.m24c.SetActive(false);
                    break;
                case 12://2-4-0
                    screenManager.m24c.SetActive(true);
                    screenManager.m24b.SetActive(false);
                    screenManager.m24d.SetActive(false);
                    break;
                case 13://2-4-0
                    screenManager.m24d.SetActive(true);
                    screenManager.m24c.SetActive(false);
                    screenManager.m24e.SetActive(false);
                    break;
                case 14://2-4-0
                    screenManager.m24e.SetActive(true);
                    screenManager.m24d.SetActive(false);
                    screenManager.m24f.SetActive(false);
                    break;
                case 15://2-4-0
                    screenManager.m24f.SetActive(true);
                    screenManager.m24e.SetActive(false);
                    screenManager.m24h.SetActive(false);
                    break;
                case 16://2-4-0
                    screenManager.m24h.SetActive(true);
                    screenManager.m24f.SetActive(false);
                    screenManager.m24i.SetActive(false);
                    break;
                case 17://2-4-0
                    screenManager.m24i.SetActive(true);
                    screenManager.m24h.SetActive(false);
                    screenManager.m240.SetActive(false);
                    break;

            }
        }

        if (mode.maintenanceMode4  && !inMode4a && !inMode4h &&  !inMode4hf)
        {
            switch (menuSelector4)
            {
                case 0:
                    screenManager.hand.SetActive(true);
                    screenManager.auto.SetActive(false);
                    break;
                case 1:
                    screenManager.hand.SetActive(false);
                    screenManager.auto.SetActive(true);
                    break;
            }
        }

        if (mode.maintenanceMode2_0)
        {
            switch(menuSelector2_0)
            {
                case 0:
                    
                    screenManager.m2_00.SetActive(true);
                    screenManager.m2_01.SetActive(false);
                    break;

                case 1:
                    
                    screenManager.m2_00.SetActive(false);
                    screenManager.m2_01.SetActive(true);
                    break;
            }
                
        }

        if (mode.maintenanceMode2_0Menu && !buttons.menu)
        {
            switch(menuSelector2_0Menu)
            {
                case 0:
                    screenManager.dot.DotsControl(false, false, false, true);
                    screenManager.cOff.SetActive(true);
                    screenManager.cOn.SetActive(false);
                    break;
                case 1:
                    screenManager.dot.DotsControl(false, false, false, true);
                    screenManager.cOff.SetActive(false);
                    screenManager.cOn.SetActive(true);
                    break;
            }
        }
        ////////////////////////////////////////////////////////////////////////
    }

    public void In2_2Manual()
    {
        //GasOut();
        screenManager.blinkingScreen = true;
    }

    public void Conn()    /////test 
    {
        screenManager.dataObj.SetActive(true);
        screenManager.dot.DotsControl(false, true, false, false);
    }



    public void InMode13()
    {
        screenManager.scores.SetActive(true);
    }

    public void InMode21()
    {
        screenManager.dot.DotsControl(false, true, false, false);
        screenManager.dataObj.SetActive(true);
        screenManager.C4H10.Value = Random.Range(00, 50);
    }

    public void InMode22()
    {
        gasNumber = Random.Range(450, 650);
        //gasIn = true;
        //screenManager.blinkingScreen = true;           /// den prepei na anavosvinei
        screenManager.dataObj.SetActive(true);
        screenManager.dot.DotsControl(false, true, false, false);
        screenManager.C4H10.Value = 0f;
        screenManager.bottleC4H10.SetActive(true);
    }

    public void InMode24ha()
    {
        screenManager.C4H10.Value = mode.current;
        screenManager.dataObj.SetActive(true);
        inAuto = true;
        error.error1 = false;
        error.error2 = false;
    }

    public void InMode24hh()
    {
        //////////////////////////na valw ifs an ola kala kalo reuma an oxi na paizei ektos
        
        if (error.error1 || error.error2 )
        {
            getFixHand = true;
            screenManager.C4H10.Value = Random.Range(2150, 2250);
            screenManager.dataObj.SetActive(true);
            inHand = true;
        }

        if (!error.error1 && !error.error2)
        {
            getFixHand = true;
            screenManager.C4H10.Value = mode.current;
            screenManager.dataObj.SetActive(true);
            inHand = true;
            
        }

        
    }

    public void AutoFix()
    {
        if (autoTimer < 1.5)
        {
            screenManager.dataObj.SetActive(false);
            screenManager.pass.SetActive(true);
        }
        if (autoTimer <0)
        {

            screenManager.pass.SetActive(false);
        }
    }

    public void CalZero()
    {
        if (calTimer > 2.5f)
        {
            screenManager.cal.SetActive(true);
            screenManager.dot.DotsControl(true, false, false, false);
            screenManager.dataObj.SetActive(false);
        }

        if (calTimer < 2.5f)
        {
            screenManager.cal.SetActive(false);
            screenManager.pass.SetActive(true);
            screenManager.dot.DotsControl(false, false, false, false);
        }

        if (calTimer <0)
        {
            screenManager.cal.SetActive(false);
            screenManager.pass.SetActive(false);
            screenManager.dataObj.SetActive(false);
        }
    }

    public void CircleMenuUp()
    {
        menuSelector += 1;
        if (menuSelector == 4)
        {
            menuSelector = 0;
        }
    }
    public void CircleMenuDown()
    {
        menuSelector -= 1;
        if (menuSelector == -1)
        {
            menuSelector = 3;
        }
    }

    public void CircleMenuUp2()
    {
        menuSelector2 += 1;
        if (menuSelector2 == 8)
        {
            menuSelector2 = 0;
        }
    }
    public void CircleMenuDown2()
    {
        menuSelector2 -= 1;
        if (menuSelector2 == -1)
        {
            menuSelector2 = 7;
        }
    }

    public void CircleMenuUp3()
    {
        menuSelector3 += 1;
        if (menuSelector3 == 18)
        {
            menuSelector3 = 0;
        }
    }
    public void CircleMenuDown3()
    {
        menuSelector3 -= 1;
        if (menuSelector3 == -1)
        {
            menuSelector3 = 17;
        }
    }

    public void CircleMenuUp4()
    {
        menuSelector4 += 1;
        if (menuSelector4 == 2)
        {
            menuSelector4 = 0;
        }
    }
    public void CircleMenuDown4()
    {
        menuSelector4 -= 1;
        if (menuSelector4 == -1)
        {
            menuSelector4 = 1;
        }
    }

    public void CircleMenuUp2_0()
    {
        menuSelector2_0 += 1;
        if(menuSelector2_0 == 2)
        {
            menuSelector2_0 = 0;
        }
    }
    public void CircleMenuDown2_0()
    {
        menuSelector2_0 -= 1;
        if (menuSelector2_0 == -1)
        {
            menuSelector2_0 = 1;
        }
    }

    public void CircleMenuUp2_0Menu()
    {
        menuSelector2_0Menu += 1;
        if (menuSelector2_0Menu == 2)
        {
            menuSelector2_0Menu = 0;
        }
    }
    public void CircleMenuDown2_0Menu()
    {
        menuSelector2_0Menu -= 1;
        if (menuSelector2_0Menu == -1)
        {
            menuSelector2_0Menu = 1;
        }
    }

    public void ClearScreen()
    {
        if (in2_2Manual)
        {
            screenManager.dataObj.SetActive(false);
            screenManager.blinkingScreen = false;
            in2_2Manual = false;
        }

        if (mode.Conn) ///////////// test
        {
            screenManager.cOn.SetActive(false);
            screenManager.dot.DotsControl(false, false, false, false);
        }

        if (menuSelector2_0Menu == 0 || menuSelector2_0Menu == 1)
        {
            screenManager.cOff.SetActive(false);
            screenManager.cOn.SetActive(false);
            screenManager.dot.DotsControl(false, false, false, false);

        }

        if (menuSelector2_0 == 0 || menuSelector2_0 == 1)
        {
            screenManager.dot.DotsControl(false, false, false, false);
            screenManager.m2_00.SetActive(false);
            screenManager.m2_01.SetActive(false);
        }

        if (menuSelector2 == 0)
        {
            screenManager.m20.SetActive(false);
        }

        if (menuSelector2_0 == 1)
        {
            screenManager.m2_01.SetActive(false);
        }

        if (menuSelector2==1)
        {
            screenManager.m21.SetActive(false);
        }
        if (menuSelector2 == 1  && inCalZero)
        {
            screenManager.dot.DotsControl(false, false, false, false);
            screenManager.dataObj.SetActive(false);
            screenManager.C4H10.Value = 0;
        }
        if (menuSelector2 == 2)
        {
            screenManager.m22.SetActive(false);
            screenManager.dot.DotsControl(false, true, false, false);    // test
        }
        if (gasInDone && (screenManager.C4H10.Value > 480 && screenManager.C4H10.Value < 520))
        {
            screenManager.blinkingScreen = false;
            screenManager.bottleC4H10.SetActive(false);
            screenManager.dataObj.SetActive(false);
            screenManager.C4H10.Value = 0;
        }
        if (menuSelector2 == 4)
        {
            screenManager.m24.SetActive(false);
        }
        if (menuSelector3 == 16)
        {
            screenManager.m24h.SetActive(false);
        }
        if (menuSelector4 == 1)
        {
            screenManager.auto.SetActive(false);
        }  
        if (menuSelector4 == 0)
        {
            screenManager.hand.SetActive(false);
        }

        /*if (inAuto)
        {
            screenManager.dataObj.SetActive(false);
            screenManager.C4H10.Value = 0;
        }*/
    }

    public void Gased()
    {

        if (gasNumber > screenManager.C4H10.Value)
        {
            screenManager.C4H10.Value += Random.Range(10, 35.5f);
        }

        if (gasNumber < screenManager.C4H10.Value)
        {
            gasInDone = true;
            gasIn = false;
        }
    }

    public void GasIn()
    {
        gasIn = true;
    }

    public void GasOut()
    {
        gasIn = false;
    }
}
