using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErrorSD10X : MonoBehaviour
{
    public ScreenManagerSD10X screenManager;
    public ModeManagerSD10X modeManager;

    public bool error1;
    public bool error2;
    public int randomSelector;


    public void Update()
    {
        
        if (!modeManager.normalMode)
        {
            screenManager.error.SetActive(false);
            screenManager.score1.SetActive(false);
        }

        if (modeManager.normalMode && error1)
        {
            
        }
        
    }

    public void Error1()
    {
        error1 = true;
            screenManager.dataObj.SetActive(false);
            screenManager.dot.DotsControl(false, false, false, false);
            screenManager.error.SetActive(true);
        
    }

    public void Error2()
    {
        error2 = true;
        randomSelector = Random.Range(0, 2);
        if (randomSelector == 0)
        {
            screenManager.score1.SetActive(true);
        }
        if (randomSelector == 1)
        {
            screenManager.C4H10.Value = Random.Range(185, 250);
        }
    }

    public void Erro1Set()
    {
        
    }
}
