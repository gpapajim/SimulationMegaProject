using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonMap : MonoBehaviour
{
    public KeyCode _key;


    public GameObject buttonManager;
    private Button _button;
    private string keyName;

    private void Awake()
    {
        
        keyName = gameObject.name;
        _button = GetComponent<Button>();
        
        foreach(CustomButton b in buttonManager.GetComponent<ButtonManager>().buttons)//vriskei to katallhlo button me vash to onoma
        {
            if(keyName==b.name)
            {
                _key = b._key;
            }
        }
    }

    private void Update()
    {
        keyName = gameObject.name;
        _button = GetComponent<Button>();


        foreach (CustomButton b in buttonManager.GetComponent<ButtonManager>().buttons)//vriskei to katallhlo button me vash to onoma
        {
            if (keyName == b.name)
            {
                _key = b._key;
            }
        }

        if (Input.GetKeyDown(_key))
        {
            FadeToColor(_button.colors.pressedColor);//animation oti to patas
        }
        if (Input.GetKeyUp(_key))
        {
            FadeToColor(_button.colors.normalColor);
        }


    }

    void FadeToColor(Color color)
    {
        Graphic graphic = GetComponent<Graphic>();
        graphic.CrossFadeColor(color, _button.colors.fadeDuration, true, true);
    }

    
}

