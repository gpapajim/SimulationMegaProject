using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPressSD : MonoBehaviour
{
    public ModeManagerSD mode;
    public MenuModeSD maintenance;
    public ScreenManagerSD screen;
    public NormalModeSd1rdi normal;
    public Error error;

    public bool menu;
    public bool set;
    public bool up;
    public bool down;

    public bool dots;
    public bool fastPlus;

    public float dotsTimer;

    public float plusTimer;
    public float plusFastTimer;

    public void Start()
    {
        dotsTimer = 0.4f;
        plusTimer = 1.5f;
        plusFastTimer = 5f;
    }

    public void Update()
    {
        /////////////////////////////dots show on press control
        if (menu)
        {
            dotsTimer -= Time.deltaTime;
        }

        if (dotsTimer<0)
        {
            if (mode.maintenanceMode3)
            {
                screen.dot.DotsControl(true, true, true, true);
            }
            if (!mode.maintenanceMode3)
            {
                screen.dot.DotsControl(true, true, true, true);
            }
            
            dotsTimer = 0.4f;
        }

        if (!menu)
        {
            dotsTimer = 0.4f;
        }
        /////////////////////////////////+-10 timer
        if ((maintenance.inMode4h || mode.Conn || maintenance.in2_2Manual) && up)
        {
            plusTimer -= Time.deltaTime;
            plusFastTimer -= Time.deltaTime;
        }
        if (plusTimer < 0 && !fastPlus)
        {
            GasPlus10();
            plusTimer = 1f;
        }
        if (plusFastTimer < 0)
        {
            fastPlus = true;
            GasPlus50();
            plusFastTimer = 1f;
        }

        if ((maintenance.inMode4h || mode.Conn || maintenance.in2_2Manual) && down)
        {
            plusTimer -= Time.deltaTime;
            plusFastTimer -= Time.deltaTime;
        }
        if (plusTimer < 0 && !fastPlus)
        {
            GasMinus10();
            plusTimer = 1f;
        }
        if (plusFastTimer < 0)
        {
            fastPlus = true;
            GasMinus50();
            plusFastTimer = 1f;
        }

        if (!up && !down)
        {
            fastPlus = false;
            plusTimer = 1.5f;
            plusFastTimer = 5f;
        }
        ///////////////////////////////////////////
       
    }


    public void Up()
    {
        up = true;
        /////////////////////////////maintence
        if (mode.maintenanceMode && !maintenance.inMode)
        {
            maintenance.CircleMenuUp();
        }
        /////////////////////////////////////maintenance2
        if (mode.maintenanceMode2 && !maintenance.inMode && !maintenance.inMode2)
        {
            maintenance.CircleMenuUp2();
        }
        ////////////////////////////////////maintenance3
        if (mode.maintenanceMode3 && !maintenance.inMode && !maintenance.inMode2 && !maintenance.inMode3)
        {
            maintenance.CircleMenuUp3();
        }
        ///////////////////////////////////maintenance4
        if (mode.maintenanceMode4 && !maintenance.inMode && !maintenance.inMode2 && !maintenance.inMode3 && !maintenance.inMode4hf)
        {
            maintenance.CircleMenuUp4();
        }

        ///////////////////////////////////maintenance2_0
        if (mode.maintenanceMode2_0)
        {
            maintenance.CircleMenuUp2_0();
        }

        if (mode.maintenanceMode2_0Menu)
        {
            maintenance.CircleMenuUp2_0Menu();
        }
        /////////////////////////////////////gas in done
        if (mode.Conn)
        {
            screen.C4H10.Value += 1;
        }

        if (maintenance.in2_2Manual)
        {
            screen.C4H10.Value += 1;
        }

        if (maintenance.inMode4hf)
        {
            screen.C4H10.Value += 1;
        }
    }

    public void UpNo()
    {
        up = false;
    }

    public void Down()
    {
        down = true;
        /////////////////////////////maintenace
        if (mode.maintenanceMode && !maintenance.inMode)
        {
            maintenance.CircleMenuDown();
        }
        ////////////////////////////////maintenace2
        if (mode.maintenanceMode2 && !maintenance.inMode && !maintenance.inMode2)
        {
            maintenance.CircleMenuDown2();
        }
        ////////////////////////////////maintenance3
        if (mode.maintenanceMode3 && !maintenance.inMode && !maintenance.inMode2 && !maintenance.inMode3)
        {
            maintenance.CircleMenuDown3();
        }
        ///////////////////////////////maintenance4
        if (mode.maintenanceMode4 && !maintenance.inMode && !maintenance.inMode2 && !maintenance.inMode3 && !maintenance.inMode4hf) 
        {
            maintenance.CircleMenuDown4();
        }

        ///////////////////////////////////maintenance2_0
        if (mode.maintenanceMode2_0)
        {
            maintenance.CircleMenuDown2_0();
        }

        if (mode.maintenanceMode2_0Menu)
        {
            maintenance.CircleMenuDown2_0Menu();
        }
        /////////////////////////////////////gas in done
        if (mode.Conn)
        {
            screen.C4H10.Value -= 1;
        }

        if (maintenance.in2_2Manual)
        {
            screen.C4H10.Value -= 1;
        }

        if (maintenance.inMode4hf)
        {
            screen.C4H10.Value -= 1;
        }
    }

    public void DownNo()
    {
        down = false;
    }

    public void Set()
    {
        set = true;
        ////////////////////////////1-3
        if (maintenance.menuSelector == 3 && !maintenance.inMode && !maintenance.inMode2)
        {
            maintenance.getInMode = true;
            //maintenance.InMode13();
        }
        ////////////////////////////2-1
        if (maintenance.menuSelector2 == 1 && !maintenance.inMode2 && !maintenance.inMode)
        {
            maintenance.getInMode = true;
        }

        if (maintenance.menuSelector2 == 1 && maintenance.inMode2)
        {
            maintenance.inMode2 = false;
            maintenance.inCalZero = true;
        }
        ///////////////////////////2-0.0
        if (maintenance.menuSelector2 == 0 && mode.maintenanceMode2)
        {
            maintenance.ClearScreen();
            mode.maintenanceMode2 = false;
            mode.maintenanceMode2_0 = true;
            maintenance.menuSelector2_0 = 0;
            screen.dot.DotsControl(false, true, false, false);
        }
        if (maintenance.menuSelector2_0 == 1 && mode.maintenanceMode2_0)
        {
            maintenance.ClearScreen();
            mode.maintenanceMode2_0 = false;
            mode.maintenanceMode2_0Menu = true;
            //screen.dot.DotsControl(false, true, false, false);
            return;
        }
        ///////// Conn
        if (mode.maintenanceMode2_0Menu && maintenance.menuSelector2_0Menu == 1)
        {
            mode.Conn = true;
            mode.maintenanceMode2_0Menu = false;
            maintenance.ClearScreen();
            maintenance.Conn();
        }

        ///////////////////////////2-2
        if (maintenance.menuSelector2 == 2 && !maintenance.inMode2 && !maintenance.inMode && !maintenance.in2_2Manual)
        {
            maintenance.getInMode = true;
        }
        /////////////////////2-2 manual
        if (maintenance.inMode2 && maintenance.menuSelector2 == 2)
        {
            maintenance.in2_2Manual = true;
            maintenance.inMode2 = false;
            return;
        }
        if (maintenance.in2_2Manual && (screen.C4H10.Value > 480 && screen.C4H10.Value < 520))  //// den xreiazetai na to perimenei
        {
            maintenance.inCalZero = true;
            //maintenance.in2_2Manual = false;
            screen.dataObj.SetActive(false);
            screen.blinkingScreen = false;
            maintenance.inMode2 = false;
            maintenance.ClearScreen();
            return;
        }                                 

        ///////////////////////////2-4
        if (maintenance.menuSelector2 == 4 && !maintenance.inMode2 && !maintenance.inMode)
        {
            maintenance.getInMode = true;
        }
        ///////////////////////////2-4-h
        if (maintenance.menuSelector3 == 16)
        {
            maintenance.getInMode = true;
        }
        ///////////////////////////2-4-h-a
        if (maintenance.menuSelector4 == 1)
        {
            maintenance.getInMode = true;
        }
        ///////////////////////////2-4-h-h
        if (maintenance.menuSelector4 == 0 && maintenance.inMode4 && !maintenance.inMode4hf)
        {
            maintenance.inMode4h = true;
            maintenance.InMode24hh();
            maintenance.ClearScreen();
        }
        if (maintenance.inMode4hf && (screen.C4H10.Value > 1949 && screen.C4H10.Value < 2051))
        {
            maintenance.inMode4 = false;
            mode.maintenanceMode4 = false;
            mode.maintenanceMode3 = true;
            error.error1 = false;
            error.error2 = false;
            mode.current = int.Parse(screen.data.text);
            maintenance.menuSelector4 = 0;
            normal.CleanScreen();
        }
    }

    public void SetNo()
    {
        set = false;
    }

    public void Menu()
    {
        menu = true;

        
    }

    public void MenuNo()
    {
        menu = false;
        
        if (maintenance.in2_2Manual)
        {
            screen.blinkingScreen = false;
            maintenance.in2_2Manual = false;
            maintenance.inMode2 = true;
            screen.dataObj.SetActive(true);
            screen.dot.DotsControl(false, true, false, false);
            return;
        }

        if (mode.Conn) ///test
        {
            normal.CleanScreen();
            screen.C4H10.Value = 0;
            mode.Conn = false;
            mode.maintenanceMode2_0 = true;
            maintenance.menuSelector2_0Menu = 0;
            screen.dot.DotsControl(false, true, false, false);
            screen.lights.AlarmLightOff();
            return;
        }

        if (mode.maintenanceMode2_0Menu)
        {
            normal.CleanScreen();
            mode.maintenanceMode2_0 = true;
            mode.maintenanceMode2_0Menu = false;
            maintenance.menuSelector2_0Menu = 0;
            screen.dot.DotsControl(false, true, false, false);
            return;
        }

        if (mode.maintenanceMode2_0)
        {
            mode.maintenanceMode2 = true;
            mode.maintenanceMode2_0 = false;
            normal.CleanScreen(); 
            return;
        }

        if (!mode.normalMode)
        {
            screen.dot.DotsControl(false, false, false, false);
            
        }

        if (mode.normalMode && error.error1)
        {
            screen.dot.DotsControl(false, false, false, false);
        }

        if (mode.normalMode && ! error.error1)
        {
            screen.dot.DotsControl(false, true, false, false);
        }

        if (maintenance.inMode)
        {
            maintenance.inMode = false;
            mode.maintenanceMode = true;
            normal.CleanScreen();
        }


        if (mode.maintenanceMode2)
        {
            if (maintenance.inMode2)
            {
                maintenance.gasIn = false;
                maintenance.gasInDone = false;
                screen.blinkingScreen = false;
                screen.bottleC4H10.SetActive(false);
                normal.CleanScreen();
                return;
            }

            if (!maintenance.inMode2)
            {
                maintenance.menuSelector2 = 0;
                mode.maintenanceMode2 = false;
                mode.maintenanceMode = true;
                maintenance.gasIn = false;
                maintenance.gasInDone = false;
                screen.blinkingScreen = false;
                screen.bottleC4H10.SetActive(false);
                normal.CleanScreen();
            }
        }

        /*if (mode.maintenanceMode2 && maintenance.inMode2)
        {
            maintenance.gasIn = false;
            maintenance.gasInDone = false;
            screen.blinkingScreen = false;
            screen.bottleC4H10.SetActive(false);
            normal.CleanScreen();
        }

        if (mode.maintenanceMode2 && !maintenance.inMode2)
        {
            mode.maintenanceMode2 = false;
            mode.maintenanceMode = true;
            maintenance.gasIn = false;
            maintenance.gasInDone = false;
            screen.blinkingScreen = false;
            screen.bottleC4H10.SetActive(false);
            normal.CleanScreen();
        }*/

        if (mode.maintenanceMode3)
        {
            mode.maintenanceMode3 = false;
            mode.maintenanceMode2 = true;
            maintenance.menuSelector3 = 0;
            normal.CleanScreen();
        }
        if (mode.maintenanceMode4 && !maintenance.inMode4a && !maintenance.inMode4h)
        {
            mode.maintenanceMode4 = false;
            mode.maintenanceMode3 = true;
            maintenance.menuSelector4 = 0;
            normal.CleanScreen();
            screen.dot.DotsControl(false, true, false, false);

        }

        if (mode.maintenanceMode4 && maintenance.inMode4h)
        {
            maintenance.inHand = false;
            maintenance.inMode4h = false;
            maintenance.inMode4hf = false;
            screen.dataObj.SetActive(false);
            
        }
    }

    public void GasPlus10()
    {
        screen.C4H10.Value += 10;
    }

    public void GasMinus10()
    {
        screen.C4H10.Value -= 10;
    }

    public void GasPlus50()
    {
        screen.C4H10.Value += 50;
    }

    public void GasMinus50()
    {
        screen.C4H10.Value -= 50;
    }

}
