using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirTouch : MonoBehaviour
{
    public bool touched;

    public void Touched()
    {
        touched = true;
    }

    public void NotTouched()
    {
        touched = false;
    }
}
