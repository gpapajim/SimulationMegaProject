using UnityEngine;

public class CursorSD10X : MonoBehaviour
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
