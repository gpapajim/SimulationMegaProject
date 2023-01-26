using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MappingButtonAir : MonoBehaviour
{
    public GameObject buttonManager;
    public KeyCode key;

    void Update()
    {
        gameObject.transform.GetChild(0).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = key.ToString();
    }
    public void MapKey()
    {
        gameObject.transform.GetChild(0).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = key.ToString();
        buttonManager.GetComponent<ButtonManager>().airSingle._key = key;
    }
}
