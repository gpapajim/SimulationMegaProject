using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSd1rdi : MonoBehaviour
{
    public void Sd1rdi()
    {
        SceneManager.LoadSceneAsync("SD-1DRI");
        Cursor.visible = false;
    }
}
