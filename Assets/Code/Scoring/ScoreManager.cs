using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    // Use to define the TMP for score display
    [SerializeField] private TextMeshProUGUI greenScoreDisplay;
    [SerializeField] private TextMeshProUGUI yellowScoreDisplay;
    [SerializeField] private TextMeshProUGUI blueScore1Display;
    [SerializeField] private TextMeshProUGUI blueScore2Display;
    [SerializeField] private TextMeshProUGUI blueScore3Display;
    [SerializeField] private TextMeshProUGUI blueScore4Display;
    [SerializeField] private TextMeshProUGUI blueScore5Display;

    private int Gscore = 0;
    private int Bscore1 = 0;
    private int Bscore2 = 0;
    private int Bscore3 = 0;
    private int Bscore4 = 0;
    private int Bscore5 = 0;
    private int Yscore = 0;

    // Setting the private GScore value with the GreenScore value to protect the value
    public int GreenScore
    {
        get { return Gscore; }
        set
        {
            Gscore = value;
            greenScoreDisplay.text = Gscore.ToString();
            PlayerPrefs.SetInt("GreenScore", Gscore);
        }
    }
    
    // Setting the private BScore values with the BlueScore value to protect the value
    public int BlueScore1
        {
            get { return Bscore1; }
            set
            {
                Bscore1 = value;
                blueScore1Display.text = Bscore1.ToString();
            }
        }
    
    public int BlueScore2
    {
        get { return Bscore2; }
        set
        {
            Bscore2 = value;
            blueScore2Display.text = Bscore2.ToString();
        }
    }
    
    public int BlueScore3
    {
        get { return Bscore3; }
        set
        {
            Bscore3 = value;
            blueScore3Display.text = Bscore3.ToString();
        }
    }
    
    public int BlueScore4
    {
        get { return Bscore4; }
        set
        {
            Bscore4 = value;
            blueScore4Display.text = Bscore4.ToString();
        }
    }
    
    public int BlueScore5
    {
        get { return Bscore5; }
        set
        {
            Bscore5 = value;
            blueScore5Display.text = Bscore5.ToString();
        }
    }
        
    // Setting the private YScore value with the YellowScore value to protect the value
    public int YellowScore
        {
            get { return Yscore; }
            set
            {
                Yscore = value;
                yellowScoreDisplay.text = Yscore.ToString();
                PlayerPrefs.SetInt("YellowScore", Yscore);
            }
        }
}