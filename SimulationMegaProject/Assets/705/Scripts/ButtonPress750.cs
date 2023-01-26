using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPress750 : MonoBehaviour
{
    public ModeManager750 modeManager;
    public ScreenManager750 screenManager;
    public Bottle750 bottle705;

    [Header("timers")]
    public float Timer;
    [Header("press")]
    public bool maintenance;
    public bool set;
    public bool up;
    public bool down;

    


    public void Awake()
    {
       Timer = 3f;
    }


    public void Update()
    {
        /////////////////////////////////getting in menu
        if(maintenance==true)
        {
            Timer -= Time.deltaTime;
        }
        if (maintenance == false && modeManager.menuMode==false)///
        {
            Timer = 3f;
        }
        ////////////////////////////////
        
        //////////////////////////////////up-down in span
        if((up==true||down==true) && modeManager.span==true && modeManager.inMode==true)
        {
            Timer -= Time.deltaTime;
        }
        if((up == false && down == false) && modeManager.span == true && modeManager.inMode == true && maintenance == false)
        {
            Timer = 1f;
        }
        
        if(Timer<0 && modeManager.span == true && modeManager.inMode == true)
        {
            if(up==true)
            {
                GasPlus10();
            }
            if(down==true)
            {
                GasMinus10();
            }
            Timer = 1f;
        }
        /////////////////////////////////up-down in alarms + f1
        if((up==true||down==true) && (modeManager.al==true || modeManager.f1==true) && modeManager.inMode2==true)
        {
            Timer -= Time.deltaTime;
        }
        if((up == false && down == false) && (modeManager.al == true || modeManager.f1==true) && modeManager.inMode2 == true && maintenance == false)
        {
            Timer = 1f;
        }
        if (Timer < 0 && (modeManager.al == true || modeManager.f1 == true) && modeManager.inMode2 == true)
        {
            if (up == true)
            {
                GasPlus10();
            }
            if (down == true)
            {
                GasMinus10();
            }
            Timer = 1f;
        }
        //////////////////////////////////////////////
        
        ////////////////////////////////////////////up down in zero

        if ((up == true || down == true) && modeManager.zero==true && modeManager.inMode3 == true)
        {
            Timer -= Time.deltaTime;
        }
        if ((up == false && down == false) && modeManager.zero==true && modeManager.inMode3 == true && maintenance == false)
        {
            Timer = 1f;
        }
        if (Timer < 0 && modeManager.zero==true && modeManager.inMode3 == true)
        {
            if (up == true)
            {
                GasPlus10();
            }
            if (down == true)
            {
                GasMinus10();
            }
            Timer = 1f;
        }

        //////////////////////////////////////////////



        ///////////////////////////////////////////// getting in menu and out
        if (Timer<0 && modeManager.normalMode==true)
        {
            if(maintenance==true)
            {
                modeManager.menuMode = true;
                
            }
            Timer = 3f;
        }
        if(Timer<0 && modeManager.menuMode==true)
        {
            if(maintenance ==true && (modeManager.inMode2 == true||modeManager.inMode==true))
            {
                modeManager.inMode2 = false;
                modeManager.inMode = false;
            }
            else if(maintenance == true && (modeManager.inMode2 == false && modeManager.inMode==false))
            {
                modeManager.menuMode = false;
                modeManager.normalMode = true;
                
            }
            Timer = 3f;
        }
        /////////////////////////////////////////////////
    }
    
    ////////////////////////////////// button function
    
    public void Maintenance()
    {
        maintenance = true;
        Timer=3f;
    }
    public void MaintenanceOff()
    {
        maintenance = false;
        if (modeManager.al == true && modeManager.inMode2 == true)///////////
        {
            screenManager.al1New = screenManager.al1;
            screenManager.al2New = screenManager.al2;
        }
        if (modeManager.inMode2 == true)
        {
            modeManager.inMode2 = false;
        }
        if (modeManager.inMode == true)
        {
            modeManager.inMode = false;
        }
        if(modeManager.al1 ==true || modeManager.al2 == true)
        {
            modeManager.al1 = false;
            modeManager.al2 = false;
        }


    }

    public void Set()
    {
        set = true;
        if(modeManager.al==true && modeManager.inMode2==true)
        {
            screenManager.al1 = screenManager.al1New;
            screenManager.al2 = screenManager.al2New;
        }

        if (modeManager.span == true && modeManager.inMode == true && (screenManager.gas > 46 && screenManager.gas < 54))
        {
            screenManager.calOn = true;
            bottle705.gased = false;
            bottle705.timer = 1.2f;

        }

        if (modeManager.span == true && modeManager.inMode == true && (screenManager.gas < 47 || screenManager.gas > 53))
        {
            screenManager.failOn = true;
            screenManager.fail.SetActive(true);
            screenManager.normalMode.SetActive(false);
            bottle705.gased = false;
            bottle705.timer = 1.2f;
        }

        if(modeManager.f1==true && modeManager.inMode2 == true)
        {
            screenManager.f1Old = screenManager.f1New;
        }
        if(modeManager.f1==true && modeManager.inMode2 ==true && modeManager.zeroSet==1 && (screenManager.f1New > 2949 && screenManager.f1New < 3051))
        {
            screenManager.set = Random.Range(0, 6)*3-8;
            if(screenManager.set==0)
            {
                screenManager.set = 1;
            }
        }
        if (modeManager.zero==true && modeManager.inMode==true && (modeManager.zeroSet==1||modeManager.zeroSet==0) && (screenManager.f1New > 2949 && screenManager.f1New < 3051))
        {
            screenManager.set = 0;
            modeManager.zeroSet = 0;
        }
        /*if(modeManager.f1==true && modeManager.inMode2)
        {
            modeManager.inMode2 = false;
            modeManager.inMode = true;
            return;
        }*/
        if(modeManager.inMode3==true)
        {
            modeManager.inMode = true;
            modeManager.inMode2 = false;
            modeManager.inMode3 = false;
            return;
        }
        if(modeManager.inMode2 == true && modeManager.zero == true)
        {
            modeManager.inMode3 = true;
            modeManager.inMode2 = false;
            modeManager.inMode = false;
            return;
        }
        if (modeManager.menuMode == true && modeManager.inMode == false)///it had to be below specific mode sets
        {
            modeManager.inMode = true;
            modeManager.inMode2 = false;
            return;
        }
        if(modeManager.inMode==true)
        {
            modeManager.inMode2 = true;
            modeManager.inMode = false;
        }
       
        
    }
    public void SetOff()
    {
        set = false;
    }

    public void Up()
    {
        up = true;
        if(modeManager.menuMode==true && modeManager.inMode==true)
        {
            Timer = 1f;
        }
        if(modeManager.menuMode==true && modeManager.al==true && modeManager.inMode2==true)
        {
            Timer = 1f;
        }
        if (modeManager.menuMode == true && modeManager.inMode == false && modeManager.inMode2 == false && modeManager.inMode3 == false)
        {
            modeManager.CircleMenuUp();
        }
        if(modeManager.menuMode == true && modeManager.al == true && modeManager.inMode == true)
        {
            modeManager.CircleAlarmUp();

        }
    }
    public void UpOff()
    {
        up = false;
        if (modeManager.menuMode == true && modeManager.span == true && modeManager.inMode==true)
        {
            screenManager.gas += 1;
        }
        if (modeManager.menuMode == true && modeManager.al == true && modeManager.al1 == true && modeManager.inMode2 == true)
        {
            screenManager.al1New += 1;
        }
        if (modeManager.menuMode == true && modeManager.al == true && modeManager.al2 == true && modeManager.inMode2 == true)
        {
            screenManager.al2New += 1;
        }
        if(modeManager.menuMode == true && modeManager.zero == true && modeManager.inMode3 == true)
        {
            screenManager.f1New += 1;
        }
    }

    public void Down()
    {
        down = true;
        if (modeManager.menuMode == true && modeManager.inMode == false && modeManager.inMode2 == false && modeManager.inMode3 == false)
        {
            modeManager.CircleMenuDown();
        }
        if(modeManager.menuMode == true && modeManager.inMode == true)
        {
            Timer = 1f;
        }
        if(modeManager.menuMode == true && modeManager.al == true && modeManager.inMode2 == true)
        {
            Timer = 1f;
        }
        if (modeManager.menuMode == true && modeManager.al == true &&  modeManager.inMode == true)
        {
            modeManager.CircleAlarmDown();
        }
    }
    public void DownOff()
    {
        down = false;
        if (modeManager.menuMode == true && modeManager.span == true && modeManager.inMode==true)
        {
            screenManager.gas -= 1;
        }
        if (modeManager.menuMode == true && modeManager.al == true && modeManager.al1 == true && modeManager.inMode2 == true)
        {
            screenManager.al1New -= 1;
        }
        if (modeManager.menuMode == true && modeManager.al == true && modeManager.al2 == true && modeManager.inMode2 == true)
        {
            screenManager.al2New -= 1;
        }
        if (modeManager.menuMode == true && modeManager.zero==true && modeManager.inMode3 == true)
        {
            screenManager.f1New -= 1;
        }
    }


    public void GasPlus10()
    {
        screenManager.gas += 10;
        if(modeManager.menuMode == true && modeManager.al == true && modeManager.al1==true && modeManager.inMode2 == true)
        {
            screenManager.al1New += 10;
        }
        if (modeManager.menuMode == true && modeManager.al == true && modeManager.al2 == true && modeManager.inMode2 == true)
        {
            screenManager.al2New += 10;
        }
        if (modeManager.menuMode == true && modeManager.zero == true && modeManager.inMode3 == true)
        {
            screenManager.f1New += 10;
        }

    }
    public void GasMinus10()
    {
        screenManager.gas -= 10;
        if (modeManager.menuMode == true && modeManager.al == true && modeManager.al1 == true && modeManager.inMode2 == true)
        {
            screenManager.al1New -= 10;
        }
        if (modeManager.menuMode == true && modeManager.al == true && modeManager.al2 == true && modeManager.inMode2 == true)
        {
            screenManager.al2New -= 10;
        }
        if (modeManager.menuMode == true && modeManager.zero == true && modeManager.inMode3 == true)
        {
            screenManager.f1New -= 10;
        }
    }
}
