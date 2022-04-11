using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueScoreModifier : MonoBehaviour
{
    private ScoreManager scoreManagerBlue;
    // Start is called before the first frame update
    private void Start()
    {
        scoreManagerBlue = FindObjectOfType<ScoreManager>();
        scoreManagerBlue.BlueScore = PlayerPrefs.GetInt("BlueScore", 0);
    }

    // Method to add BlueScore (used for logistics)
    public void AddScore()
    {
        scoreManagerBlue.BlueScore++;
        Debug.Log("Increased blue score");
    }
    
    // Method to reduce BlueScore (used for logistics)
    public void ReduceScore()
    {
        scoreManagerBlue.BlueScore--;
        Debug.Log("Decreased blue score");
    }
}