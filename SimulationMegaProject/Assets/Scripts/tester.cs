using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tester : MonoBehaviour
{
    public GameObject gasnumbers;
    public GameObject alarmLights;
    public float alarmtimer;

    public float o2;
    
    // Start is called before the first frame update
    void Start()
    {
        //alarmtimer = 1;
        //alarmLights.GetComponent<Lights_Manager>().TimerSelector(alarmtimer);
    }

    // Update is called once per frame
    void Update()
    {
        /* foreach(Gas g in gasnumbers.GetComponent<GasNumbers>().gases)
         {
             if(g.name=="o2")
             {
                 g.number = o2;
            }
         }*/
    }
}
