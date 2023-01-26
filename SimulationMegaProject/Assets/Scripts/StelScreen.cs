using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StelScreen : MonoBehaviour
{
    public GameObject gasNumbers;

    public void ShowStel()
    {
        gasNumbers.gameObject.SetActive(true);
        gasNumbers.transform.GetChild(1).gameObject.SetActive(false);
        gasNumbers.transform.GetChild(2).gameObject.SetActive(false);
        gameObject.transform.GetChild(3).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "STEL";
    }
    public void HideStel()
    {
        gasNumbers.transform.GetChild(1).gameObject.SetActive(true);//trying to reset them maybe wrong move
        gasNumbers.transform.GetChild(2).gameObject.SetActive(true);//
        gameObject.transform.GetChild(3).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = null;
    }
}
