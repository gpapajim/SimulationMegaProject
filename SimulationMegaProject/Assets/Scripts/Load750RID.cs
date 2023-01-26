using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load750RID : MonoBehaviour
{
    public void SD750RID()
    {
        SceneManager.LoadSceneAsync("750RID");
        Cursor.visible = false;
    }
}
