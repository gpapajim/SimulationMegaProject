using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warning : MonoBehaviour
{
    public GameObject warningButton;
    public GameObject gx2009;
    public GameObject alarmLightsManager;
    public GameObject gasNumbers;
    public GameObject menuMessage;
    [Space]
    public float increaseTimer;//xronos gia na anevei kati
    public float alarmTimer;//o xronos pou gurizoun ta lights to dinw sto function
    public float warningSoundTimer;
    [Space]
    public bool warningStart;
    public bool warningOn;
    public bool airCleaned;
    [Space]
    public int gasSelected;
    public int o2UpDown;
    public bool o2Selected;
    public bool ch4Selected;
    public bool h2sSelected;
    public bool coSelected;
    [Space]
    public float o2;
    public float ch4;
    public float h2s;
    public float co;

    public void Awake()
    {
        increaseTimer = 1.5f;//xronos gia na anevei kati
    }
    public void Update()
    {
       
        if(warningStart==false&warningOn==false)//to blockarw na kanei sinexws update 
        {
          foreach(Gas g in gasNumbers.GetComponent<GasNumbers>().gases)//passing the real numbers to the floats
          {
            if(g.name=="o2")
            {
                o2 = g.number;
            }
            if(g.name=="ch4")
            {
                ch4 = g.number;
            }
            if(g.name=="h2s")
            {
                h2s = g.number;
            }
            if(g.name=="co")
            {
                co = g.number;
            }
          }
        }

        if(warningStart==true)//timer start//increase start
        {
            increaseTimer -= Time.deltaTime;
            //////////////////////////////////////////gas increase
            if (increaseTimer < 0 & o2Selected == true)//o2
            {
                if (o2UpDown == 0)
                {
                    o2 -= Random.Range(0.1f, 0.3f);
                }
                if(o2UpDown==1)
                {
                    o2 += Random.Range(0.1f, 0.3f);
                }
            }
            if (increaseTimer < 0 & ch4Selected == true)//ch4
            {
                ch4 += Random.Range(1, 3);
            }
            if (increaseTimer < 0 & h2sSelected == true)//h2s
            {
                h2s += Random.Range(1, 3);
            }
            if (increaseTimer < 0 & coSelected == true)//co
            {
                co += Random.Range(1, 3);
            }
            gasNumbers.GetComponent<GasNumbers>().GasNumbersUpdate(o2, ch4, h2s, co);//updates the numbers 
            /////////////////////////////////////////gas increase
            if (increaseTimer < 0)//timer reset
            {
                increaseTimer = 1.5f;
            }
        }
        if((o2 < 19.5f || o2 > 21.8f || co > 25|| ch4 > 10|| h2s > 10) & warningStart==true)//ksekina to alarm //kovei to increse
        {
            if(o2 < 19.2f || o2 > 22.4f|| co > 30|| ch4 > 20|| h2s > 15)//ta afinw na pane ligo pio katw apo to trigger
            {
                warningStart = false;//apo edw mallon tha afisw gia to alarm
            }
            warningOn = true;
        }
        if(warningOn==true & alarmLightsManager.GetComponent<Lights_Manager>().timeSelected == false)//ksekina ta fwta/minima
        {
            menuMessage.GetComponent<TMPro.TextMeshProUGUI>().text = "WARNING";
            alarmLightsManager.GetComponent<Lights_Manager>().timeSelected = true;
            alarmLightsManager.GetComponent<Lights_Manager>().TimerSelector(0.7f);//alarm start
        }
        if(warningOn==true)//ksekina/xeirizetai ton hxo
        {
            if(airCleaned==true)//gia na douleuei meta apo ena clean o hxos
            {
                WarningSound();
                airCleaned = false;
            }
            warningSoundTimer -= Time.deltaTime;
            if(warningSoundTimer<0&airCleaned==false)//gia na 
            {
                WarningSound();
                warningSoundTimer = 7;
            }
        }
    }

    public void WarningStart()//to function tou warning
    { 
        if(gx2009.GetComponent<OpeningScreen>().normalOperation==true)
        {
            gasSelected = Random.Range(0, 4);//dialegei aerio
            warningStart = true;//ksekina to timer
            switch (gasSelected)//epilogh tou aeriou 
            {
                case 0:
                    o2Selected = true;
                    o2UpDown = Random.Range(0, 2);
                    break;
                case 1:
                    ch4Selected = true;
                    break;
                case 2:
                    h2sSelected = true;
                    break;
                case 3:
                    coSelected = true;
                    break;
            }
        }
    }
    public void WarningSound()//sound function
    {
        FindObjectOfType<AudioManager>().Play("Warning");
    }
    public void WarningSoundPause()
    {
        FindObjectOfType<AudioManager>().Pause("Warning");
    }
    
}
