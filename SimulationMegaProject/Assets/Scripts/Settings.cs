using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{
    public GameObject gx2009;

    private void Update()
    {
      
    }
    public void OpenMenu()
    {
        if(gx2009.GetComponent<PowerOnOff>().deviceOff==true & gx2009.GetComponent<CalibrationMode>().inMenu==false)
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            gx2009.GetComponent<PowerOnOff>().inSettings = true;
        }
        
    }
    public void CloseMenu()
    {
        gameObject.transform.parent.gameObject.SetActive(false);
        gx2009.GetComponent<PowerOnOff>().inSettings = false;
    }
}