using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalibrationMenu8000 : MonoBehaviour
{
    public DeviceState8000 deviceState;
    public ScreenManager8000 screenManager;
    public ButtonManager8000 buttonManager;
    public StartingSq8000 startingSq;
    public GameObject bottleVol;
    public GameObject bottleSm;
    public GameObject bottleN;
    public int upDown;
    

    [Header("menu selector")]
    public int menuSelector;
    public int oneCalMenuSelector;

    [Header("checkers")]
    public bool timer;
    public bool timerDone;
    public bool blink;
    public bool oneCalMenu;
    public bool inGas;
    public float pushFast;

    [Header("timers")]
    public float w8Timer;
    public float blinkTimer;



    public void Awake()
    {
        w8Timer = 0.5f;
        blinkTimer = 1.5f;
    }

    public void Update()
    {
        if(deviceState.normalMode==true && buttonManager.D==true && buttonManager.R==true)
        {
            deviceState.normalMode = false;
            deviceState.menu = true;
            menuSelector = 0;
        }

        if(deviceState.menu==true && Input.GetKeyDown(buttonManager.air) &! deviceState.inMode)
        {
            MenuScroll(true, true, false);
        }
        if(deviceState.menu==true && Input.GetKeyDown(buttonManager.reset) &! deviceState.inMode)
        {
            MenuScroll(true, false, true);
        }

        if(deviceState.menu==true)
        {
            Menu();
        }

        if(deviceState.airCal == true)
        {
            InAirCal();
        }

        ///////////////////////////////////////volzcal
        if (deviceState.volZCal)
        {
            timer = true;

            bottleN.SetActive(true);

            screenManager.o2.Value = 0.2f;
            screenManager.hc.Value = 0f;
            startingSq.GasNames(true, true, false, false);
            startingSq.GasNumbers(true, true, false, false, screenManager.hc.Value, screenManager.o2.Value, screenManager.co.Value, screenManager.h2s.Value);
            screenManager.hcLel.SetActive(false);
            blink = true;
        }

        if (blink)
        {
            blinkTimer -= Time.deltaTime;
        }

        if (blinkTimer<0.7f)
        {
            screenManager.hcVol.SetActive(false);
            startingSq.MenuMessage(false, "");
        }

        if (blinkTimer<0)
        {
            screenManager.hcVol.SetActive(true);
            startingSq.MenuMessage(true, "VOL Z.CAL");
            blinkTimer = 1.5f;
        }


        if (w8Timer<0 && deviceState.volZCal && Input.GetKeyDown(buttonManager.power))
        {
            bottleN.SetActive(false);

            deviceState.volZCal = false;
            blinkTimer = 1.5f;
            startingSq.GasNames(false, false, false, false);
            startingSq.MenuMessage(true, "VOL Z.CAL");
            screenManager.hcLel.SetActive(true);
            blink = false;
            deviceState.inMode = false;
            timer = false;
            w8Timer = 0.5f;


        }

       /* if (w8Timer<0 && deviceState.volZCal)
        {
            blink = false;
            blinkTimer = 1.5f;
            deviceState.volZCal = false;
            startingSq.GasNames(false, false, false, false);
            startingSq.MenuMessage(true, "VOL Z.CAL");
            deviceState.inMode = false;
            screenManager.hcLel.SetActive(true);
            timer = false;
            w8Timer = 0.5f;
        }*/


        /////////////////////////////////////
     
        /////////////////////////////////////gased
        
        

       
        
        ////////////////////////////////////

        /////////////////////////////////////one cal
        

        if (deviceState.oneCal)
        {
            bottleSm.SetActive(true);
            bottleVol.SetActive(true);
        }

        if (!deviceState.oneCal)
        {
            bottleSm.SetActive(false);
            bottleVol.SetActive(false);
        }


        if (oneCalMenu)
        {
            timer = true;
        }
        
        if (oneCalMenu && Input.GetKeyDown(buttonManager.reset) &! inGas)
        {
            OneCalMenuScroll(true, false);
        }

        if (oneCalMenu && Input.GetKeyDown(buttonManager.air) &! inGas)
        {
            OneCalMenuScroll(false, true);
        }

        if (oneCalMenu)
        {
            OneCalMenu();
        }

       

        if (oneCalMenu)
        {
            timer = true;
            
        }

        if (oneCalMenu && oneCalMenuSelector == 0 && Input.GetKeyDown(buttonManager.power) && w8Timer<0)
        {
            
            inGas = true;
        }

        if (inGas && oneCalMenuSelector == 0)
        {
            screenManager.barHc.SetActive(false);
            startingSq.GasNumbers(true, false, false, false, screenManager.hc.Value, screenManager.o2.Value, screenManager.co.Value, screenManager.h2s.Value);
            ResetTimer();
        }
        if (oneCalMenu && oneCalMenuSelector == 1 && Input.GetKeyDown(buttonManager.power) && w8Timer < 0)
        {

            inGas = true;
        }

        if (inGas && oneCalMenuSelector == 1)
        {
            screenManager.barHc.SetActive(false);
            startingSq.GasNumbers(true, false, false, false, screenManager.hc.Value, screenManager.o2.Value, screenManager.co.Value, screenManager.h2s.Value);
            ResetTimer();
        }

        if (oneCalMenu && oneCalMenuSelector == 2 && Input.GetKeyDown(buttonManager.power) && w8Timer < 0)
        {

            inGas = true;
        }

        if (inGas && oneCalMenuSelector == 2)
        {
            screenManager.barO2.SetActive(false);
            startingSq.GasNumbers(false, true, false, false, screenManager.hc.Value, screenManager.o2.Value, screenManager.co.Value, screenManager.h2s.Value);
            ResetTimer();
        }

        if (oneCalMenu && oneCalMenuSelector == 3 && Input.GetKeyDown(buttonManager.power) && w8Timer < 0)
        {

            inGas = true;
        }

        if (inGas && oneCalMenuSelector == 3)
        {
            screenManager.barH2s.SetActive(false);
            startingSq.GasNumbers(false, false, false, true, screenManager.hc.Value, screenManager.o2.Value, screenManager.co.Value, screenManager.h2s.Value);
            ResetTimer();
        }

        if (oneCalMenu && oneCalMenuSelector == 4 && Input.GetKeyDown(buttonManager.power) && w8Timer < 0)
        {

            inGas = true;
        }

        if (inGas && oneCalMenuSelector == 4)
        {
            screenManager.barCo.SetActive(false);
            startingSq.GasNumbers(false, false, true, false, screenManager.hc.Value, screenManager.o2.Value, screenManager.co.Value, screenManager.h2s.Value);
            ResetTimer();
        }

        if (oneCalMenu && oneCalMenuSelector == 5 && Input.GetKeyDown(buttonManager.power) && w8Timer < 0)
        {
            bottleSm.SetActive(false);
            bottleVol.SetActive(false);
            startingSq.MenuMessage(true, "ONE CAL");
            deviceState.inMode = true;
            deviceState.oneCal = false;
            oneCalMenu = false;
            screenManager.bottleVol.SetActive(true);
            screenManager.bottleLel.SetActive(true);
            deviceState.menu = true;
            deviceState.inMode = false;
            oneCalMenuSelector = 0;
            timer = false;
            w8Timer = 0.5f;
        }

        if (inGas && oneCalMenuSelector == 0)
        {
            if(Input.GetKeyDown(buttonManager.power) && (screenManager.hc.Value<53 && screenManager.hc.Value>48))
            {
                inGas = false;
                screenManager.barHc.SetActive(true);
                startingSq.GasNumbers(false, false, false, false, screenManager.hc.Value, screenManager.o2.Value, screenManager.co.Value, screenManager.h2s.Value);
            }

            
        }

        if (inGas && oneCalMenuSelector == 1)
        {
            if (Input.GetKeyDown(buttonManager.power) && (screenManager.hc.Value < 53 && screenManager.hc.Value > 48))
            {
                inGas = false;
                screenManager.barHc.SetActive(true);
                startingSq.GasNumbers(false, false, false, false, screenManager.hc.Value, screenManager.o2.Value, screenManager.co.Value, screenManager.h2s.Value);
            }


        }

        if (inGas && oneCalMenuSelector == 2)
        {
            if (Input.GetKeyDown(buttonManager.power) && (screenManager.o2.Value < 14 && screenManager.o2.Value > 10))
            {
                inGas = false;
                screenManager.barO2.SetActive(true);
                startingSq.GasNumbers(false, false, false, false, screenManager.hc.Value, screenManager.o2.Value, screenManager.co.Value, screenManager.h2s.Value);
            }


        }

        if (inGas && oneCalMenuSelector == 3)
        {
            if (Input.GetKeyDown(buttonManager.power) && (screenManager.h2s.Value < 28 && screenManager.h2s.Value > 23))
            {
                inGas = false;
                screenManager.barH2s.SetActive(true);
                startingSq.GasNumbers(false, false, false, false, screenManager.hc.Value, screenManager.o2.Value, screenManager.co.Value, screenManager.h2s.Value);
            }


        }

        if (inGas && oneCalMenuSelector == 4)
        {
            if (Input.GetKeyDown(buttonManager.power) && (screenManager.co.Value < 53 && screenManager.co.Value > 48))
            {
                inGas = false;
                screenManager.barCo.SetActive(true);
                startingSq.GasNumbers(false, false, false, false, screenManager.hc.Value, screenManager.o2.Value, screenManager.co.Value, screenManager.h2s.Value);
            }


        }


        /////////////////////////////////////
        ///////////////////////////////////up - down gases



        if (Input.GetKeyDown(buttonManager.air) && inGas)
        {
            if (oneCalMenuSelector==0)
            {
                screenManager.hc.Value += 1;
            }
            if (oneCalMenuSelector == 1)
            {
                screenManager.hc.Value += 1;
            }
            if (oneCalMenuSelector == 2)
            {
                screenManager.o2.Value += 1;
            }
            if (oneCalMenuSelector == 3)
            {
                screenManager.h2s.Value += 1;
            }
            if (oneCalMenuSelector == 4)
            {
                screenManager.co.Value += 1;
            }
        }

        if(Input.GetKeyDown(buttonManager.reset) && inGas)

        {
            if (oneCalMenuSelector == 0)
            {
                screenManager.hc.Value -= 1;
            }
            if (oneCalMenuSelector == 1)
            {
                screenManager.hc.Value -= 1;
            }
            if (oneCalMenuSelector == 2)
            {
                screenManager.o2.Value -= 1;
            }
            if (oneCalMenuSelector == 3)
            {
                screenManager.h2s.Value -= 1;
            }
            if (oneCalMenuSelector == 4)
            {
                screenManager.co.Value -= 1;
            }
        }

        //////////////////////////////////



        if (timer==true)
        {
            w8Timer -= Time.deltaTime;
        }
    }

    public void OneCalMenu()
    {
        switch (oneCalMenuSelector)
        {
            case 0:
                startingSq.MenuMessage(true, "ONE CAL");
                screenManager.barHc.SetActive(true);
                screenManager.barO2.SetActive(false);
                screenManager.barCo.SetActive(false);
                screenManager.barH2s.SetActive(false);
                screenManager.meterHC.SetActive(true);
                screenManager.meterO2.SetActive(false);
                screenManager.meterCo.SetActive(false);
                screenManager.meterH2s.SetActive(false);
                startingSq.GasNames(true, false, false, false);
                screenManager.hcVol.SetActive(false);
                screenManager.hcLel.SetActive(true);
                break;
            case 1:
                startingSq.MenuMessage(true, "ONE CAL");
                screenManager.barHc.SetActive(true);
                screenManager.barO2.SetActive(false);
                screenManager.barCo.SetActive(false);
                screenManager.barH2s.SetActive(false);
                screenManager.meterHC.SetActive(true);
                screenManager.meterO2.SetActive(false);
                screenManager.meterCo.SetActive(false);
                screenManager.meterH2s.SetActive(false);
                startingSq.GasNames(true, false, false, false);
                screenManager.hcVol.SetActive(true);
                screenManager.hcLel.SetActive(false);
                break;
            case 2:
                startingSq.MenuMessage(true, "ONE CAL");
                screenManager.barHc.SetActive(false);
                screenManager.barO2.SetActive(true);
                screenManager.barCo.SetActive(false);
                screenManager.barH2s.SetActive(false);
                screenManager.meterHC.SetActive(false);
                screenManager.meterO2.SetActive(true);
                screenManager.meterCo.SetActive(false);
                screenManager.meterH2s.SetActive(false);
                startingSq.GasNames(false, true, false, false);
                screenManager.hcVol.SetActive(false);
                screenManager.hcLel.SetActive(false);
                break;
            case 3:
                startingSq.MenuMessage(true, "ONE CAL");
                screenManager.barHc.SetActive(false);
                screenManager.barO2.SetActive(false);
                screenManager.barCo.SetActive(false);
                screenManager.barH2s.SetActive(true);
                screenManager.meterHC.SetActive(false);
                screenManager.meterO2.SetActive(false);
                screenManager.meterCo.SetActive(false);
                screenManager.meterH2s.SetActive(true);
                startingSq.GasNames(false, false, false, true);
                screenManager.hcVol.SetActive(false);
                screenManager.hcLel.SetActive(false);
                break;
            case 4:
                startingSq.MenuMessage(true, "ONE CAL");
                screenManager.barHc.SetActive(false);
                screenManager.barO2.SetActive(false);
                screenManager.barCo.SetActive(true);
                screenManager.barH2s.SetActive(false);
                screenManager.meterHC.SetActive(false);
                screenManager.meterO2.SetActive(false);
                screenManager.meterCo.SetActive(true);
                screenManager.meterH2s.SetActive(false);
                startingSq.GasNames(false, false, true, false);
                screenManager.hcVol.SetActive(false);
                screenManager.hcLel.SetActive(false);
                break;
            case 5:
                startingSq.MenuMessage(true, "ESCAPE");
                screenManager.barHc.SetActive(false);
                screenManager.barO2.SetActive(false);
                screenManager.barCo.SetActive(false);
                screenManager.barH2s.SetActive(false);
                screenManager.meterHC.SetActive(false);
                screenManager.meterO2.SetActive(false);
                screenManager.meterCo.SetActive(false);
                screenManager.meterH2s.SetActive(false);
                startingSq.GasNames(false, false, false, false);
                screenManager.hcVol.SetActive(false);
                screenManager.hcLel.SetActive(false);
                break;
        }
    }


    public void Menu()
    {
        
        if(deviceState.inMode==false)
        {
            startingSq.TimeOff();
            startingSq.GasNames(false, false, false, false);
            startingSq.GasNumbers(false, false, false, false, screenManager.hc.Value, screenManager.o2.Value, screenManager.co.Value, screenManager.h2s.Value);
        }
        
        if(deviceState.noMode==false)
        {
            switch (menuSelector)
            {
                //prosthetw cases gia osa einai ta items sto menu kai prepei sta scroll na allaksw ta oria
                case 0:
                    startingSq.MenuMessage(true, "AIR CAL");
                    if (buttonManager.P == true)
                    {
                        deviceState.inMode = true;
                        deviceState.airCal = true;
                    }
                    break;
                case 1:
                    startingSq.MenuMessage(true, "VOL Z.CAL");
                    if (Input.GetKeyDown(buttonManager.power))
                    {
                        deviceState.inMode = true;
                        deviceState.volZCal = true;
                    }
                    break;
                case 2:
                    startingSq.MenuMessage(true, "AUTO CAL");
                    break;
                case 3:
                    startingSq.MenuMessage(true, "ONE CAL");
                    
                    if (Input.GetKeyDown(buttonManager.power))
                    {
                        deviceState.inMode = true;
                        deviceState.oneCal = true;
                        oneCalMenu = true;
                        

                        if(!inGas)
                        {
                            Gased();
                        }
                        
                        
                    }
                    if (Input.GetKeyDown(buttonManager.power))
                    {
                        
                       
                        
                    }
                    break;
                case 4:
                    startingSq.MenuMessage(true, "BUMP");
                    break;
                case 5:
                    startingSq.MenuMessage(true, "NORMAL");
                    if(buttonManager.P == true)
                    {
                        Return();
                    }
                    break;
                    /////////////////////////////////////////////////
            }
        }
    }

    public void MenuScroll(bool menu, bool air, bool reset)
    {
        if(menu==true)
        {
            if(air==true)
            {
                menuSelector -= 1;
            }
            if(reset==true)
            {
                menuSelector += 1;
            }
        }

        if(menuSelector==-1 && air==true)
        {
            menuSelector = 5;
        }
        if(menuSelector==6 && reset==true)
        {
            menuSelector = 0;
        }
    }

    public void OneCalMenuScroll(bool air, bool reset)
    {
        if (air)
        {
            oneCalMenuSelector -= 1;
        }
        if (reset)
        {
            oneCalMenuSelector += 1;
        }

        if (oneCalMenuSelector == -1 && air == true)
        {
            oneCalMenuSelector = 5;
        }
        if (oneCalMenuSelector == 6 && reset == true)
        {
            oneCalMenuSelector = 0;
        }
    }

    public void MenuScrollTouch(GameObject button)
    {
        if(deviceState.menu==true)
        {
            if (button.name == "Air")
            {
                menuSelector -= 1;
            }
            if (button.name == "Reset")
            {
                menuSelector += 1;
            }

            if (menuSelector == -1)
            {
                menuSelector = 2;
            }
            if (menuSelector == 3)
            {
                menuSelector = 0;
            }
        }  
    }

    public void InAirCal()
    {
        deviceState.noMode = true;
        startingSq.MenuMessage(true, "PUSH AIR");
        screenManager.bars.SetActive(true);
        startingSq.GasNames(true, true, true, true);
        startingSq.GasNumbers(true, true, true, true, 0, 20.9f, 0, 0);
        
    }

    public void Return()
    {
        
        
        deviceState.menu = false;
        deviceState.normalMode = true;
        startingSq.GasNumbers(true, true, true, true, screenManager.hc.Value, screenManager.o2.Value, screenManager.co.Value, screenManager.h2s.Value);
        screenManager.hc.Value = 0;
        screenManager.o2.Value = 20.9f;
        screenManager.h2s.Value = 0f;
        screenManager.co.Value = 0f;
        timer = false;
        ResetTimer();
    }


    public void ChangeNumbers()
    {
        if (oneCalMenuSelector == 0 &  pushFast > 0)
        {
            screenManager.hc.Value += 5;

        }
        if (oneCalMenuSelector == 0 &  pushFast < 0)
        {
            screenManager.hc.Value += 10;
        }

        if (oneCalMenuSelector == 1 & pushFast > 0)
        {
            screenManager.hc.Value += 5;

        }
        if (oneCalMenuSelector == 1 & pushFast < 0)
        {
            screenManager.hc.Value += 10;
        }


        if (oneCalMenuSelector == 2 & pushFast > 0)
        {
            screenManager.o2.Value += 5;

        }
        if (oneCalMenuSelector == 2 &  pushFast < 0)
        {
            screenManager.o2.Value += 10;
        }
        
        if (oneCalMenuSelector == 3 &  pushFast > 0)
        {
            screenManager.h2s.Value += 5;

        }
        if (oneCalMenuSelector == 3 &  pushFast < 0)
        {
            screenManager.h2s.Value += 10;
        }
       
        if (oneCalMenuSelector == 4 &  pushFast > 0)
        {
            screenManager.co.Value += 5;
        }
        if (oneCalMenuSelector == 4 &  pushFast < 0)
        {
            screenManager.co.Value +=10;
        }
        

    }

    public void ChangeNumbersDown()
    {
        if (oneCalMenuSelector == 0 & pushFast > 0)
        {
            screenManager.hc.Value -= 5;

        }
        if (oneCalMenuSelector == 0 & pushFast < 0)
        {
            screenManager.hc.Value -= 10;
        }

        if (oneCalMenuSelector == 1 & pushFast > 0)
        {
            screenManager.hc.Value -= 5;

        }
        if (oneCalMenuSelector == 1 & pushFast < 0)
        {
            screenManager.hc.Value -= 10;
        }


        if (oneCalMenuSelector == 2 & pushFast > 0)
        {
            screenManager.o2.Value -= 5;

        }
        if (oneCalMenuSelector == 2 & pushFast < 0)
        {
            screenManager.o2.Value -= 10;
        }

        if (oneCalMenuSelector == 3 & pushFast > 0)
        {
            screenManager.h2s.Value -= 5;

        }
        if (oneCalMenuSelector == 3 & pushFast < 0)
        {
            screenManager.h2s.Value -= 10;
        }

        if (oneCalMenuSelector == 4 & pushFast > 0)
        {
            screenManager.co.Value -= 5;
        }
        if (oneCalMenuSelector == 4 & pushFast < 0)
        {
            screenManager.co.Value -= 10;
        }
    }

    public void Gased()
    {
        bottleSm.SetActive(true);

        upDown = Random.Range(0, 2);

        if(upDown == 0)
        {
            screenManager.hc.Value = Random.Range(44, 49);
            screenManager.o2.Value = Random.Range(8,10);
            screenManager.co.Value = Random.Range(44,49);
            screenManager.h2s.Value = Random.Range(20, 24);
        }

        if(upDown ==1)
        {
            screenManager.hc.Value = Random.Range(53, 57);
            screenManager.o2.Value = Random.Range(13, 17);
            screenManager.co.Value = Random.Range(53, 57);
            screenManager.h2s.Value = Random.Range(27, 32);
        }

        
    }

    public void ResetTimer()
    {
        w8Timer = 0.5f;
    }
}
