using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetGame : MonoBehaviour
{
    // Upgradeable building of each area so that the component values from them
    // can be reset
    [SerializeField] private GameObject henhouse;
    [SerializeField] private GameObject garden;
    [SerializeField] private GameObject farm;
    [SerializeField] private GameObject greenhouse;
    [SerializeField] private GameObject roofgarden;

    // Public function used in the reset button
    public void ResetButton()
    {
        SetPlayerPrefsToZero();
        SetScriptValuesToZero();
    }

    // Set playerprefs to zero on reset
    private void SetPlayerPrefsToZero()
    {
        // Score playerprefs
        PlayerPrefs.SetInt("GreenScore", 0);
        PlayerPrefs.SetInt("YellowScore", 0);
        
        // Building playerprefs
        PlayerPrefs.SetInt("Garden", 0);
        PlayerPrefs.SetInt("Greenhouse", 0);
        PlayerPrefs.SetInt("Henhouse", 0);
        PlayerPrefs.SetInt("Farm", 0);
        PlayerPrefs.SetInt("Roofgarden", 0);
    }

    // Set values in scripts to zero on reset
    private void SetScriptValuesToZero()
    {
        // Set UpgradeSystems current_level to 0
        henhouse.GetComponent<UpgradeSystem>().SetLevelToZero();
        garden.GetComponent<UpgradeSystem>().SetLevelToZero();
        farm.GetComponent<UpgradeSystem>().SetLevelToZero();
        greenhouse.GetComponent<UpgradeSystem>().SetLevelToZero();
        roofgarden.GetComponent<UpgradeSystem>().SetLevelToZero();
        
        // Set saveLevels levelOfBuilding to 0
        henhouse.GetComponent<saveLevel>().SetBuildingToZero();
        garden.GetComponent<saveLevel>().SetBuildingToZero();
        farm.GetComponent<saveLevel>().SetBuildingToZero();
        greenhouse.GetComponent<saveLevel>().SetBuildingToZero();
        roofgarden.GetComponent<saveLevel>().SetBuildingToZero();
    }
}
