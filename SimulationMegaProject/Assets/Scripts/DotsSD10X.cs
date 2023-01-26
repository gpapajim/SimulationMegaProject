using UnityEngine;

public class DotsSD10X : MonoBehaviour
{
    public GameObject dot1;
    public GameObject dot2;
    public GameObject dot3;
    public GameObject dot4;


    public void DotsControl(bool d1, bool d2, bool d3, bool d4)
    {
        if(d1)
        {
            dot1.SetActive(true);
        }
        if(!d1)
        {
            dot1.SetActive(false);
        }

        if (d2)
        {
            dot2.SetActive(true);
        }
        if (!d2)
        {
            dot2.SetActive(false);
        }

        if (d3)
        {
            dot3.SetActive(true);
        }
        if (!d3)
        {
            dot3.SetActive(false);
        }

        if (d4)
        {
            dot4.SetActive(true);
        }
        if (!d4)
        {
            dot4.SetActive(false);
        }
    }

    public void Dot1On()
    {
        dot1.SetActive(true);
    }

    public void Dot2On()
    {
        dot2.SetActive(true);
    }

    public void Dot3On()
    {
        dot3.SetActive(true);
    }

    public void Dot4On()
    {
        dot4.SetActive(true);
    }

    public void Dot1Off()
    {
        dot1.SetActive(false);
    }

    public void Dot2Off()
    {
        dot2.SetActive(false);
    }

    public void Dot3Off()
    {
        dot3.SetActive(false);
    }

    public void Dot4Off()
    {
        dot4.SetActive(false);
    }

}
