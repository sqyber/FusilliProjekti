using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saveLevel : MonoBehaviour
{
    [SerializeField] private GameObject building;
    [SerializeField] private String buildingName;

    [SerializeField] private GameObject reset;

    private int levelOfBuilding;

    public int lvlOfBuilding
    {
        get { return levelOfBuilding; }
    }
    
    // Start is called before the first frame update
    private void Awake()
    {
        if (reset.GetComponent<ResetScore>().tglLvlReset == false)
        {
            GetLevel();
        }
    }

    // Update is called once per frame
    private void Update()
    {
        SaveBuildingLevel();
    }

    // Save buildings current level to playerprefs
    public void SaveBuildingLevel()
    {
        PlayerPrefs.SetInt(buildingName, building.GetComponent<UpgradeSystem>().current_lvl);
    }

    // Get the buildings level from playerprefs
    private void GetLevel()
    {
        levelOfBuilding = PlayerPrefs.GetInt(buildingName, 0);
    }
    
    // Function used to reset stored levels
    public void SetBuildingToZero()
    {
        levelOfBuilding = 0;
    }
}
