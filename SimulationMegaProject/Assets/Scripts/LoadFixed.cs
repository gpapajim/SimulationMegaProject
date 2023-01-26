using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadFixed : MonoBehaviour
{
    public void Fixed()
    {
        SceneManager.LoadSceneAsync("Fixed");
        Cursor.visible = true;
    }
}
