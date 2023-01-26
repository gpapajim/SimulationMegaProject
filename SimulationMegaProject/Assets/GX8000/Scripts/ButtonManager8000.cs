using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager8000 : MonoBehaviour
{
    public DeviceState8000 deviceState;

    public Button airButton;
    public Button powerButton;
    public Button resetButton;
    public Button displayButton;


    public KeyCode air;
    public KeyCode power;
    public KeyCode display;
    public KeyCode reset;


    public bool A;
    public bool P;
    public bool R;
    public bool D;

    public float timer;


    public void Awake()
    {
        timer = 1;
    }

    public void Update()
    {
        if (Input.GetKeyDown(air))
        {
            A = true;
            if (deviceState.on &! deviceState.startingSq)
            {
                ButtonSound();
            }
        }
        else
        {
            A = false;
        }

        if (Input.GetKeyDown(power))
        {
            P = true;
            if (deviceState.on &! deviceState.startingSq)
            {
                ButtonSound();
            }
        }
        else
        {
            P = false;
        }

        if (Input.GetKeyDown(display))
        {
            D = true;
            if (deviceState.on &! deviceState.startingSq)
            {
                ButtonSound();
            }
        }
        else
        {
            D = false;
        }

        if (Input.GetKeyDown(reset))
        {
            R = true;
            if (deviceState.on &! deviceState.startingSq)
            {
                ButtonSound();
            }
        }
        else
        {
            R = false;
        }

        if (Input.GetKey(air))
        {
            A = true;

        }

        if (Input.GetKey(power))
        {
            P = true;

        }

        if (Input.GetKey(display))
        {
            D = true;

        }

        if (Input.GetKey(reset))
        {
            R = true;

        }

        if ((A || P || R || D) && (deviceState.on &! deviceState.startingSq))
        {
            timer -= Time.deltaTime;
        }

        if (!A && !P && !R && !D)
        {
            timer = 1f;
        }
    }


    public void FixedUpdate()
    {
        if (timer < 0)
        {
            ButtonSound();
            timer = 1f;
        }
    }



    public void ButtonSound()
    {
        FindObjectOfType<AudioManager8000>().Play("Beep");
    }
}
