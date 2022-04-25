using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TransitionLoader : MonoBehaviour
{
    public Animator transition;

    [SerializeField] private float transitionTime = 1f;
    [SerializeField] private int nextSceneIndex;
    
    // Public function used in buttons
    public void LoadNextScene()
    {
        StartCoroutine(TransitionNextScene(nextSceneIndex));
    }

    // Coroutine to have a wait time before loading the next scene
    private IEnumerator TransitionNextScene(int index)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(index);
    }
}