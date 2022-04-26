using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ChickenAnimationRandomisation : MonoBehaviour
{
    private Animator animator;

    private float random;
    
    // Start is called before the first frame update
    private void Awake()
    {
        random = Random.Range(0f, 8f);
        animator = GetComponent<Animator>();
        animator.enabled = false;
    }

    private void OnEnable()
    {
        StartCoroutine(StartAnimationWithDelay());
    }

    private IEnumerator StartAnimationWithDelay()
    {
        yield return new WaitForSeconds(random);

        animator.enabled = true;
    }
}