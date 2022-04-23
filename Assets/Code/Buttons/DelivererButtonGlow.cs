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
        if (area1Spawner.GetComponent<Area1Spawning>().scoreManagerBlue.BlueScore1 > 0)
        {
            deliveryButtonGlow.SetActive(true);
            return;
        }
        
        if (area2Bscore.activeSelf && area2Spawner.GetComponent<Area2Spawning>().scoreManagerBlue.BlueScore2 > 0)
        {
            deliveryButtonGlow.SetActive(true);
            return;
        }
        
        if (area3Spawner.GetComponent<Area3Spawning>().scoreManagerBlue.BlueScore3 > 0
            && area3Bscore.activeSelf)
        {
            deliveryButtonGlow.SetActive(true);
            return;
        }
        
        if (area4Spawner.GetComponent<Area4Spawning>().scoreManagerBlue.BlueScore4 > 0
            && area4Bscore.activeSelf)
        {
            deliveryButtonGlow.SetActive(true);
            return;
        }
        
        if (area5Spawner.GetComponent<Area5Spawning>().scoreManagerBlue.BlueScore5 > 0
            && area5Bscore.activeSelf)
        {
            deliveryButtonGlow.SetActive(true);
            return;
        }
        
        deliveryButtonGlow.SetActive(false);
    }
}
