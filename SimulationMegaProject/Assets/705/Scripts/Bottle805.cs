using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bottle805 : MonoBehaviour
{
    public ScreenManager805 screenManager;
    public ModeManager805 modeManager;
    public int targetNumber;
    public bool gased;
    [Space]
    public float timer;

    public void Awake()
    {
        timer = 1.2f;
    }

    public void Update()
    {
        if(gased==false)
        {
            if (modeManager.span == true && modeManager.inMode == true)
            {
                if (screenManager.gas < targetNumber)
                {
                    timer -= Time.deltaTime;
                }

                if (timer < 0)
                {
                    if(targetNumber-screenManager.gas<=20)
                    {
                        screenManager.gas += Random.Range(0, 3);
                        timer = 2.4f;
                    }
                    if(targetNumber-screenManager.gas>20)
                    {
                        screenManager.gas += Random.Range(0, 3);
                        timer = 1.2f;
                    }
                    
                }

                if (screenManager.gas > targetNumber)
                {
                    gased = true;
                    timer = 1.2f;
                }
            }
        }
        
    }

    public void GasIn()
    {
        targetNumber = Random.Range(40, 60);
        gased = false;
    }
}
