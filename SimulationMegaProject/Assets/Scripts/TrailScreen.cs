using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailScreen : MonoBehaviour
{
    public static TrailScreen trialScreen;
    public bool trialOpen;
    public GameObject screen;

    public void Awake()
    {
        if (trialScreen == null)
        {
            trialScreen = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void Update()
    {
        if (trialOpen == true)
        {
            screen.SetActive(true);
        }
    }
}
