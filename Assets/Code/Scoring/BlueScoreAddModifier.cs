using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueScoreAddModifier : MonoBehaviour
{
    ScoreManager scoreManagerBlueAdd;
    // Start is called before the first frame update
    void Start()
    {
        scoreManagerBlueAdd = FindObjectOfType<ScoreManager>();
        scoreManagerBlueAdd.BlueScore = PlayerPrefs.GetInt("BlueScore", 0);
    }

    // Method to add BlueScore (used for logistics)
    public void AddScore()
    {
        scoreManagerBlueAdd.BlueScore++;
    }
}