using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenUnlocks : MonoBehaviour
{
    // Thresholds for unlocking shrubbery etc. foliage
    [SerializeField] private int thresholdOne = 100;
    [SerializeField] private int thresholdTwo = 200;
    [SerializeField] private int thresholdThree = 300;
    [SerializeField] private int thresholdFour = 400;
    [SerializeField] private int thresholdFive = 500;

    // The foliage gameobjects to unlock
    [SerializeField] private GameObject foliageOne;
    [SerializeField] private GameObject foliageTwo;
    [SerializeField] private GameObject foliageThree;
    [SerializeField] private GameObject foliageFour;
    [SerializeField] private GameObject foliageFive;

    // Object with the greenscoremodifier script
    [SerializeField] private GameObject greenscoreSource;

    // Int value used to simplify code in the script
    private int greenscoreAmount;

    private void Start()
    {
        greenscoreAmount = greenscoreSource.GetComponent<GreenScoreModifier>().Greenscore;
        CheckUnlocks();
    }

    // Update is called once per frame
    private void Update()
    {
        greenscoreAmount = greenscoreSource.GetComponent<GreenScoreModifier>().Greenscore;
        CheckUnlocks();
    }

    // Function to check if greenscore is above threshold, if yes
    // show the corresponding foliage
    private void CheckUnlocks()
    {
        if (greenscoreAmount >= thresholdOne)
        {
            foliageOne.SetActive(true);
        }

        if (greenscoreAmount >= thresholdTwo)
        {
            foliageTwo.SetActive(true);
        }

        if (greenscoreAmount >= thresholdThree)
        {
            foliageThree.SetActive(true);
        }

        if (greenscoreAmount >= thresholdFour)
        {
            foliageFour.SetActive(true);
        }

        if (greenscoreAmount >= thresholdFive)
        {
            foliageFive.SetActive(true);
        }
    }
}
