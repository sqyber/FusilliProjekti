using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicToggle : MonoBehaviour
{
    [SerializeField] private GameObject toggle;
    [SerializeField] private GameObject musicPlayer;

    private void Awake()
    {
        musicPlayer = FindInActiveObjectByName("BackgroundMusic");
    }

    public void OnToggle()
    {
        if (!toggle.GetComponent<Toggle>().isOn)
        {
            PlayerPrefs.SetInt("Music", 0);
            musicPlayer.SetActive(false);
            return;
        }
        
        PlayerPrefs.SetInt("Music", 1);
        musicPlayer.SetActive(true);
    }
    
    // Used to find the object that plays the background music, so that
    // toggling it works even if it was inactive when a scene was loaded
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
