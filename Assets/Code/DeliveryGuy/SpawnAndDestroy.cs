using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAndDestroy : MonoBehaviour
{
    // define the delivery guy object
    [SerializeField] private GameObject deliverer;

    private GameObject spawnedDeliverer;
    private GameObject spawnedDeliverer2;
    private GameObject spawnedDeliverer3;
    
    // spawn deliverers
    public void Spawn()
    {
        // check if there is a 2nd deliverer already, if yes then spawn third with identifier for 
        // being the third one
        if (spawnedDeliverer2 != null)
        {
            spawnedDeliverer3 = Instantiate(deliverer, transform.position, Quaternion.identity);
            spawnedDeliverer3.SetActive(true);
            return;
        }
        
        // check if there is a deliverer already, if yes then spawn second with identifier for 
        // being the second one
        if (spawnedDeliverer != null)
        {
            spawnedDeliverer2 = Instantiate(deliverer, transform.position, Quaternion.identity);
            spawnedDeliverer2.SetActive(true);
            return;
        }
        
        // check if there is a deliverer, if not then spawn one with identifier for being
        // the first one
        if (spawnedDeliverer == null)
        {
            spawnedDeliverer = Instantiate(deliverer, transform.position, Quaternion.identity);
            spawnedDeliverer.SetActive(true);
        }
    }
    
    // despawn the last deliverer that was spawned
    public void DespawnLast()
    {
        // check if a third deliverer exists, then delete it and return
        if (spawnedDeliverer3 != null)
        {
            Destroy(spawnedDeliverer3.gameObject);
            return;
        }
        
        // check if a second deliverer exists, then delete it and return
        if (spawnedDeliverer2 != null)
        {
            Destroy(spawnedDeliverer2.gameObject);
            return;
        }
        
        // check if a deliverer exists, then delete it
        if (spawnedDeliverer != null)
        {
            Destroy(spawnedDeliverer.gameObject);
        }
    }
}