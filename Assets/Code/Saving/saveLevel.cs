using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saveLevel : MonoBehaviour
{
    [SerializeField] private GameObject building;
    [SerializeField] private String buildingName;

    private int levelOfBuilding;

    public int lvlOfBuilding
    {
        get { return levelOfBuilding; }
    }
    
    // Start is called before the first frame update
    private void Start()
    {
        GetLevel();
    }

    // Update is called once per frame
    private void Update()
    {
        SaveBuildingLevel();
    }

    private void SaveBuildingLevel()
    {
        PlayerPrefs.SetInt(buildingName, building.GetComponent<UpgradeSystem>().current_lvl);
    }

    private void GetLevel()
    {
        levelOfBuilding = PlayerPrefs.GetInt(buildingName, 0);
    }
}