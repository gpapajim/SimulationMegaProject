using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GasDataSD10X : MonoBehaviour
{
    public FloatVariableSD10X gas;

    public TextMeshProUGUI text;

    public void Update()
    {
        text.text = gas.Value.ToString("00");
    }
}