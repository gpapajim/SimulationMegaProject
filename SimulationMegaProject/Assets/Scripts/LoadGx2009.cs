using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGx2009 : MonoBehaviour
{
    public void GX2009()
    {
        SceneManager.LoadSceneAsync("GX-2009");
        Cursor.visible = true;
    }
}
