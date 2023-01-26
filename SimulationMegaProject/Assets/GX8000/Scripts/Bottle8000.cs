using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bottle8000 : MonoBehaviour
{
    public bool bottleOnOffVol;
    public bool bottleOnOffLel;
    
    public GameObject bottleVol;
    public GameObject bottleLel;

    

    public void Update()
    {
        

    }

    public void ConnectedVol()
    {
        if(bottleOnOffVol)
        {
            bottleOnOffVol = false;
        }
        else
        {
            bottleOnOffVol = true;
        }
    }

    public void DisConnectedVol()
    {
        bottleOnOffVol = false;
    }

    public void ConnectedLel()
    {
        if(bottleOnOffLel)
        {
            bottleOnOffLel = false;
        }
        else
        {
            bottleOnOffLel = true;
        }
        
    }

    public void DisConnectedLel()
    {
        bottleOnOffLel = false;
    }

    public void ShowBottle()
    {
        gameObject.SetActive(true);
    }
    public void HideBottle()
    {
        gameObject.SetActive(false);
    }


    void FadeToColor(Color color)
    {
        Graphic graphic = GetComponent<Graphic>();
        graphic.CrossFadeColor(color, this.GetComponent<Button>().colors.fadeDuration, true, true);
    }
}
