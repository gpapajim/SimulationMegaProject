using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottle : MonoBehaviour
{
    public bool bottleOnOff;
    public GameObject gasCup;

    public void BottleOnOff()
    {
        if(bottleOnOff==false)
        {
            bottleOnOff = true;
            gasCup.gameObject.SetActive(true);
        }
        else
        {
            bottleOnOff = false;
            gasCup.gameObject.SetActive(false);
        }
    }
    public void ShowBottle()
    {
        gameObject.SetActive(true);
    }
    public void HideBottle()
    {
        gameObject.SetActive(false);
    }
}
