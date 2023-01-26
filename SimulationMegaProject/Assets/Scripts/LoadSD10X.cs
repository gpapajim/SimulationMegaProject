using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSD10X : MonoBehaviour
{
    public void Sd10X()
    {
        SceneManager.LoadSceneAsync("SD-10X");
        Cursor.visible = false;
    }
}
