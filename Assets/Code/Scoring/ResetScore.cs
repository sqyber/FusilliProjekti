using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetScore : MonoBehaviour
{
    // Used to reset the PlayerPrefs
    void Awake()
    {
        PlayerPrefs.SetInt("GreenScore", 0);
        PlayerPrefs.SetInt("YellowScore", 0);
        PlayerPrefs.SetInt("Garden", 0);
        PlayerPrefs.SetInt("Greenhouse", 0);
        PlayerPrefs.SetInt("Henhouse", 0);
        PlayerPrefs.SetInt("Farm", 0);
        PlayerPrefs.SetInt("Roofgarden", 0);
    }
}
