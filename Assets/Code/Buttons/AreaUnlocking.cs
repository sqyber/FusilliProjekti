using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaUnlocking : MonoBehaviour
{
    [SerializeField] private GameObject building;
    [SerializeField] private GameObject nextAreaPlus;
    [SerializeField] private GameObject nextAreaLogistics;

    private bool buildingLvl2 = false;

    // Update is called once per frame
    private void Update()
    {
        CheckLevel();
        ActivateButtons();
        DeactivateButtons();
    }

    // Check if areas upgradeable building is lvl 2, if yes then set bool to true
    private void CheckLevel()
    {
        if (building.GetComponent<UpgradeSystem>().current_lvl == 2)
        {
            buildingLvl2 = true;
        }
    }

    // Activate next areas buttons, if current areas building is lvl 2
    private void ActivateButtons()
    {
        if (!buildingLvl2) return;
        
        nextAreaPlus.SetActive(true);
        nextAreaLogistics.SetActive(true);
    }

    // Keep buttons deactivated, if current areas building isn't lvl 2
    private void DeactivateButtons()
    {
        if (buildingLvl2) return;
        
        nextAreaPlus.SetActive(false);
        nextAreaLogistics.SetActive(false);
    }
}