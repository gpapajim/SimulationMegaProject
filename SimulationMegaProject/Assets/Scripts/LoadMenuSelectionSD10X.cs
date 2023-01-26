using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMenuSelectionSD10X : MonoBehaviour
{
    public void MenuSelection()
    {
        SceneManager.LoadSceneAsync("MenuSelection");
        Cursor.visible = true;
    }
}
