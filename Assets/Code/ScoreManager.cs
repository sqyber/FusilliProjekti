using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreDisplay;
    private int score = 0;

    public int Score
    {
        get { return score; }
        set
        {
            score = value;
            scoreDisplay.text = score.ToString();
            //PlayerPrefs.SetInt("Score", score);
        }
    }
}
