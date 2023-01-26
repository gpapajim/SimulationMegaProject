using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GasDataF18000 : MonoBehaviour
{
    public FloatReference gas;

    public TextMeshProUGUI text;

    public void Update()
    {
        text.text = gas.Value.ToString("F1");
    }
}
