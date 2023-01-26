using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GasNumbers : MonoBehaviour
{

    public Gas[] gases;
    
    
    public void Update()
    {   //gas base and rounding to one decimal 
        foreach (Gas g in gases)
        {
            if(g.inFloat==true)
            {
                g.onScreen = Math.Round(g.number, 1);
                
            }
            else
            {
                g.onScreen =Math.Round(g.number,0);
            }
        }
    }
    public void GasNumbersUpdate(float o2, float ch4, float h2s, float co)//update numbers on screen
    {
        foreach (Gas g in gameObject.GetComponent<GasNumbers>().gases)
        {
            if (g.name == "o2")
            {
                g.number = o2;
            }
            if (g.name == "ch4")
            {
                g.number = ch4;
            }
            if (g.name == "h2s")
            {
                g.number = h2s;
            }
            if (g.name == "co")
            {
                g.number = co;
            }
        }
    }

}
