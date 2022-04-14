using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class UpgradeSystem : MonoBehaviour
{
    // The upgrade button of the building
    [SerializeField] private GameObject upgradeButton;

    // ScoreManager is used to track all scores, and here it is
    // used to receive the value of the yellow score
    [SerializeField] private GameObject scoreManager;

    // Used to access the saved level of the building
    [SerializeField] private GameObject building;
    
    // Scorethresholds for upgrades
    [SerializeField] private int thresholdOneValue;
    [SerializeField] private int thresholdTwoValue;
    
    // Scoremodifiers that increase the score gained after upgrades
    [SerializeField] private float scoreModifierLvl1 = 1;
    [SerializeField] private float scoreModifierLvl2 = 1;
    
    // Define spawnerobjects here to use scripts from them to increase deliveryguy amount
    [SerializeField] private GameObject AreaTwoSpawner;
    [SerializeField] private GameObject AreaThreeSpawner;
    [SerializeField] private GameObject AreaFourSpawner;
    [SerializeField] private GameObject AreaFiveSpawner;
    
    // Used to track the scoremodifier given by level and sent onward to be used in another script
    private float scoreModifier = 1;

    // Bools to track if scorethreshold has been achieved
    private bool thresholdOne = false;
    private bool thresholdTwo = false;
    
    public GameObject[] levels;
    private int current_level;

    public int current_lvl
    {
        get { return current_level; }
    }

    public float scoreMod
    {
        get { return scoreModifier; }
    }

    private void Start()
    {
        if (building.GetComponent<saveLevel>().lvlOfBuilding != 0)
        {
            current_level = building.GetComponent<saveLevel>().lvlOfBuilding;
        }
        SwitchObject(current_level);
    }

    public void Update()
    {
        CheckScore();
        ActivateButton();
    }

    public void Upgrade()
    {
        if (current_level < levels.Length - 1)
        {
            current_level++;
            SwitchObject(current_level);
            UpdateModifier();
            upgradeButton.SetActive(false);
            building.GetComponent<saveLevel>().SaveBuildingLevel();
        }
    }

    private void SwitchObject(int lvl)
        {
            for (int i = 0; i < levels.Length; i++)
            {
                if (i == lvl)
                {
                    levels[i].SetActive(true);
                }
                else
                {
                    levels[i].SetActive(false);
                }
            }
        }
    
    // Check if score is over thresholds, if yes, then modify the corresponding bool
    private void CheckScore()
    {
        if (scoreManager.GetComponent<ScoreManager>().YellowScore > thresholdOneValue)
        {
            thresholdOne = true;
        }

        if (scoreManager.GetComponent<ScoreManager>().YellowScore > thresholdTwoValue)
        {
            thresholdTwo = true;
        }
    }

    // Method to activate button 1
    private void ActivateButton()
    {
        if (thresholdOne && current_lvl == 0)
        {
            upgradeButton.SetActive(true);
        }
        else if (thresholdTwo && current_lvl == 1)
        {
            upgradeButton.SetActive(true);
        }
    }

    private void UpdateModifier()
    {
        if (current_lvl == 1)
        {
            scoreModifier = scoreModifierLvl1;
        }
        else if (current_lvl == 2)
        {
            scoreModifier = scoreModifierLvl2;
        }
    }
}