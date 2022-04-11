using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class UpgradeSystem : MonoBehaviour
{
    // The upgrade buttons of the building
    [SerializeField] private GameObject upgradeButton1;
    [SerializeField] private GameObject upgradeButton2;

    // ScoreManager is used to track all scores, and here it is
    // used to receive the value of the yellow score
    [SerializeField] private GameObject scoreManager;
    
    // Scorethresholds for upgrades
    [SerializeField] private int thresholdOneValue;
    [SerializeField] private int thresholdTwoValue;
    
    // Scoremodifiers that increase the score gained after upgrades
    [SerializeField] private float scoreModifierLvl1 = 1;
    [SerializeField] private float scoreModifierLvl2 = 1;
    
    // Used to track the scoremodifier given by level and sent onward to be used in another script
    private float scoreModifier = 1;

    // Bools to track if scorethreshold has been achieved
    private bool thresholdOne = false;
    private bool thresholdTwo = false;
    
    public GameObject[] levels;
    private int current_level = 0;

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
            UpdateModifier();
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
        if (thresholdOne && current_lvl == 0)
        {
            upgradeButton1.SetActive(true);
        }
    }

    // Method to activate button 2
    private void ActivateButton2()
    {
        if (thresholdTwo && current_lvl == 1)
        {
            upgradeButton2.SetActive(true);
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