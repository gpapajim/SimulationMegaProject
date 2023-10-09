using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Help : MonoBehaviour
{
    public GameObject helpText;

    public bool activated;

    public void ActivateText()
    {
        if (!activated)
        {
            helpText.gameObject.SetActive(true);
            activated = true;
            return;
        }
        if (activated)
        {
            helpText.gameObject.SetActive(false);
            activated = false;
        }

    }

    
}

