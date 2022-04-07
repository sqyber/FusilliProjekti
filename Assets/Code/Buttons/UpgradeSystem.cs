using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class UpgradeSystem : MonoBehaviour
{
    [SerializeField] private GameObject button;
    
    public GameObject[] levels;
    private int current_level = 0;

    private void Start()
    {
        SwitchObject(current_level);
    }

    public void Upgrade()
    {
        if (current_level < levels.Length - 1)
        {
            current_level++;
            SwitchObject(current_level);
            button.SetActive(false);
        }
    }

    private void SwitchObject(int lvl)
        {
            for (int i = 0; i < levels.Length; i++)
            {
                if (i == lvl)
                {
                    levels[i].SetActive(true);
                }
                else
                {
                    levels[i].SetActive(false);
                }
            }
        }

    }