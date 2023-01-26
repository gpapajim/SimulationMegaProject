using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalibrationMode : MonoBehaviour
{
    public GameObject gx2009;
    public GameObject extras;
    public GameObject buttonManager;
    public GameObject screenManager;
    public GameObject gasNumbers;
    public GameObject bottle;
    [Space]
    public bool powerPressed;
    public bool airPressed;
    [Space]
    public int menuSelection;
    [Space]
    public bool inMenu;
    public bool soundPlay;
    public bool endSkip;
    public bool inMode;
    [Space]
    public float inMenuTimer;
    public float endSkipTimer;

    public void Awake()
    {
        inMenuTimer = 2;
        endSkipTimer = 1;
    }
    public void Update()
    {
        foreach (CustomButton b in buttonManager.GetComponent<ButtonManager>().buttons)//psaxnei mesa sto button manager
        {
            if (b.name == "Power")
            {
                if(b.isPressed==true)
                {
                    powerPressed = true;
                }
                if(b.isPressed==false)
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
                if(b.isPressed==false)
                {
                    airPressed = false;
                }
            }
        }
        if(airPressed==true & powerPressed==true & inMenu==false)
        {
            inMenuTimer -= Time.deltaTime;
        }
        if (airPressed == false || powerPressed == false)
        {
            inMenuTimer = 2;
        }
        if (inMenuTimer<0)
        {
            inMenu = true;
            ButtonSound();
            inMenuTimer = 2;
        }
        if(inMenu==true)
        {
            Menu();
        }
        if (Input.GetKeyDown(buttonManager.GetComponent<ButtonManager>().airSingle._key) & inMenu==true &inMode==false)
        {
            MenuScroll();
        }
        if(endSkip==true)
        {
            endSkipTimer -= Time.deltaTime;
            extras.transform.GetChild(3).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "END";
        }
        if(endSkipTimer<0)
        {
            extras.transform.GetChild(3).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "";
            endSkip = false;
            inMode = false;
            endSkipTimer = 1;
            Menu();
        }
    }
    public void Menu()
    {

        gx2009.transform.GetChild(0).gameObject.SetActive(true);
        extras.transform.GetChild(2).gameObject.SetActive(true);
        if(inMode==false)
        {
            switch (menuSelection)
            {
                case 0:
                    extras.transform.GetChild(3).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "DATE";
                    break;
                case 1:
                    extras.transform.GetChild(3).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "AIR CAL";
                    if (powerPressed == true  & endSkipTimer == 1)
                    {
                        inMode = true;
                        bottle.GetComponent<Bottle>().HideBottle();
                        gx2009.transform.GetChild(4).gameObject.SetActive(false);
                        screenManager.transform.GetChild(0).gameObject.SetActive(true);
                        bottle.GetComponent<Bottle>().bottleOnOff = false;
                        extras.transform.GetChild(0).gameObject.SetActive(true);
                        extras.transform.GetChild(1).gameObject.SetActive(true);
                        gasNumbers.GetComponent<GasNumbers>().GasNumbersUpdate(20.9f, 0, 0, 0);
                        extras.transform.GetChild(3).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "PUSH AIR";
                    }
                    break;
                case 2:
                    extras.transform.GetChild(3).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "AUTO CAL";
                    if (powerPressed == true)
                    {
                        inMode = true;
                        screenManager.transform.GetChild(0).gameObject.SetActive(true);
                        extras.transform.GetChild(0).gameObject.SetActive(true);
                        bottle.GetComponent<Bottle>().ShowBottle();
                        extras.transform.GetChild(3).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "AUTO CAL";
                        gx2009.GetComponent<AutoCal>().autoCalStart = true;
                    }
                    break;
                case 3:
                    extras.transform.GetChild(3).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "ONE CAL";
                    if (powerPressed == true & gx2009.GetComponent<OneCal>().inGas==false)
                    {
                        inMode = true;
                        screenManager.transform.GetChild(0).gameObject.SetActive(true);
                        extras.transform.GetChild(0).gameObject.SetActive(true);
                        bottle.GetComponent<Bottle>().ShowBottle();
                        extras.transform.GetChild(3).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "Air CAL";
                        gx2009.GetComponent<OneCal>().oneCalStart = true;
                    }
                    if(inMode==false)
                    {
                        gx2009.GetComponent<OneCal>().menuSelection = 0;
                    }
                        break;
                case 4:
                    extras.transform.GetChild(3).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "ALARM--P";
                    break;
                case 5:
                    extras.transform.GetChild(3).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "REFRESH";
                    break;
                case 6:
                    extras.transform.GetChild(3).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "PASSWORD";
                    break;
                case 7:
                    extras.transform.GetChild(3).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "START";
                    if (powerPressed == true)
                    {
                        inMenu = false;
                        bottle.GetComponent<Bottle>().HideBottle();
                        menuSelection = 0;
                        gx2009.GetComponent<PowerOnOff>().deviceOn = true;
                        gx2009.GetComponent<PowerOnOff>().deviceOff = false;
                        gx2009.GetComponent<OpeningScreen>().startingScreenStart = true;
                        extras.transform.GetChild(3).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "";
                        ButtonSound();
                    }
                    break;
            }
        }
    }
    public void MenuScroll()
    {
        menuSelection += 1;
        if (menuSelection == 8)
        {
            menuSelection = 0;
        }
    }
    public void ButtonSound()
    {
        FindObjectOfType<AudioManager>().Play("Beep");
    }
    

}
