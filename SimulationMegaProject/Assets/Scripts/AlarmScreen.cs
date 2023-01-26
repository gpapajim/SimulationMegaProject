using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmScreen : MonoBehaviour
{
    public GameObject gasNumbers;

    public void ShowAlarm()
    {
        gasNumbers.gameObject.SetActive(true);
        gameObject.transform.GetChild(3).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "ALARM";
    }
    public void HideAlarm()
    {
        gameObject.transform.GetChild(3).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = null;
    }
}
