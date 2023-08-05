using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Credits : MonoBehaviour
{
    public GameObject creditText;

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)) && (Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt))
            && (Input.GetKey(KeyCode.C) || (Input.GetKey(KeyCode.R) || (Input.GetKey(KeyCode.E)))))
        {
            creditText.SetActive(true);
        }

        else
        {
            creditText.SetActive(false);
        }
    }
}
