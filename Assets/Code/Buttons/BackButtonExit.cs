using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButtonExit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Makes the press of back button close the app
        Input.backButtonLeavesApp = true;
    }
}
