using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckToggle : MonoBehaviour
{
    [SerializeField] private GameObject toggle;
    private int savedValue;

    private void Awake()
    {
        savedValue = PlayerPrefs.GetInt(toggle.GetComponent<SoundToggle>().SavedVariableName, 1);
    }
    
    // Start is called before the first frame update
    private void Start()
    {
        CheckAndSetToggle();
    }

    // Set the toggle based on the value set in the playerprefs
    // ie. if the player has chosen the music to be off
    // the value is 0 and therefore the toggle is off
    // and so is the music
    private void CheckAndSetToggle()
    {
        if (savedValue == 0)
        {
            toggle.GetComponent<Toggle>().isOn = false;
            return;
        }

        toggle.GetComponent<Toggle>().isOn = true;
    }
}
