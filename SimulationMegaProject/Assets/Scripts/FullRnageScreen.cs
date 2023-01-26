using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullRnageScreen : MonoBehaviour
{
    public GameObject gasNumbers;
    

   public void ShowFull()
    {
        gasNumbers.gameObject.SetActive(true);
        gameObject.transform.GetChild(3).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "F. S.";
    
    } 
    public void HideFull()
    {
        gameObject.transform.GetChild(3).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = null;
    }
}
