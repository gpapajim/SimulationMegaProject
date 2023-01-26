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
                screen.dot.DotsControl(true, false, true, true);
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
        if ((maintenance.gasInDone || maintenance.gasIn || maintenance.inMode4h) && up)
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

        if ((maintenance.gasInDone || maintenance.gasIn || maintenance.inMode4h) && down)
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
        /////////////////////////////////////gas in done
        if (maintenance.gasInDone || maintenance.gasIn)
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
        /////////////////////////////////////gas in done
        if (maintenance.gasInDone || maintenance.gasIn)
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
        
        if (maintenance.menuSelector2 == 1 && maintenance.inMode2 )
        {
            maintenance.inMode2 = false;
            maintenance.inCalZero = true;
        }
        ///////////////////////////2-2
        if (maintenance.menuSelector2 == 2 && !maintenance.inMode2 && !maintenance.inMode)
        {
            maintenance.getInMode = true;
        }
        if (maintenance.gasInDone && (screen.C4H10.Value > 480 && screen.C4H10.Value <520))
        {
            maintenance.ClearScreen();
            maintenance.inCalZero = true;    
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
