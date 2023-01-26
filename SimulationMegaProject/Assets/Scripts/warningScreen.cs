using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class warningScreen : MonoBehaviour
{
    public GameObject gasNumbers;

    public void ShowWarning()
    {
        gasNumbers.gameObject.SetActive(true);
        gameObject.transform.GetChild(3).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "WARNING";
    }
    public void HideWarning()
    {
        gameObject.transform.GetChild(3).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = null;
    }
}
