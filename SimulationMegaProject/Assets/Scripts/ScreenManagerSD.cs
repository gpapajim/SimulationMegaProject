using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScreenManagerSD : MonoBehaviour
{
    public Lightssd1rdi lights;
    public DotsSD dot;
    public GameObject dataObj;
    public TextMeshProUGUI data;

    public GameObject m10;
    public GameObject m11;
    public GameObject m12;
    public GameObject m13;
    public GameObject m20;
    public GameObject m21;
    public GameObject m22;
    public GameObject m23;
    public GameObject m24;
    public GameObject m25;
    public GameObject m26;
    public GameObject m27;
    public GameObject m240;
    public GameObject m241;
    public GameObject m242;
    public GameObject m243;
    public GameObject m244;
    public GameObject m245;
    public GameObject m246;
    public GameObject m247;
    public GameObject m248;
    public GameObject m249;
    public GameObject m24a;
    public GameObject m24b;
    public GameObject m24c;
    public GameObject m24d;
    public GameObject m24e;
    public GameObject m24f;
    public GameObject m24h;
    public GameObject m24i;
    public GameObject m2_00;
    public GameObject m2_01;
    public GameObject hand;
    public GameObject auto;

    public GameObject scores;
    public GameObject score1;
    public GameObject error;
    public GameObject pass;
    public GameObject cal;
    public GameObject cOn;
    public GameObject cOff;

    public GameObject bottleC4H10;

    public FloatVariableSD C4H10;


    public bool blinkingScreen;
    public bool screenOn;

    public float blinkingTimer;


    public void Update()
    {
        if (blinkingScreen)
        {
            blinkingTimer -= Time.deltaTime;
        }

        if (!blinkingScreen)
        {
            blinkingTimer = 0.8f;
            screenOn = false;
        }

        if (blinkingTimer < 0 && blinkingScreen)
        {
            BlinkingScreen();
            blinkingTimer = 0.8f;
        }
    }

    public void BlinkingScreen()
    {
        if (screenOn)
        {
            dataObj.SetActive(false);
            dot.DotsControl(false, false, false, false);
            screenOn = false;
            return;
        }
        if (!screenOn)
        {
            dataObj.SetActive(true);
            dot.DotsControl(false, true, false, false);
            screenOn = true;
        }
    }
}
