using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PowerOnOff : MonoBehaviour
{
    
    public GameObject buttonManager;
    public GameObject audioManager;
    public GameObject screenManager;
    public GameObject warning;
    public GameObject alarm;
    

    [Space]
    public bool deviceOn;
    public bool deviceOff;
    public bool inSettings;
    [Space]
    public bool stopOpening;
    [Space]
    public float deviceOnTimer;//na kanw private
    public float deviceOffTimer;
    public void Awake()
    {
        deviceOffTimer = 3;
        deviceOnTimer = 2;
        DeviceOff();
    }

    public void Update()
    {
      foreach(CustomButton b in buttonManager.GetComponent<ButtonManager>().buttons)//psaxnei mesa sto button manager
        {
            if (b.name == "Power")//dialegei to koumpi power opoio kai na einai apop button manager
            {
              if(b.isPressed==true&deviceOff==true & stopOpening==false 
                    & gameObject.GetComponent<CalibrationMode>().inMenu==false)//press down to open
              {
                deviceOnTimer -= Time.deltaTime;
              }
              if(deviceOnTimer<0& gameObject.GetComponent<OpeningScreen>().startingScreenStart == false)//reset if it opens// maybe not needed
              {
                DeviceOn();
              }
                if (b.isPressed == true & deviceOn == true
                    & warning.GetComponent<Warning>().warningStart==false
                    & warning.GetComponent<Warning>().warningOn==false
                    & alarm.GetComponent<Alarm>().warningStart==false
                    & alarm.GetComponent<Alarm>().warningOn==false
                    & alarm.GetComponent<Alarm>().alarmOn==false)//press to shut down
                {
                    deviceOffTimer -= Time.deltaTime;
                }
              if(deviceOffTimer<0& gameObject.GetComponent<OpeningScreen>().startingScreenStart == false)
                {
                  
                    DeviceOff();
                    
                }
              
              if(b.isPressed==false)//reset if you let before open
              {
                    deviceOnTimer = 2;
                    deviceOffTimer = 3;

              }

            } 
            if(b.name=="Air")
            {
                if(b.isPressed==true)
                {
                    stopOpening = true;
                }
                if(b.isPressed==false)
                {
                    stopOpening = false;
                }
            }
        }

     

    }
    public void DeviceOff()//closes the device also default state on run
    {
        if(gameObject.GetComponent<OpeningScreen>().normalOperation==true)//otan exei anoiksei kanonika
        {
            Beep();
        }
        screenManager.transform.GetChild(1).gameObject.transform.GetChild(5).gameObject.SetActive(false);
        screenManager.SetActive(false);//shuts down the screen
        deviceOff = true;
        deviceOn = false;
        gameObject.GetComponent<OpeningScreen>().normalOperation = false;
        deviceOnTimer = 2;
        
    }
    public void DeviceOn()
    {
        screenManager.SetActive(true);//open screen===that valw alla edw
        Beep();
        deviceOn = true;
        deviceOff = false;
        deviceOnTimer = 2;
    }
    public void Beep()
    {
        FindObjectOfType<AudioManager>().Play("Beep");
    }
}
