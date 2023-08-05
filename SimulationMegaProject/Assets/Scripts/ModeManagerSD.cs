using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeManagerSD : MonoBehaviour
{
    public bool normalMode;
    public bool maintenanceMode;
    public bool maintenanceMode2;
    public bool maintenanceMode2_0;
    public bool maintenanceMode2_0Menu;
    public bool Conn;
    public bool maintenanceMode3;
    public bool maintenanceMode4;

    public int current;

    public void Start()
    {
        current = Random.Range(1950,2050);
    }
}
