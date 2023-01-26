using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    public FloatReference gasValue;




    public void Update()
    {
        slider.value = gasValue.variable.Value;
    }
}
