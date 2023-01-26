using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSelector : MonoBehaviour
{
    private static SceneSelector sceneSelector;

    

    public void Awake()
    {
        if (sceneSelector == null)
        {
            sceneSelector = this;
        }
        else
        {
            Destroy(this);
        }

        DontDestroyOnLoad(this);
    }

    public void MenuSelection()
    {
        SceneManager.LoadSceneAsync("MenuSelection");
    }

    public void Expired()
    {
        SceneManager.LoadSceneAsync("Expired");
    }

    public void GX2009()
    {
        SceneManager.LoadSceneAsync("GX-2009");
    }
}
