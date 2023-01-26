using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GasData8000 : MonoBehaviour
{
    public FloatReference gas;

    public TextMeshProUGUI text;

    public void Update()
    {
        text.text = gas.Value.ToString();
    }
}
