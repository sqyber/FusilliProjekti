using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfGame : MonoBehaviour
{
    // Gameobjects that are used to track score, building level
    // and then the screen for the "ending"
    [SerializeField] private GameObject gscoreText;
    [SerializeField] private GameObject rooftopgarden;
    [SerializeField] private GameObject endscreen;
    
    // Greenscore amount set for the "end of the game"
    [SerializeField] private int endOfGameThreshold = 15000;

    // Bools used to track if specified values are what are required for
    // the ending
    private bool pastThreshold;
    private bool rtgardenLvl2;
    
    // Bool to track if the ending screen has been shown
    // (used to show the screen only once)
    private bool endOfGameScreenShown;

    private void Start()
    {
        if (PlayerPrefs.GetInt("EndShown", 0) == 1)
        {
            endOfGameScreenShown = true;
        }
    }
    
    // Update is called once per frame
    private void Update()
    {
        CheckForEndOfGame();
        OpenEndOfGameScreen();
    }

    // Function to constantly check if the thresholds are met
    private void CheckForEndOfGame()
    {
        if (gscoreText.GetComponent<GreenScoreModifier>().Greenscore >= endOfGameThreshold)
        {
            pastThreshold = true;
        }

        if (rooftopgarden.GetComponent<UpgradeSystem>().current_lvl == 2)
        {
            rtgardenLvl2 = true;
        }
    }

    // Function to open ending screen if thresholds are met and
    // the screen hasn't already been shown
    private void OpenEndOfGameScreen()
    {
        if (endOfGameScreenShown || !rtgardenLvl2 || !pastThreshold) return;
        
        endscreen.SetActive(true);
        endOfGameScreenShown = true;
        PlayerPrefs.SetInt("EndShown", 1);
    }
}
