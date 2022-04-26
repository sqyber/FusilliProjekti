using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GreenScoreModifier : MonoBehaviour
{
    // The amount of green score you get when ending deliveries
    [SerializeField] private float score = 10;
    
    // Upgradeable buildings that affect the score by giving a modifier
    [SerializeField] private GameObject henhouse;
    [SerializeField] private GameObject garden;
    [SerializeField] private GameObject farm;
    [SerializeField] private GameObject greenhouse;
    [SerializeField] private GameObject roofgarden;

    private float henhouseMultiplier;
    private float gardenMultiplier;
    private float farmMultiplier;
    private float greenhouseMultiplier;
    private float roofgardenMultiplier;

    private float multipliedScore;
    private float multiplier;
    
    private ScoreManager scoreManagerGreen;

    public int Greenscore
    {
        get { return scoreManagerGreen.GreenScore; }
    }
    
    private void Awake()
    {
        scoreManagerGreen = FindObjectOfType<ScoreManager>();
        scoreManagerGreen.GreenScore = PlayerPrefs.GetInt("GreenScore", 0);
    }

    private void Update()
    {
        UpdateMultipliers();
    }

    // Method to add GreenScore (used to track green upgrades ie. ground etc.)
    public void AddScore()
    {
        multipliedScore = score * multiplier;
        scoreManagerGreen.GreenScore += (int)multipliedScore;
    }

    // Update all multipliers with their corresponding value from the upgradeable building
    // and then add them all together.
    private void UpdateMultipliers()
    {
        henhouseMultiplier = henhouse.GetComponent<UpgradeSystem>().scoreMod;
        gardenMultiplier = garden.GetComponent<UpgradeSystem>().scoreMod;
        farmMultiplier = farm.GetComponent<UpgradeSystem>().scoreMod;
        greenhouseMultiplier = greenhouse.GetComponent<UpgradeSystem>().scoreMod;
        roofgardenMultiplier = roofgarden.GetComponent<UpgradeSystem>().scoreMod;

        multiplier = henhouseMultiplier * gardenMultiplier * farmMultiplier * greenhouseMultiplier *
                     roofgardenMultiplier;
    }
}