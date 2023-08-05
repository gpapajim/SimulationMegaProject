using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneCal : MonoBehaviour
{
    public GameObject gx2009;
    public GameObject extras;
    public GameObject gasNumbers;
    public GameObject gasNames;
    public GameObject buttonManager;
    public GameObject bottle;
    public GameObject numbersBars;
    [Space]
    public bool airPressed;
    public bool powerPressed;
    [Space]
    public bool oneCalStart;
    public bool inOneCal;
    public bool inGas;
    public bool gased;
    public bool ofGased;
    public bool goInGas;
    [Space]
    public bool reverse;
    [Space]
    public int menuSelection;
    [Space]
    public float w8ToPress;
    public float w8ToGetInAgain;
    public float pushFast;
    public float reverseTimer;
    public float normalTimer;
    public float increaseTimer;
    public float goBackTimer;
    public float goInTimer;
    [Space]
    public float o2;
    public float ch4;
    public float h2s;
    public float co;
    [Space]
    public float o2Gased;
    public float ch4Gased;
    public float h2sGased;
    public float coGased;

    private void Awake()
    {
        w8ToPress = 0.5f;
        w8ToGetInAgain = 0.5f;
        pushFast = 0.7f;
        reverseTimer = 0.5f;
        normalTimer = 0.5f;
        goBackTimer = 0.5f;
        goInTimer = 0.5f;
        
    }
    private void Update()
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
        if ((airPressed == false || powerPressed ==false) & inGas == true)
        {
            normalTimer = 0.5f;
            reverseTimer = 0.5f;
        }
        if (airPressed ==true & powerPressed == true & inGas == true & reverse==false)
        {
            reverseTimer -= Time.deltaTime;
        }
        if (airPressed == true & powerPressed == true & inGas == true & reverse == true)
        {
            normalTimer -= Time.deltaTime;
        }
        if (reverse==false & reverseTimer<0)
        {
            reverse = true;
        }
        if (reverse ==true & normalTimer<0)
        {
            reverse = false;
        }
        if (airPressed==false)
        {
            pushFast = 0.7f;
        }
        if (airPressed==true & inGas==true)
        {
            pushFast -= Time.deltaTime;
        }
        if (reverseTimer<0)
        {
            reverseTimer = 0.5f;
        }
        if (normalTimer<0)
        {
            normalTimer = 0.5f;
        }
        if(goInGas==true)
        {
            goInTimer -= Time.deltaTime;
        }
        if(goInTimer<0)
        {
            InGas();
        }
        if(goInTimer<0)
        {
            goInTimer = 0.5f;
        }
        if(ofGased==true && airPressed == false)     ////////// fixing
        {
            goBackTimer -= Time.deltaTime;
        }
        if(goBackTimer<0 && airPressed ==false)      /////fixx ing touch
        {
            inGas = false;
            ofGased = false;
        }
        if(goBackTimer<0)
        {
            goBackTimer = 0.5f;
        }
        if (pushFast<0 & powerPressed==false)
        {
            ChangeNumbers();
            pushFast = 0.7f;
        }
        if (Input.GetKeyDown(buttonManager.GetComponent<ButtonManager>().airSingle._key) & inOneCal==true & inGas==false)
        {
            MenuScroll();
        }
        if(Input.GetKeyDown(buttonManager.GetComponent<ButtonManager>().powerSingle._key) & inOneCal==true)
        {
            InGasTimer();
        }
        if (Input.GetKeyDown(buttonManager.GetComponent<ButtonManager>().airSingle._key) & inGas == true & powerPressed==false)
        {
            ChangeNumbers();
        }
        if ((Input.GetKeyDown(buttonManager.GetComponent<ButtonManager>().powerSingle._key) & airPressed==false) & inOneCal == true & inGas == true)
        {
            OfGas();
        }

        if (inOneCal==true)
        {
            switch (menuSelection)
            {
                case 0://////////////////////////////////////////////////ch4
                    if(inGas==false)
                    {
                        gasNumbers.transform.GetChild(2).gameObject.SetActive(false);
                    }
                    extras.transform.GetChild(3).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "";
                    gasNames.transform.GetChild(0).gameObject.SetActive(true);
                    if(inGas==false)
                    {
                        numbersBars.transform.GetChild(0).gameObject.SetActive(true);
                    }      
                    break;
                case 1://////////////////////////////////////////////////////o2
                    if (inGas == false)
                    {
                        gasNumbers.transform.GetChild(1).gameObject.SetActive(false);
                    }
                    gasNames.transform.GetChild(0).gameObject.SetActive(false);
                    numbersBars.transform.GetChild(0).gameObject.SetActive(false);
                    gasNames.transform.GetChild(3).gameObject.SetActive(true);
                    if(inGas==false)
                    {
                        numbersBars.transform.GetChild(1).gameObject.SetActive(true);
                    }
                    break;
                case 2:////////////////////////////0/////////////////////////h2s
                    if (inGas == false)
                    {
                        gasNumbers.transform.GetChild(3).gameObject.SetActive(false);
                    }
                    gasNames.transform.GetChild(3).gameObject.SetActive(false);
                    numbersBars.transform.GetChild(1).gameObject.SetActive(false);
                    gasNames.transform.GetChild(1).gameObject.SetActive(true);
                    if (inGas == false)
                    {
                        numbersBars.transform.GetChild(2).gameObject.SetActive(true);
                    }
                    break;
                case 3://///////////////////////////////////////////////////co
                    if (inGas == false)
                    {
                        gasNumbers.transform.GetChild(0).gameObject.SetActive(false);
                    }
                    gasNames.transform.GetChild(1).gameObject.SetActive(false);
                    numbersBars.transform.GetChild(2).gameObject.SetActive(false);
                    gasNames.transform.GetChild(2).gameObject.SetActive(true);
                    if (inGas == false)
                    {
                        numbersBars.transform.GetChild(3).gameObject.SetActive(true);
                    }
                    break;
                case 4:////////////////////////////////////////////////////////escape
                    for (int i = 0; i < 4; i++)
                    {
                        gasNames.transform.GetChild(i).gameObject.SetActive(false);
                    }
                    for (int i = 0; i < 4; i++)
                    {
                        numbersBars.transform.GetChild(i).gameObject.SetActive(false);
                    }
                    extras.transform.GetChild(3).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "ESCAPE";
                    break;

            }
        }
        if(oneCalStart==true & inGas==false)
        {
            for (int i=0;i<4;i++)
            {
                gasNames.transform.GetChild(i).gameObject.SetActive(false);
            }
            for (int i = 0; i < 4; i++)
            {
                gasNumbers.transform.GetChild(i).gameObject.SetActive(false);
            }
            menuSelection = 0;
            extras.transform.GetChild(3).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "";
            w8ToPress -= Time.deltaTime;
            if(w8ToPress<0)
            {
                oneCalStart = false;
                inOneCal = true;
                numbersBars.gameObject.SetActive(true);//na kleisw sto inspector ta child   
            }
        }
        
        
        if(w8ToPress<0)
        {
            w8ToPress = 0.5f;
        }
        if(inGas==true & gx2009.GetComponent<CalibrationMode>().inMode==false)   ///////////////////////////////////////////////
        {
            w8ToGetInAgain -= Time.deltaTime;
        }
        if(w8ToGetInAgain<0)
        {
            inGas = false;
            w8ToGetInAgain = 0.5f;
        }

        if(bottle.GetComponent<Bottle>().bottleOnOff==true & inGas==true)////////////////////////////////
        {
            if(gased==false)
            {
                Gased();
            }
            
            increaseTimer -= Time.deltaTime;
            if (increaseTimer < 0)
            {  
                if(o2<o2Gased)
                {
                    o2 += Random.Range(0.5f, 0.8f);
                }
                if(ch4<ch4Gased)
                {
                    ch4 += Random.Range(1, 4);
                }
                if(h2s<h2sGased)
                {
                    h2s += Random.Range(1, 3);
                }
                if(co<coGased)
                {
                    co += Random.Range(1, 4);
                }
            }
            if(increaseTimer<0)
            {
                increaseTimer = 1.5f;
            }
        }
        if(inOneCal==true)
        {
            gasNumbers.GetComponent<GasNumbers>().GasNumbersUpdate(o2, ch4, h2s, co);
        }
        
    }

    public void MenuScroll()
    {
        menuSelection += 1;
        if(menuSelection==5)
        {
            menuSelection = 0;
        }
    }
    public void InGas()
    {
        goInGas = false;
        if(menuSelection==0)
        {
            gasNumbers.transform.GetChild(2).gameObject.SetActive(true);
            numbersBars.transform.GetChild(0).gameObject.SetActive(false);
            inGas = true;
        }
        if(menuSelection==1)
        {
            gasNumbers.transform.GetChild(1).gameObject.SetActive(true);
            numbersBars.transform.GetChild(1).gameObject.SetActive(false);
            inGas = true;
        }
        if(menuSelection==2)
        {
            gasNumbers.transform.GetChild(3).gameObject.SetActive(true);
            numbersBars.transform.GetChild(2).gameObject.SetActive(false);
            inGas = true;
        }
        if(menuSelection==3)
        {
            gasNumbers.transform.GetChild(0).gameObject.SetActive(true);
            numbersBars.transform.GetChild(3).gameObject.SetActive(false);
            inGas = true;
        }
        if(menuSelection==4)
        {
            oneCalStart = false;
            inGas = true;
            inOneCal = false;
            gasNumbers.transform.GetChild(0).gameObject.SetActive(true);
            gasNumbers.transform.GetChild(1).gameObject.SetActive(true);
            gasNumbers.transform.GetChild(2).gameObject.SetActive(true);
            gasNumbers.transform.GetChild(3).gameObject.SetActive(true);
            gasNames.transform.GetChild(0).gameObject.SetActive(true);
            gasNames.transform.GetChild(1).gameObject.SetActive(true);
            gasNames.transform.GetChild(2).gameObject.SetActive(true);
            gasNames.transform.GetChild(3).gameObject.SetActive(true);
            gx2009.GetComponent<CalibrationMode>().inMode = false;
        }
    }
    public void ChangeNumbers()
    {
        if(menuSelection==0 & reverse==false & pushFast>0)
        {
            ch4 += 5;
            
        }
        if(menuSelection==0 & reverse==false & pushFast<0)
        {
            ch4 += 10;
        }
        if (menuSelection == 0 & reverse == true & pushFast > 0)
        {
            ch4 -= 5;

        }
        if (menuSelection == 0 & reverse == true & pushFast < 0)//////
        {
            ch4 -= 10;
        }
        if (menuSelection == 1 & reverse == false & pushFast > 0)
        {
            o2 += 0.2f;

        }
        if (menuSelection == 1 & reverse == false & pushFast < 0)
        {
            o2 += 0.5f;
        }
        if (menuSelection == 1 & reverse == true & pushFast > 0)
        {
            o2 -= 0.2f;

        }
        if (menuSelection == 1 & reverse == true & pushFast < 0)/////
        {
            o2 -= 0.5f;
        }
        if (menuSelection == 2 & reverse == false & pushFast > 0)
        {
            h2s += 5;

        }
        if (menuSelection == 2 & reverse == false & pushFast < 0)
        {
            h2s += 10;
        }
        if (menuSelection == 2 & reverse == true & pushFast > 0)
        {
            h2s -= 5;

        }
        if (menuSelection == 2 & reverse == true & pushFast < 0)//////
        {
            h2s -= 10;
        }
        if (menuSelection == 3 & reverse == false & pushFast > 0)
        {
            co += 5;

        }
        if (menuSelection == 3 & reverse == false & pushFast < 0)
        {
            co += 10;
        }
        if (menuSelection == 3 & reverse == true & pushFast > 0)
        {
            co -= 5;

        }
        if (menuSelection == 3 & reverse == true & pushFast < 0)//////
        {
            co -= 10;
        }
        
    }
    public void Gased()
    {
        gased = true;
        o2Gased = Random.Range(8, 14.6f);
        ch4Gased = Random.Range(32, 70);
        coGased = Random.Range(32, 70);
        h2sGased = Random.Range(15, 38);
    }
    public void OfGas()
    {
        ofGased = true;
    }
    public void InGasTimer()
    {
        goInGas = true;
    }
}
