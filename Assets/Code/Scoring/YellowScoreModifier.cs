using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowScoreModifier : MonoBehaviour
{
    ScoreManager scoreManagerYellow;
    // Start is called before the first frame update
    void Start()
    {
        scoreManagerYellow = FindObjectOfType<ScoreManager>();
        scoreManagerYellow.YellowScore = PlayerPrefs.GetInt("YellowScore", 0);
    }

    // Used to add YellowScore (used as the secondary main score)
    public void AddScore()
    {
        scoreManagerYellow.YellowScore++;
    }
}