using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class DateTime8000 : MonoBehaviour
{
    
    public TextMeshProUGUI time;
    
    public TextMeshProUGUI date;

    void Update()
    {
        int hour = System.DateTime.Now.Hour;
        int min = System.DateTime.Now.Minute;
        int day = System.DateTime.Now.Day;
        int month = System.DateTime.Now.Month;
        int year = System.DateTime.Now.Year;
        

        time.text = hour.ToString("00") + ":" + min.ToString("00");
        date.text = year.ToString("0000") + "  - " + month.ToString("00") + ". " + day.ToString("00");
    }
}
