using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleActivation : MonoBehaviour
{
    public MenuModeSD menuMode;


    public void Update()
    {
        
    }

    public void OnOFF()
    {
        if (!menuMode.gasIn)
        {
        
            menuMode.GasIn();
            return;
        }

        if (menuMode.gasIn)
        {
            menuMode.GasOut();
            return;
        }
    }

}
