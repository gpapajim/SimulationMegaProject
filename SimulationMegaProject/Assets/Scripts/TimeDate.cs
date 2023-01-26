using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeDate : MonoBehaviour
{
    private int day;
    private int month;
    private int year;
    private int hour;
    private int min;



    public void Update()
    {
        day = System.DateTime.Now.Day;
        month = System.DateTime.Now.Month;
        year = System.DateTime.Now.Year;
        hour = System.DateTime.Now.Hour;
        min = System.DateTime.Now.Minute;

        if (hour < 10 & min > 9)
        {
            gameObject.transform.GetChild(5).GetComponent<TMPro.TextMeshProUGUI>().text= "0" + hour + " : " + "" + min;
        }
        if (min < 10 & hour > 9)
        {
            gameObject.transform.GetChild(5).GetComponent<TMPro.TextMeshProUGUI>().text = "" + hour + " : " + "0" + min;
        }
        if (min < 10 & hour < 10)
        {
            gameObject.transform.GetChild(5).GetComponent<TMPro.TextMeshProUGUI>().text = "0" + hour + " : " + "0" + min;
        }
        if (min > 9 & hour > 9)
        {
            gameObject.transform.GetChild(5).GetComponent<TMPro.TextMeshProUGUI>().text = "" + hour + " : " + "" + min;
        }
    }
    public void ShowDate()
    {
        
        gameObject.transform.GetChild(4).GetComponent<TMPro.TextMeshProUGUI>().text = "" + year + "   -    " + "" + month + "." + "   " + day;
    }
    public void HideDate()
    {
        
    }
    public void ShowTime()
    {
        gameObject.transform.GetChild(5).gameObject.SetActive(true);
    }
    public void HideTime()
    {
        gameObject.transform.GetChild(5).gameObject.SetActive(false);
    }
}
