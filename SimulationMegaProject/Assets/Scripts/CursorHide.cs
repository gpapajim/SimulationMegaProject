using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorHide : MonoBehaviour
{
    public ModeManager805 modeManager;
 
    void Update()
    {
        transform.position = Input.mousePosition;
    }

    public void CursorState()
    {
       /* if (modeManager.activation == true)
        {
            Cursor.visible = false;
        }
        if (modeManager.activation == false)
        {
            Cursor.visible = true;
        }*/
    }
}
