using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasNumberMap : MonoBehaviour
{
    public GameObject gasNumber;
    

    private string gasName;

    private void Awake()
    {
        gasName = gameObject.name;
    }
    private void Update()
    {
        foreach(Gas g in gasNumber.GetComponent<GasNumbers>().gases)
        {
            if(gasName==g.name)//map the gases from the base to the text.objects
            {

                gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = g.onScreen.ToString();
                
            }
            if(gasName==g.name&g.inFloat==true)
            {
                gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = g.onScreen.ToString("0.0");//force the one decimal
            }
            
        }
    }
}
