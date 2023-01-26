using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load805RI : MonoBehaviour
{
    public void SD805RI()
    {
        SceneManager.LoadSceneAsync("805RI");
        Cursor.visible = false;
    }
}
