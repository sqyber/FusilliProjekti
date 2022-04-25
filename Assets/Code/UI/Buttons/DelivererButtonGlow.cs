using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelivererButtonGlow : MonoBehaviour
{
    [SerializeField] private GameObject area1Spawner;
    
    [SerializeField] private GameObject area2Spawner;
    [SerializeField] private GameObject area2Bscore;
    
    [SerializeField] private GameObject area3Spawner;
    [SerializeField] private GameObject area3Bscore;
    
    [SerializeField] private GameObject area4Spawner;
    [SerializeField] private GameObject area4Bscore;
    
    [SerializeField] private GameObject area5Spawner;
    [SerializeField] private GameObject area5Bscore;

    [SerializeField] private GameObject deliveryButtonGlow;

    private void Update()
    {
        CheckForUnusedDeliverers();
    }

    // Function which checks if the logisticsscore is over 0 and if the areas logisticsscore
    // is active, if both are true, then display the glow for deliveryguy button
    private void CheckForUnusedDeliverers()
    {
        if (area1Spawner.GetComponent<Area1Spawning>().Bluescore1 > 0)
        {
            deliveryButtonGlow.SetActive(true);
            return;
        }
        
        if (area2Spawner.GetComponent<Area2Spawning>().Bluescore2 > 0
            && area2Bscore.activeSelf)
        {
            deliveryButtonGlow.SetActive(true);
            return;
        }
        
        if (area3Spawner.GetComponent<Area3Spawning>().Bluescore3 > 0
            && area3Bscore.activeSelf)
        {
            deliveryButtonGlow.SetActive(true);
            return;
        }
        
        if (area4Spawner.GetComponent<Area4Spawning>().Bluescore4 > 0
            && area4Bscore.activeSelf)
        {
            deliveryButtonGlow.SetActive(true);
            return;
        }
        
        if (area5Spawner.GetComponent<Area5Spawning>().Bluescore5 > 0
            && area5Bscore.activeSelf)
        {
            deliveryButtonGlow.SetActive(true);
            return;
        }
        
        deliveryButtonGlow.SetActive(false);
    }
}
