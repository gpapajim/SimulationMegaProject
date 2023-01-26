using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalOperation : MonoBehaviour
{
    
    public GameObject extras;
    public GameObject gasNumbers;
    public GameObject warning;
    


    public void Update()
    {
        if(gameObject.GetComponent<OpeningScreen>().normalOperation==true)//setting the normal operation screen
        {
            if (warning.GetComponent<Warning>().warningStart == false
                & warning.GetComponent<Warning>().warningOn==false
                & gameObject.GetComponent<AirClean>().airCalStart==false
                & gameObject.GetComponent<AirClean>().endAirCal==false)//stops updating when warning/alarm starts(notyet)
            {
            gasNumbers.gameObject.SetActive(true);
            extras.transform.GetChild(5).gameObject.SetActive(true);
            extras.transform.GetChild(2).gameObject.SetActive(true);
            extras.transform.GetChild(0).gameObject.SetActive(true);
            gasNumbers.GetComponent<GasNumbers>().GasNumbersUpdate(20.9f, 0, 0, 0);
            }
        }
        if (gameObject.GetComponent<OpeningScreen>().normalOperation == false
            & gameObject.GetComponent<OpeningScreen>().startingScreenStart == false
            & gameObject.GetComponent<OneCal>().inOneCal == false////////
            & gameObject.GetComponent<CalibrationMode>().inMode==false)//blockarei na emfanizontai sto starting meta thn prwth fora 
        {
            gasNumbers.gameObject.SetActive(false);//ta noumera tou normal
            extras.transform.GetChild(0).gameObject.SetActive(false);//ta onomata twn gas
        }
    }
}
