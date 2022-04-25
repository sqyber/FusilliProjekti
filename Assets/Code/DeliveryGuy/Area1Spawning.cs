using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Area1Spawning : MonoBehaviour
{
    // define the delivery guy objects
    [SerializeField] private GameObject delivererRoute1;
    [SerializeField] private GameObject delivererRoute2;
    [SerializeField] private GameObject delivererRoute3;

    // A GameObject that is used to clone the original deliverer
    private GameObject spawnedDeliverer;

    // Initializing a list for deliverers
    private List<GameObject> deliverers = new List<GameObject>();
    
    private ScoreManager scoreManagerBlue;

    public int Bluescore1
    {
        get { return scoreManagerBlue.BlueScore1; }
    }

    private void Awake()
    {
        scoreManagerBlue = FindObjectOfType<ScoreManager>();
        SetBaseValues();
    }

    private void Update()
    {
        CheckArraySize();
    }

    // spawn deliverers
    public void Spawn()
    {
        if (scoreManagerBlue.BlueScore1 <= 0) return;
        // set and spawn spawnedDeliverer as a clone of deliverer
        // also track deliverers by amount to define which deliverer is used
        // (used to have more routes)
        if (deliverers.Count <= 1)
        {
            spawnedDeliverer = Instantiate(delivererRoute1, transform.position, Quaternion.identity);
            DelivererToArray();
            return;
        }
        
        if (deliverers.Count <= 3)
        {
            spawnedDeliverer = Instantiate(delivererRoute2, transform.position, Quaternion.identity);
            DelivererToArray();
            return;
        }
        
        spawnedDeliverer = Instantiate(delivererRoute3, transform.position, Quaternion.identity);
        DelivererToArray();
    }
    
    private void DelivererToArray()
    {
        // add the spawnedDeliverer to the list initialized earlier
        deliverers.Add(spawnedDeliverer);
        
        // set the deliverer active
        deliverers[deliverers.Count - 1].SetActive(true);
        
        // add logistics score by one to track deliverers on the UI
        scoreManagerBlue.BlueScore1--;
    }

    // The base value for the first area
    private void SetBaseValues()
    {
        scoreManagerBlue.BlueScore1 = 6;
    }

    // Fix for a UI bug
    // Checks if the array is full, and if it is it keeps the free deliverer count
    // at 0
    private void CheckArraySize()
    {
        if (deliverers.Count == 6)
        {
            scoreManagerBlue.BlueScore1 = 0;
        }
    }
}