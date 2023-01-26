using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

//attach this to the button you want to animate
public class ButtonAnimationR : MonoBehaviour
{
    public ButtonManager8000 buttonManager;

    public void Update()
    {
        if (buttonManager.R)
        {
            FadeToColor(this.GetComponent<Button>().colors.pressedColor);
        }
        else
        {
            FadeToColor(this.GetComponent<Button>().colors.normalColor);
        }
        
    }

    void FadeToColor(Color color)
    {
        Graphic graphic = GetComponent<Graphic>();
        graphic.CrossFadeColor(color, this.GetComponent<Button>().colors.fadeDuration, true, true);
    }
}
