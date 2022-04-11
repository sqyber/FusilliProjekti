using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class UpgradeSystem : MonoBehaviour
{
    // The upgrade buttons of the building
    [SerializeField] private GameObject upgradeButton1;
    [SerializeField] private GameObject upgradeButton2;
    
    // The building that is being upgraded and modified
    [SerializeField] private GameObject building;
    
    // ScoreManager is used to track all scores, and here it is
    // used to receive the value of the yellow score
    [SerializeField] private GameObject scoreManager;
    
    // Scorethresholds for upgrades
    [SerializeField] private int thresholdOneValue;
    [SerializeField] private int thresholdTwoValue;
    
    // Bools to track if scorethreshold has been achieved
    private bool thresholdOne = false;
    private bool thresholdTwo = false;
    
    public GameObject[] levels;
    private int current_level = 0;

    public int current_lvl
    {
        get { return current_level; }
    }

    private void Start()
    {
        SwitchObject(current_level);
    }

    public void Update()
    {
        CheckScore();
        ActivateButton();
        ActivateButton2();
    }

    public void Upgrade()
    {
        if (current_level < levels.Length - 1)
        {
            current_level++;
            SwitchObject(current_level);
            upgradeButton1.SetActive(false);
            upgradeButton2.SetActive(false);
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
        if (thresholdOne && building.GetComponent<UpgradeSystem>().current_lvl == 0)
        {
            upgradeButton1.SetActive(true);
        }
    }

    // Method to activate button 2
    private void ActivateButton2()
    {
        if (thresholdTwo && building.GetComponent<UpgradeSystem>().current_lvl == 1)
        {
            upgradeButton2.SetActive(true);
        }
    }
}