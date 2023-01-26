using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager750 : MonoBehaviour
{
    public GameObject pwLight;
    public GameObject alLight;
    public GameObject al2Light;
    public GameObject skipLight;
    public GameObject lelLight;
    public GameObject zeroLight;
    public GameObject spanLight;
    public GameObject maLight;
    [Header("checks")]
    public bool pw;
    public bool al;
    public bool al2;
    public bool skip;
    public bool lel;
    public bool zero;
    public bool span;
    public bool ma;
    public bool blinking;//all
    public bool blinkingPw;
    public bool blinkingAl;
    public bool blinkingAl2;
    public bool blinkingSkip;
    public bool blinkingSpan;
    public bool blinkingZero;
    public bool blinkingLel;
    public bool blinkingMa;

    public bool open;
    [Header("timer")]
    public float timer;


    public void Awake()
    {
        timer = 0.5f;
    }

    public void Update()
    {
        ///////////////////////blinking activation
        if(blinking==true)
        {
            timer -= Time.deltaTime;
        }

        if(blinking==true && timer<0)
        {
            timer = 0.5f;
            if(open==true)
            {
                open = false;
            }
            else
            {
                open = true;
            }
        }

        if(blinking==false)
        {
            timer = 0.5f;
        }
        ////////////////////////////////////////

        ////////////////////////managing lights

        if(blinkingPw == false && pw==true)
        {
            pwLight.SetActive(true);
        }
        if(pw==false)
        {
            pwLight.SetActive(false);
        }

        if(blinkingLel == false && lel==true)
        {
            lelLight.SetActive(true);
        }
        if(lel==false)
        {
            lelLight.SetActive(false);
        }
        
        if(blinkingSkip == false && skip==true)
        {
            skipLight.SetActive(true);
        }
        if(skip==false)
        {
            skipLight.SetActive(false);
        }

        if(blinkingAl == false && al==true)
        {
            alLight.SetActive(true);
        }
        if(al==false)
        {
            alLight.SetActive(false);
        }

        if(blinkingAl2 == false && al2==true)
        {
            al2Light.SetActive(true);
        }
        if(al2==false)
        {
            al2Light.SetActive(false);
        }

        if(blinkingSpan == false && span==true)
        {
            spanLight.SetActive(true);
        }
        if(span==false)
        {
            spanLight.SetActive(false);
        }

        if(blinkingMa == false && ma==true)
        {
            maLight.SetActive(true);
        }
        if(ma==false)
        {
            maLight.SetActive(false);
        }
        
        if(blinkingZero == false && zero==true)
        {
            zeroLight.SetActive(true);
        }
        if(zero==false)
        {
            zeroLight.SetActive(false);
        }
        /////////////////////////////////////////

        


        /////////////////////////////blinking of lights 
        if(blinkingSkip == true && timer>0 && open == false && skip == true)//for each blinking light
        {
            skipLight.SetActive(true);
            
        }
        if(blinkingSkip == true && timer>0 && open == true && skip == true)
        {
            skipLight.SetActive(false);
            
        }

        if(blinkingPw == true && timer > 0 && open == false && pw == true)//for each blinking light
        {
            pwLight.SetActive(true);

        }
        if(blinkingPw == true && timer > 0 && open == true && pw == true)
        {
            pwLight.SetActive(false);

        }

        if(blinkingLel == true && timer > 0 && open == false && lel == true)//for each blinking light
        {
            lelLight.SetActive(true);

        }
        if(blinkingLel == true && timer > 0 && open == true && lel == true)
        {
            lelLight.SetActive(false);

        }

        if(blinkingAl == true && timer > 0 && open == false && al == true)//for each blinking light
        {
            alLight.SetActive(true);

        }
        if(blinkingAl == true && timer > 0 && open == true && al == true)
        {
            alLight.SetActive(false);

        }

        if(blinkingAl2 == true && timer > 0 && open == false && al2 == true)//for each blinking light
        {
            al2Light.SetActive(true);

        }
        if(blinkingAl2 == true && timer > 0 && open == true && al2 == true)
        {
            al2Light.SetActive(false);

        }

        if(blinkingSpan == true && timer > 0 && open == false && span == true)//for each blinking light
        {
            spanLight.SetActive(true);

        }
        if(blinkingSpan == true && timer > 0 && open == true && span == true)
        {
            spanLight.SetActive(false);

        }

        if(blinkingMa == true && timer > 0 && open == false && ma == true)//for each blinking light
        {
            maLight.SetActive(true);

        }
        if(blinkingMa == true && timer > 0 && open == true && ma == true)
        {
            maLight.SetActive(false);

        }

        if(blinkingZero == true && timer > 0 && open == false && zero == true)//for each blinking light
        {
            zeroLight.SetActive(true);

        }
        if(blinkingZero == true && timer > 0 && open == true && zero == true)
        {
            zeroLight.SetActive(false);

        }
        /////////////////////////////////////////////////
    }

}
