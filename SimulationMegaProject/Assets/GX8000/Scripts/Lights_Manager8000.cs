using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lights_Manager8000 : MonoBehaviour
{
    //apo edw xeirizomai ta lights 
    //ola ta functions tous einai edw


    [Space]
    public bool timeSelected;
    [Space]
    public int numberOfLeds;//o arithmos twn led
    [Space]
    
    [Header("Timers (in Seconds)")]
    public float warningTimer;
    public float alarmTimer;
    [Space]
    public int ledOn;//na ginoun private
    public int ledOff;
    public float selectedTimer;
    public float resetTimer;


    void Awake()
    {
        
        numberOfLeds = gameObject.transform.childCount;
        

        LightsOff();//kleinw prin to start
    }

    public void Update()
    {
        
       
        if(timeSelected==true)
        {
            selectedTimer -= Time.deltaTime;
            if (selectedTimer < 0)
            {
                ledOff = ledOn;
                ledOn += 1;
                if (ledOn == numberOfLeds)
                {
                    ledOn = 0;
                }
                AlarmCircle();
            }
            if (selectedTimer < 0)
            {
                selectedTimer = resetTimer;
            }
        }
    }


    //anavei ta fwta ola 
    // gia to anoigma
   
    public void LightsOn()
    {
        for (int i = 0; i < numberOfLeds; i++)
        {
            gameObject.transform.GetChild(i).gameObject.SetActive(true);

        }
    }

    //lights o arithmos twn led+1
    //kleinei ola ta fwta 
    
    public void LightsOff()
    {
        for (int i = 0; i < numberOfLeds; i++)
        {
            gameObject.transform.GetChild(i).gameObject.SetActive(false);

        }
    }

    //kuklos sta alarm
    private void AlarmCircle()
    {
        gameObject.transform.GetChild(ledOff).gameObject.SetActive(false);
        gameObject.transform.GetChild(ledOn).gameObject.SetActive(true);
        

    }
    
    //setarei twn xrono twn alarm
    public void TimerSelector(float timeSelected)
    {
        selectedTimer = timeSelected;
        resetTimer = timeSelected;
    }
}
