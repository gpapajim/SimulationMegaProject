using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrialOK : MonoBehaviour
{
    public ExpirationManager expirationManager;

    public void OKTrial()
    {
        expirationManager.trialOpen = false;

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("MenuSelection"))
        {
            Cursor.visible = true;
        }

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("750RID"))
        {
            Cursor.visible = false;
        }

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("GX-2009"))
        {
            Cursor.visible = true;
        }

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("805RI"))
        {
            Cursor.visible = false;
        }

    }
}
