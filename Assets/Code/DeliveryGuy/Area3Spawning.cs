using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area3Spawning : MonoBehaviour
{
    // define the delivery guy object
    [SerializeField] private GameObject deliverer;

    // A GameObject that is used to clone the original deliverer
    private GameObject spawnedDeliverer;

    // Initializing a list for deliverers
    private List<GameObject> deliverers = new List<GameObject>();
    
    private ScoreManager scoreManagerBlue;

    private int logisticsCap = 6;
    
    private void Awake()
    {
        scoreManagerBlue = FindObjectOfType<ScoreManager>();
        scoreManagerBlue.BlueScore3 = logisticsCap;
    }

    // spawn deliverers
    public void Spawn()
    {
        if (scoreManagerBlue.BlueScore3 > 0)
        {
            // set and spawn spawnedDeliverer as a clone of deliverer
            spawnedDeliverer = Instantiate(deliverer, transform.position, Quaternion.identity);
        
            // add the spawnedDeliverer to the list initialized earlier
            deliverers.Add(spawnedDeliverer);
        
            // set the deliverer active
            deliverers[deliverers.Count - 1].SetActive(true);
        
            // add logistics score by one to track deliverers on the UI
            scoreManagerBlue.BlueScore3--;
        }
    }
    
    // despawn the last deliverer that was spawned
    public void DespawnLast()
    {
        // Check if lists index value is below zero, if yes then return
        // otherwise destroy the last object in the list
        if (deliverers.Count - 1 < 0)
        {
            return;
        }

        if (scoreManagerBlue.BlueScore3 < logisticsCap)
        {
            Destroy(deliverers[deliverers.Count - 1]);
            deliverers.RemoveAt(deliverers.Count - 1);
            spawnedDeliverer = null;
            
            // reduce logistics score to track the amount of deliverers on the UI
            scoreManagerBlue.BlueScore3++;
        }
    }
}
