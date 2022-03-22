using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetScore : MonoBehaviour
{
    // Used to reset the PlayerPrefs
    void Start()
    {
        PlayerPrefs.SetInt("GreenScore", 0);
        PlayerPrefs.SetInt("YellowScore", 0);
        PlayerPrefs.SetInt("BlueScore", 0);
    }
}
