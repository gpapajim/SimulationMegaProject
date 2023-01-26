using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GasData : MonoBehaviour
{
    public FloatVariableSD gas;

    public TextMeshProUGUI text;

    public void Update()
    {
        text.text = gas.Value.ToString("00");
    }
}