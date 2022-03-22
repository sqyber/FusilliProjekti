using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueScoreReduceModifier : MonoBehaviour
{
    ScoreManager scoreManagerBlueReduce;
    // Start is called before the first frame update
    void Start()
    {
        scoreManagerBlueReduce = FindObjectOfType<ScoreManager>();
        scoreManagerBlueReduce.BlueScore = PlayerPrefs.GetInt("BlueScore", 0);
    }

    // Method to reduce BlueScore (used for logistics)
    public void ReduceScore()
    {
        scoreManagerBlueReduce.BlueScore--;
    }
}
