using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeAvailable : MonoBehaviour
{
    // Define the text gameobject here
    [SerializeField] private GameObject text;

    // Bool used to track if an upgradebutton is active
    private bool upgradeAvailable = false;

    // Update is called once per frame
    private void Update()
    {
        CheckUpdateAvailability();
        ToggleText();
    }

    // Check if any of the upgradebuttons is active
    private void CheckUpdateAvailability()
    {
        if (!GameObject.Find("UpgradeButtonArea"))
        {
            upgradeAvailable = false;
            return;
        }
        
        upgradeAvailable = true;
    }

    // Display "upgrade is available" text if an upgradebutton is active
    private void ToggleText()
    {
        if (!upgradeAvailable)
        {
            text.SetActive(false);
            return;
        }

        text.SetActive(true);
    }
}
