using UnityEngine;

public class CursorSd1rdi : MonoBehaviour
{
    public void Start()
    {
        //Cursor.visible = false;
    }

    private void Update()
    {
        transform.position = Input.mousePosition;
    }
}
