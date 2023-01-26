using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{
    public void ShowBattery()
    {
        gameObject.transform.GetChild(2).gameObject.SetActive(true);
    }
    public void HideBattery()
    {
        gameObject.transform.GetChild(2).gameObject.SetActive(true);
    }
}
