using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ActivationState
{
    public bool activated;


    public ActivationState(bool activated)
    {
        this.activated = activated;
    }
}

[System.Serializable]
public class ExpirationState
{
    public bool expired;

    public ExpirationState(bool expired)
    {
        this.expired = expired;
    }
}

[System.Serializable]
public class DateOfExpiration
{
    public int year;
    public int month;
    public int day;
    public int hour;
    public float min;
    public float timerExpiration;

    public DateOfExpiration(int year, int month, int day, int hour, float min, float timer)
    {
        this.year = year;
        this.month = month;
        this.day = day;
        this.hour = hour;
        this.min = min;
        this.timerExpiration = timer;
    }
}