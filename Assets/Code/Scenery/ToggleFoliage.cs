using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleFoliage : MonoBehaviour
{
    [SerializeField] private GameObject building;
    [SerializeField] private GameObject foliageLvl1;
    [SerializeField] private GameObject foliageLvl2;
    [SerializeField] private GameObject foliageLvl3;

    private void Update()
    {
        ChangeFoliage();
    }    
    
    // Function to change foliage based on the buildings level
    private void ChangeFoliage()
    {
        if (building.GetComponent<UpgradeSystem>().current_lvl == 0)
        {
            foliageLvl1.SetActive(true);
            return;
        }

        if (building.GetComponent<UpgradeSystem>().current_lvl == 1)
        {
            foliageLvl1.SetActive(false);
            foliageLvl2.SetActive(true);
            return;
        }

        if (building.GetComponent<UpgradeSystem>().current_lvl != 2) return;
        
        foliageLvl2.SetActive(false);
        foliageLvl3.SetActive(true);
    }
}
