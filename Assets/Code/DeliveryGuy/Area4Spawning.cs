using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Area4Spawning : MonoBehaviour
{
    // define the delivery guy objects
    [SerializeField] private GameObject delivererRoute1;
    [SerializeField] private GameObject delivererRoute2;
    [SerializeField] private GameObject delivererRoute3;

    // define areas upgradeable building
    [SerializeField] private GameObject building;

    // used to store the current level of the areas upgradeable building
    private int buildingsLvl;

    // A GameObject that is used to clone the original deliverer
    private GameObject spawnedDeliverer;

    // Initializing a list for deliverers
    private List<GameObject> deliverers = new List<GameObject>();
    
    private ScoreManager scoreManagerBlue;
    
    public int Bluescore4
    {
        get { return scoreManagerBlue.BlueScore4; }
    }

    private void Awake()
    {
        scoreManagerBlue = FindObjectOfType<ScoreManager>();
    }

    private void Start()
    {
        GetCurrentLevel();
        SetScoreAndLogistics();
    }

    // spawn deliverers
    public void Spawn()
    {
        if (scoreManagerBlue.BlueScore4 > 0)
        {
            // set and spawn spawnedDeliverer as a clone of deliverer
            // also track deliverers by amount to define which deliverer is used
            // (used to have more routes)
            if (deliverers.Count <= 1)
            {
                spawnedDeliverer = Instantiate(delivererRoute1, transform.position, Quaternion.identity);
            }
            else if (deliverers.Count <= 3)
            {
                spawnedDeliverer = Instantiate(delivererRoute2, transform.position, Quaternion.identity);
            }
            else if (deliverers.Count <= 5)
            {
                spawnedDeliverer = Instantiate(delivererRoute3, transform.position, Quaternion.identity);
            }
        
            // add the spawnedDeliverer to the list initialized earlier
            deliverers.Add(spawnedDeliverer);
        
            // set the deliverer active
            deliverers[deliverers.Count - 1].SetActive(true);
        
            // add logistics score by one to track deliverers on the UI
            scoreManagerBlue.BlueScore4--;
        }
    }

    // Check the areas upgradeable buildings current level
    private void GetCurrentLevel()
    {
        buildingsLvl = building.GetComponent<saveLevel>().lvlOfBuilding;
    }

    // Set the logisticscap and max. deliverer amount according to the buildings level
    private void SetScoreAndLogistics()
    {
        switch (buildingsLvl)
        {
            case 2:
                scoreManagerBlue.BlueScore4 = 6;
                return;
            case 1:
                scoreManagerBlue.BlueScore4 = 4;
                return;
            case 0:
                scoreManagerBlue.BlueScore4 = 2;
                return;
        }
    }
    
    // Function to add deliverers and logistics cap along with upgrade levels
    public void AddDeliverersArea4()
    {
        scoreManagerBlue.BlueScore4 += 2;
    }
}