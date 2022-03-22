using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenScoreModifier : MonoBehaviour
{
    ScoreManager scoreManagerGreen;
    // Start is called before the first frame update
    void Start()
    {
        scoreManagerGreen = FindObjectOfType<ScoreManager>();
        scoreManagerGreen.GreenScore = PlayerPrefs.GetInt("GreenScore", 0);
    }

    // Method to add GreenScore (used for the main score to track unlocks)
    public void AddScore()
    {
        scoreManagerGreen.GreenScore++;
    }
}