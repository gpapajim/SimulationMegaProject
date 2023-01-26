using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PowerButtonChangeGX2009 : MonoBehaviour
{
    public GameObject gx2009;
    public GameObject buttonManager;
    public GameObject powerText;
    public GameObject changeMsg;

    [Space]
    public bool startSelection;
    public bool buttonSelected;
    [Space]
    public float msgTimer;

    private void Start()
    {
        msgTimer = 2;
    }

    private void Update()
    {
        if (gx2009.GetComponent<PowerOnOff>().inSettings == true)
        {
            powerText.GetComponent<TMPro.TextMeshProUGUI>().text = "Press to change the key";
        }

        if (startSelection == true)
        {
            powerText.GetComponent<TMPro.TextMeshProUGUI>().text = "Press your new key";

            foreach (KeyCode kcode in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(kcode))
                {
                    buttonManager.GetComponent<ButtonManager>().powerSingle._key = kcode;
                    changeMsg.GetComponent<TMPro.TextMeshProUGUI>().text = "new " + "Power " + "button is " + kcode;
                    buttonSelected = true;
                }
            }
            if (buttonSelected == true)
            {
                msgTimer -= Time.deltaTime;
            }
            if (msgTimer < 0)
            {
                changeMsg.GetComponent<TMPro.TextMeshProUGUI>().text = "";
                buttonSelected = false;
                startSelection = false;
            }
            if (msgTimer < 0)
            {
                msgTimer = 2;
            }
        }
        if (startSelection == false)
        {
            powerText.GetComponent<TMPro.TextMeshProUGUI>().text = "";
        }
    }

    public void Press()
    {
        if (startSelection == false)
        {
            startSelection = true;
        }

    }
}
