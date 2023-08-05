    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   

public class ButtonManager : MonoBehaviour
{
    //settarisma ton buttons apo edw tha pernoun ta script ta koumpia
    //mallon edw tha settarw kai to hxo tou pathmatos twn pliktrwn
    public GameObject gx2009;
    public CustomButton[] buttons;
    [Space]
    public CustomButton airSingle;
    public CustomButton powerSingle;
    [Space]
    public float soundEffectTimer;
    
    private void Awake()
    {
        soundEffectTimer = 1;
    }
    public void Update()
    {

        foreach (CustomButton b in buttons)
        {
            if (Input.GetKey(b._key))//detecting press 
            {
                b.isPressed = true;
            }
            if (Input.GetKeyUp(b._key))//detecting realease of button
            {
                b.isPressed = false;
            }
            if(b.isPressed==true&(gx2009.GetComponent<OpeningScreen>().normalOperation==true
                || gx2009.GetComponent<CalibrationMode>().inMenu==true))
            {
                
                Timer();
            }
            
        }
        if((Input.GetKeyDown(airSingle._key)||Input.GetKeyDown(powerSingle._key))
            & (gx2009.GetComponent<OpeningScreen>().normalOperation == true
            || gx2009.GetComponent<CalibrationMode>().inMenu == true))
        {
            ButtonSound();
        }
        if(buttons[0].isPressed==false && buttons[1].isPressed==false)
        {
            ResetTimer();
        }
        if(soundEffectTimer<0)
        {
            ButtonSound();
            ResetTimer();
        }
        foreach(CustomButton b in buttons)
        {
            if(b.name=="Air")
            {
                b._key = airSingle._key;
            }
            if(b.name=="Power")
            {
                b._key = powerSingle._key;
            }
        }
    }
    public void Timer()
    {
        soundEffectTimer -= Time.deltaTime;
    }
    public void ResetTimer()
    {
        soundEffectTimer = 1;
    }

    public void ButtonSound()
    {
        FindObjectOfType<AudioManager>().Play("Button");
    }
}
