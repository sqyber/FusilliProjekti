using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    // Use to define the TMP for score display
    [SerializeField]
    private TextMeshProUGUI greenScoreDisplay;
    [SerializeField]
    private TextMeshProUGUI blueScoreDisplay;
    [SerializeField]
    private TextMeshProUGUI yellowScoreDisplay;
    private int Gscore = 0;
    private int Bscore = 5;
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
    
    // Setting the private BScore value with the BlueScore value to protect the value
    public int BlueScore
        {
            get { return Bscore; }
            set
            {
                Bscore = value;
                blueScoreDisplay.text = Bscore.ToString();
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
