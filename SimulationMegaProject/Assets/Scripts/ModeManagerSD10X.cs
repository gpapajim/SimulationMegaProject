using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeManagerSD10X : MonoBehaviour
{
    public bool normalMode;
    public bool maintenanceMode;
    public bool maintenanceMode2;
    public bool maintenanceMode3;
    public bool maintenanceMode4;

    public int current;

    public void Start()
    {
        current = Random.Range(1950,2050);
    }
}
