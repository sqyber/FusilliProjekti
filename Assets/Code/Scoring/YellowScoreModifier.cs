using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowScoreModifier : MonoBehaviour
{
    [SerializeField] private GameObject greenhouseButton;
    private bool overHundred = false;
    private bool overTwoHundred = false;
    private bool overThreeHundred = false;
    
    ScoreManager scoreManagerYellow;

    private int score = 3;
    // Start is called before the first frame update
    private void Start()
    {
        scoreManagerYellow = FindObjectOfType<ScoreManager>();
        scoreManagerYellow.YellowScore = PlayerPrefs.GetInt("YellowScore", 0);
    }

    // Used to add YellowScore (used as the secondary main score)
    public void AddScore()
    {
        scoreManagerYellow.YellowScore += score;
        CheckScore();
        if (overHundred || overTwoHundred || overThreeHundred)
        {
            ActivateButton();
        }
    }

    private void CheckScore()
    {
        if (scoreManagerYellow.YellowScore > 100)
        {
            overHundred = true;
        }

        if (scoreManagerYellow.YellowScore > 200)
        {
            overTwoHundred = true;
        }

        if (scoreManagerYellow.YellowScore > 300)
        {
            overThreeHundred = true;
        }
    }

    private void ActivateButton()
    {
        greenhouseButton.SetActive(true);
    }
}