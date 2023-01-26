using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGx8000 : MonoBehaviour
{
    public void Gx8000()
    {
        SceneManager.LoadSceneAsync("GX8000");
        Cursor.visible = true;
    }
}