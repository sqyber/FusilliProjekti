using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButtonExit : MonoBehaviour
{
    [SerializeField] private GameObject exitMenu;
    private void Update()
    {
        if (Input.GetKey("escape"))
        {
            exitMenu.SetActive(true);
        }
    }
}
