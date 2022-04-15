using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetScore : MonoBehaviour
{
    [SerializeField] private bool toggleScoreReset = false;
    [SerializeField] private bool toggleLevelReset = false;

    public bool tglLvlReset
    {
        get { return toggleLevelReset; }
    }
    
    // Used to reset the PlayerPrefs
    private void Awake()
    {
        if (toggleScoreReset)
        {
            SetScoresToZero();
        }

        if (toggleLevelReset)
        {
            SetUpgradesToZero();
        }
    }

    private static void SetScoresToZero()
    {
        PlayerPrefs.SetInt("GreenScore", 0);
        PlayerPrefs.SetInt("YellowScore", 0);
    }
    
    private static void SetUpgradesToZero()
    {
        PlayerPrefs.SetInt("Garden", 0);
        PlayerPrefs.SetInt("Greenhouse", 0);
        PlayerPrefs.SetInt("Henhouse", 0);
        PlayerPrefs.SetInt("Farm", 0);
        PlayerPrefs.SetInt("Roofgarden", 0);
    }
}
