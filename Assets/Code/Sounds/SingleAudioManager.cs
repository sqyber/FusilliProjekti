using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SingleAudioManager : MonoBehaviour
{
    private static SingleAudioManager instance;

    // Set the gameobject the script is attatched to be an object
    // that isn't destroyed on load and to destroy the
    // duplicates that might be caused by this
    private void Awake()
    {
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
}
