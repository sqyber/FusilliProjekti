using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetGame : MonoBehaviour
{
    [SerializeField] private GameObject Henhouse;
    [SerializeField] private GameObject Garden;
    [SerializeField] private GameObject Farm;
    [SerializeField] private GameObject Greenhouse;
    [SerializeField] private GameObject Roofgarden;
    
    public void ResetButton()
    {
        SetPlayerPrefsToZero();
        SetScriptValuesToZero();
        ReloadScene();
    }

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

    private void ReloadScene()
    {
        SceneManager.LoadScene("SampleScene");
    }

    private void SetScriptValuesToZero()
    {
        // Set UpgradeSystems current_level to 0
        Henhouse.GetComponent<UpgradeSystem>().SetLevelToZero();
        Garden.GetComponent<UpgradeSystem>().SetLevelToZero();
        Farm.GetComponent<UpgradeSystem>().SetLevelToZero();
        Greenhouse.GetComponent<UpgradeSystem>().SetLevelToZero();
        Roofgarden.GetComponent<UpgradeSystem>().SetLevelToZero();
        
        // Set saveLevels levelOfBuilding to 0
        Henhouse.GetComponent<saveLevel>().SetBuildingToZero();
        Garden.GetComponent<saveLevel>().SetBuildingToZero();
        Farm.GetComponent<saveLevel>().SetBuildingToZero();
        Greenhouse.GetComponent<saveLevel>().SetBuildingToZero();
        Roofgarden.GetComponent<saveLevel>().SetBuildingToZero();
    }
}
