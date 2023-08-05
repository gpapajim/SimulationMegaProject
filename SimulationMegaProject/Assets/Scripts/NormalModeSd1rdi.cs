using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalModeSd1rdi : MonoBehaviour
{
    public ModeManagerSD mode;
    public ScreenManagerSD screen;
    public Lightssd1rdi lights;
    public ButtonPressSD buttons;
    public MenuModeSD maintenance;
    public Error error;

    public float maintenanceEnterTimer;


    public void Start()
    {
        mode.normalMode = true;
        SetStartScreen();
        maintenanceEnterTimer = 3.5f;
    }


    public void Update()
    {
        

        /*if (mode.normalMode)
        {
            screen.dataObj.SetActive(true);
            screen.data.text = 00.ToString("00");
            screen.dot.DotsControl(false, true, false, false);
            lights.PowerLightOn();
        }*/


       /* if (!mode.normalMode)
        {
            screen.dataObj.SetActive(true);
            screen.data.text = "";
            screen.dot.DotsControl(false, false, false, false);
            lights.PowerLightOff();
        }*/


        if (mode.normalMode && buttons.menu)
        {
            maintenanceEnterTimer -= Time.deltaTime;
        }

        if (maintenanceEnterTimer < 0)
        {
            if (mode.normalMode)
            {
                mode.normalMode = false;
                mode.maintenanceMode = true;
                CleanScreen();
                maintenanceEnterTimer = 3.5f;
                return;
            }

            ///otan vgainoun
            if (mode.maintenanceMode || mode.maintenanceMode2 || mode.maintenanceMode3 || mode.maintenanceMode4 || mode.maintenanceMode2_0 || mode.maintenanceMode2_0Menu || mode.Conn)
            {
                mode.normalMode = true;
                mode.maintenanceMode = false;
                mode.maintenanceMode2 = false;
                mode.maintenanceMode3 = false;
                mode.maintenanceMode4 = false;
                mode.maintenanceMode2_0Menu = false;
                mode.maintenanceMode2 = false;
                mode.Conn = false;
                CleanScreen();
                SetStartScreen();
                maintenanceEnterTimer = 3.5f;

                
            }


            /*mode.normalMode = false;
            mode.maintenanceMode = true;
            CleanScreen();
            maintenanceEnterTimer = 3.5f;*/
        }

        if (maintenanceEnterTimer != 3.5f && !buttons.menu)
        {
            maintenanceEnterTimer = 3.5f;
        }

        if ((mode.maintenanceMode || mode.maintenanceMode2 || mode.maintenanceMode3 || mode.maintenanceMode4 || mode.maintenanceMode2_0 || mode.maintenanceMode2_0Menu || mode.Conn) && buttons.menu)
        {
            maintenanceEnterTimer -= Time.deltaTime;
        }

    }

    public void SetStartScreen()
    {
        screen.dataObj.SetActive(true);
        screen.C4H10.Value = 0;
        screen.dot.DotsControl(false, true, false, false);
        lights.PowerLightOn();

        if (error.error1)
        {
            
                error.Error1();
            screen.dot.DotsControl(false, false, false, false);
        }

        if (error.error2 && error.randomSelector == 0)
        {
            screen.score1.SetActive(true);

        }

        if (error.error2 && error.randomSelector == 1)
        {
            screen.C4H10.Value = Random.Range(185, 250);
        }
    }

    public void CleanScreen()//// katharismos othonhs se epistorfi me to kouboi menu
    {
        screen.dataObj.SetActive(false);
        //screen.C4H10.Value = ;
        screen.dot.DotsControl(false, false, false, false);
        
        //lights.PowerLightOff();     /// test stamataei to power blink
        
       

        screen.m20.SetActive(false);
        screen.m21.SetActive(false);
        screen.m22.SetActive(false);
        screen.m23.SetActive(false);
        screen.m24.SetActive(false);
        screen.m25.SetActive(false);
        screen.m26.SetActive(false);
        screen.m27.SetActive(false);
        screen.m10.SetActive(false);
        screen.m11.SetActive(false);
        screen.m12.SetActive(false);
        screen.m13.SetActive(false);
        screen.m240.SetActive(false);
        screen.m241.SetActive(false);
        screen.m242.SetActive(false);
        screen.m243.SetActive(false);
        screen.m244.SetActive(false);
        screen.m245.SetActive(false);
        screen.m246.SetActive(false);
        screen.m247.SetActive(false);
        screen.m248.SetActive(false);
        screen.m249.SetActive(false);
        screen.m24a.SetActive(false);
        screen.m24b.SetActive(false);
        screen.m24c.SetActive(false);
        screen.m24d.SetActive(false);
        screen.m24e.SetActive(false);
        screen.m24f.SetActive(false);
        screen.m24h.SetActive(false);
        screen.m24i.SetActive(false);
        screen.hand.SetActive(false);
        screen.auto.SetActive(false);
        screen.scores.SetActive(false);
        screen.cal.SetActive(false);
        screen.pass.SetActive(false);
        screen.m2_00.SetActive(false);
        screen.m2_01.SetActive(false);
        screen.cOff.SetActive(false);
        screen.cOn.SetActive(false);
        maintenance.inMode = false;
        maintenance.inMode2 = false;
        maintenance.inMode3 = false;
        maintenance.inMode4 = false;
        maintenance.inMode4a = false;
        maintenance.inMode4h = false;
        maintenance.inHand = false;
        mode.maintenanceMode2_0 = false;
        mode.maintenanceMode2_0Menu = false;
        //maintenance.menuSelector2_0 = 0;
        //maintenance.menuSelector2_0Menu = 0;
        mode.Conn = false;
        screen.hand.SetActive(false);
        screen.auto.SetActive(false);


        lights.blinkingPower = false;
        
        
        
        

       
    }

    /*
      na grapsw otan den einai normal kai presarw to menu gia 3,5 na ginetai normal
    */
}
