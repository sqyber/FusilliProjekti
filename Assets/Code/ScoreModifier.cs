using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreModifier : MonoBehaviour
{
    ScoreManager scoreManager;
    // Start is called before the first frame update
    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        //scoreManager.Score = PlayerPrefs.GetInt("Score", 0);
    }

    public void AddScore()
    {
        scoreManager.Score++;
    }
}
