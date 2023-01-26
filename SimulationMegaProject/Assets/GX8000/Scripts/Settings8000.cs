using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings8000 : MonoBehaviour
{

    public DeviceState8000 deviceState;
    public GameObject settings;
    

    
    void Update()
    {
        
    }

    public void OpenMenu()
    {
        if (!deviceState.on &! deviceState.menu)
        {
            settings.SetActive(true);
            deviceState.inSettings = true;
        }

    }

    public void CloseMenu()
    {
        settings.SetActive(false);
        deviceState.inSettings = false;
    }
    
}
