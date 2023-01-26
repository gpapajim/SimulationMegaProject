using UnityEngine;

public class LightsSD10X : MonoBehaviour
{
    public GameObject powerLight;
    public GameObject alarmLight;
    public GameObject faultLight;
    public GameObject powerLightOff;
    public GameObject alarmLightOff;

    public bool powerOn;
    public bool alarmOn;

    public bool blinkingPower;
    public bool blinkingAlarm;

    public float blinkingTimer;

    public void Start()
    {
        blinkingTimer = 0.5f;
    }

    public void Update()
    {
        if (blinkingAlarm || blinkingPower)
        {
            blinkingTimer -= Time.deltaTime;
        }

        if (!blinkingAlarm && !blinkingPower)
        {
            blinkingTimer = 0.5f;
            powerOn = false;
            alarmOn = false;
        }

        

        if (blinkingTimer <0 && blinkingPower)
        {
            Powerblinking();
            blinkingTimer = 0.5f;
        }

        if (blinkingTimer <0 && blinkingAlarm)
        {
            AlarmBlinking();
            blinkingTimer = 0.5f;
        }

    }

    public void Powerblinking()
    {
        if (powerOn)
        {
            powerLight.SetActive(false);
            powerOn = false;
            return;
        }
        if (!powerOn)
        {
            powerLight.SetActive(true);
            powerOn = true;
        }
    }

    public void AlarmBlinking()
    {
        if (alarmOn)
        {
            alarmLight.SetActive(false);
            alarmOn = false;
            return;
        }
        if (!alarmOn)
        {
            alarmLight.SetActive(true);
            alarmOn = true;
        }
    }



    public void PowerLightOn()
    {
        powerLight.SetActive(true);
        
    }

    public void AlarmLightOn()
    {
        alarmLight.SetActive(true);
        
    }

    public void FaultLightOn()
    {
         faultLight.SetActive(true);
    }

    public void PowerLightOff()
    {
        
        powerLight.SetActive(false);
    }

    public void AlarmLightOff()
    {
        alarmLight.SetActive(false);
        
    }

    public void FaultLightOff()
    {
        faultLight.SetActive(false);
    }
}
