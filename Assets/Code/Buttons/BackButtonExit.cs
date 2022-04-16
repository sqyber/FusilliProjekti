using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButtonExit : MonoBehaviour
{
    [SerializeField] private GameObject exitMenu;
    
    // If the back button on a mobile device is tapped open the exitmenu
    private void Update()
    {
        if (Input.GetKey("escape"))
        {
            exitMenu.SetActive(true);
        }
    }
}
