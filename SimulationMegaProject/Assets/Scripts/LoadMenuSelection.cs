using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMenuSelection : MonoBehaviour
{
    public void MenuSelection()
    {
        SceneManager.LoadSceneAsync("MenuSelection");
        Cursor.visible = true;
    }
}
