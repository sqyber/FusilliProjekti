using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckToggle : MonoBehaviour
{
    [SerializeField] private GameObject toggle;
    private int musicValue;

    private void Awake()
    {
        musicValue = PlayerPrefs.GetInt("Music");
    }
    
    // Start is called before the first frame update
    private void Start()
    {
        CheckAndSetToggle();
    }

    private void CheckAndSetToggle()
    {
        if (musicValue == 0)
        {
            toggle.GetComponent<Toggle>().isOn = false;
            return;
        }

        toggle.GetComponent<Toggle>().isOn = true;
    }
}
