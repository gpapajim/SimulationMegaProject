using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupGas : MonoBehaviour
{
    public GameObject gx2009;
    public GameObject gasNumbers;
    public GameObject extras;
    public GameObject gasBottle;
    [Space]
    public float increaseTimer;
    [Space]
    public float o2;
    public float ch4;
    public float h2s;
    public float co;



    private void Awake()
    {
        increaseTimer = 1.5f;
    }


    void Update()
    {

        
        if (gasBottle.GetComponent<Bottle>().bottleOnOff == true)
        {
            increaseTimer -= Time.deltaTime;
            ///////////////////////////////////////fix gas
            if (o2>12 & increaseTimer<0)
            {
                o2 -= Random.Range(0.1f, 0.3f);
            }
            if (o2<12)
            {
                o2 = 12;
            }
            if (ch4<50 & increaseTimer<0)
            {
                ch4 += Random.Range(1, 4);
            }
            if (ch4>50)
            {
                ch4 = 50;
            }
            if (h2s <25 & increaseTimer < 0)
            {
                h2s += Random.Range(1, 3);
            }
            if (h2s > 25)
            {
                o2 = 25;
            }
            if (co < 50 & increaseTimer < 0)
            {
                co += Random.Range(1, 4);
            }
            if (co > 50)
            {
                co = 50;
            }
            gasNumbers.GetComponent<GasNumbers>().GasNumbersUpdate(o2, ch4, h2s, co);//update screen
            if (increaseTimer<0)
            {
                increaseTimer = 1.5f;
            }
        }
    }
}
