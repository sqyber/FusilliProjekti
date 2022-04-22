using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SingleAudioManager : MonoBehaviour
{
    private static SingleAudioManager instance;

    [SerializeField] private GameObject music;
    [SerializeField] private GameObject toggle;

    private int musicValue;

    private void Awake()
    {
        musicValue = PlayerPrefs.GetInt("Music", 1);
        
        CheckToggle();
        
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void OnToggle()
    {
        if (!toggle.GetComponent<Toggle>().isOn)
        {
            PlayerPrefs.SetInt("Music", 0);
            music.SetActive(false);
            return;
        }
        
        PlayerPrefs.SetInt("Music", 1);
        music.SetActive(true);
    }

    private void CheckToggle()
    {
        if (musicValue == 0)
        {
            toggle.GetComponent<Toggle>().isOn = false;
            return;
        }

        toggle.GetComponent<Toggle>().isOn = true;
    }
}
