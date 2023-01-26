using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoltBattery : MonoBehaviour
{

    public void ShowVolt()
    {
        
        gameObject.transform.GetChild(3).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "AL -- H";
        gameObject.transform.GetChild(4).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "BATT.";
        gameObject.transform.GetChild(7).gameObject.SetActive(true);
    }
    public void  HideVolt()
    {
        gameObject.transform.GetChild(3).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = null;
        gameObject.transform.GetChild(4).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = null;
        gameObject.transform.GetChild(7).gameObject.SetActive(false);
    }
}
