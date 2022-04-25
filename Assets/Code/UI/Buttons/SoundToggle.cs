using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundToggle : MonoBehaviour
{
    [SerializeField] private GameObject toggle;
    [SerializeField] private GameObject soundPlayer;
    [SerializeField] private String targetObjectName;
    [SerializeField] private String savedVariableName;

    public String SavedVariableName
    {
        get { return savedVariableName; }
    }

    private void Awake()
    {
        soundPlayer = FindInActiveObjectByName(targetObjectName);
    }

    // On toggle check if the toggle isn't on, then set the playerpref value for the
    // sound to 0 and turn off the soundplayer
    // Otherwise set the value to 1 and turn the soundplayer on
    public void OnToggle()
    {
        if (!toggle.GetComponent<Toggle>().isOn)
        {
            PlayerPrefs.SetInt(savedVariableName, 0);
            soundPlayer.SetActive(false);
            return;
        }
        
        PlayerPrefs.SetInt(savedVariableName, 1);
        soundPlayer.SetActive(true);
    }
    
    // Used to find the object that plays the sound, so that
    // toggling it works even if it was inactive when a scene was loaded
    // (Not really used for SFX, but only for music)
    private static GameObject FindInActiveObjectByName(string name)
    {
        Transform[] objects = Resources.FindObjectsOfTypeAll<Transform>() as Transform[];
        foreach (var t in objects)
        {
            if (t.hideFlags == HideFlags.None)
            {
                if (t.name == name)
                {
                    return t.gameObject;
                }
            }
        }
        return null;
    }
}
