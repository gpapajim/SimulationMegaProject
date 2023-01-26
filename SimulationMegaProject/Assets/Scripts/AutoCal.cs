using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoCal : MonoBehaviour
{
    public GameObject gx2009;
    public GameObject screenManager;
    public GameObject extras;
    public GameObject buttonManager;
    public GameObject gasNumbers;
    public GameObject gasCup;
    public GameObject gasBottle;
    [Space]
    public bool powerPressed;
    public bool airPressed;
    [Space]
    public bool autoCalStart;
    public bool rdyToPress;
    [Space]
    public bool o2Ready;
    public bool ch4Ready;
    public bool h2sReady;
    public bool coReady;
    [Space]
    public bool blinkMessage;
    public bool autoPassStart;
    public bool autoPass;
    public int onOffMessage;
    [Space]
    public float w8ToPress;
    public float onOffMessageTimer;
    public float increaseTimer;
    public float autoPassTimer;
    [Space]
    public float o2;
    public float ch4;
    public float h2s;
    public float co;

    public void Awake()
    {
        w8ToPress = 0.5f;
        autoPassTimer = 2;
    }
    public void Update()
    {
        foreach (CustomButton b in buttonManager.GetComponent<ButtonManager>().buttons)//psaxnei mesa sto button manager
        {
            if (b.name == "Power")
            {
                if (b.isPressed == true)
                {
                    powerPressed = true;
                }
                if (b.isPressed == false)
                {
                    powerPressed = false;
                }
            }
            if (b.name == "Air")
            {
                if (b.isPressed == true)
                {
                    airPressed = true;
                }
                if (b.isPressed == false)
                {
                    airPressed = false;
                }
            }
        }

        if (autoCalStart == true)
        {
            w8ToPress -= Time.deltaTime;
        }
        if(autoCalStart==true&blinkMessage==false)
        {
            gx2009.GetComponent<AutoCal>().o2 = 12;
            gx2009.GetComponent<AutoCal>().ch4 = 50;
            gx2009.GetComponent<AutoCal>().co = 50;
            gx2009.GetComponent<AutoCal>().h2s = 25;
        }
        if (w8ToPress < 0)
        {
            rdyToPress = true;
            w8ToPress = 0.5f;
        }
        if (powerPressed == true & rdyToPress == true)//prwto press sto auto
        {
            AutoCalibration();
   
        }
        if(gasBottle.GetComponent<Bottle>().bottleOnOff == true & powerPressed==true & blinkMessage==true)//deutero press sto auto
        {
            autoPass = true;
        }
        if(autoPass==true)
        {
            extras.transform.GetChild(3).gameObject.SetActive(true);
            rdyToPress = false;
            increaseTimer = 1.5f;
            w8ToPress = 0.5f;
            gx2009.GetComponent<AutoCal>().autoCalStart = false;
            gx2009.GetComponent<CalibrationMode>().inMode = false;
            extras.transform.GetChild(3).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "PASS";
            blinkMessage = false;
            autoPassTimer -= Time.deltaTime;
            if(autoPassTimer<0)
            {
                gx2009.GetComponent<CalibrationMode>().inMenu = true;
                autoPass = false;
                autoPassStart = false;
                autoPassTimer = 2;
                //gasBottle.GetComponent<Bottle>().HideBottle();
                extras.transform.GetChild(3).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "";
            }

        }
        if(autoPass==true)
        {
        }
        if (blinkMessage == true)
        {
            extras.transform.GetChild(3).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "AUTO CAL";
            switch (onOffMessage)
            {
                case 0:
                    extras.transform.GetChild(3).gameObject.SetActive(true);
                    onOffMessageTimer -= 1 * Time.deltaTime;
                    if (onOffMessageTimer < 0)
                    {
                        FlashCircle();
                        onOffMessageTimer = 0.5f;
                    }
                    break;
                case 1:
                    extras.transform.GetChild(3).gameObject.SetActive(false);
                    onOffMessageTimer -= 1 * Time.deltaTime;
                    if (onOffMessageTimer < 0)
                    {
                        FlashCircle();
                        onOffMessageTimer = 0.5f;
                    }
                    break;
            }
        }
        if (gasBottle.GetComponent<Bottle>().bottleOnOff == true)//apo edw na valw to blink messag gia na mhn gemizei otan den einai mesa
        {
            increaseTimer -= Time.deltaTime;
            ///////////////////////////////////////fix gas
            if (o2 > 12 & increaseTimer < 0)
            {
                o2 -= Random.Range(0.1f, 0.3f);
            }
            if (o2 < 12)
            {
                o2 = 12;
            }
            if (ch4 < 50 & increaseTimer < 0)
            {
                ch4 += Random.Range(1, 4);
            }
            if (ch4 > 50)
            {
                ch4 = 50;
            }
            if (h2s < 25 & increaseTimer < 0)
            {
                h2s += Random.Range(1, 3);
            }
            if (h2s > 25)
            {
                o2 = 25;
            }
            if (co < 50 & increaseTimer < 0)
            {
                co += Random.Range(1, 4);
            }
            if (co > 50)
            {
                co = 50;
            }
            if (increaseTimer < 0)
            {
                increaseTimer = 1.5f;
            }
        }
        
        if(autoCalStart==true)
        {
            gasNumbers.GetComponent<GasNumbers>().GasNumbersUpdate(o2, ch4, h2s, co);//update screen
        }  
    }

    public void AutoCalibration()
    {
        gx2009.GetComponent<AutoCal>().o2 = 20.9f;
        gx2009.GetComponent<AutoCal>().ch4=0;
        gx2009.GetComponent<AutoCal>().co=0;
        gx2009.GetComponent<AutoCal>().h2s=0;
        blinkMessage = true;
        
    }
    void FlashCircle()
    {
        onOffMessage += 1;
        if (onOffMessage == 2)
        {
            onOffMessage = 0;

        }
    }

}
