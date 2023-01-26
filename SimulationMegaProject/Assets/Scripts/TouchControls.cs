using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControls : MonoBehaviour
{
    public GameObject gx2009;
    public GameObject buttonManager;

    private string touchName;
    [Space]
    public float soundEffectTimer;

    private void Awake()
    {
        touchName = gameObject.name;
    }

    public void Touch()
    {
        foreach(CustomButton b in buttonManager.GetComponent<ButtonManager>().buttons)
        {
            if(b.name==touchName)
            {
                b.isPressed = true;
            }
        }  
        
    }
    public void SinglePress()
    { 
        if (gx2009.GetComponent<OpeningScreen>().normalOperation == true|| gx2009.GetComponent<CalibrationMode>().inMenu == true)
        ButtonSound();
        if(gx2009.GetComponent<CalibrationMode>().inMenu==true&touchName=="Air" & gx2009.GetComponent<CalibrationMode>().inMode==false)
        {
            gx2009.GetComponent<CalibrationMode>().MenuScroll();
        }
        if(gx2009.GetComponent<OneCal>().inOneCal==true & gx2009.GetComponent<OneCal>().inGas == false & touchName=="Air")
        {
            gx2009.GetComponent<OneCal>().MenuScroll();
        }
        if(gx2009.GetComponent<OneCal>().inOneCal & touchName=="Power")
        {
            gx2009.GetComponent<OneCal>().InGasTimer();
        }
        if(gx2009.GetComponent<OneCal>().inGas==true & touchName!="Power")
        {
            gx2009.GetComponent<OneCal>().ChangeNumbers();
        }
        if(touchName!="Air")
        {
            if (touchName == "Power" & gx2009.GetComponent<OneCal>().inGas==true & gx2009.GetComponent<OneCal>().inOneCal==true)
            {
                gx2009.GetComponent<OneCal>().OfGas();
            }
        }
        
    }
    public void NoTouch()
    {
        foreach (CustomButton b in buttonManager.GetComponent<ButtonManager>().buttons)
        {
            if (b.name == touchName)
            {
                b.isPressed = false;
            }
        }
    }
    public void ButtonSound()
    {
        FindObjectOfType<AudioManager>().Play("Button");
    }
}
