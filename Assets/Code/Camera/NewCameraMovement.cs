using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCameraMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 5;
    private Vector3 firstTouch;
    private Vector3 newPosition;
    private Vector3 cameraPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            firstTouch = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            cameraPosition = Camera.main.transform.position;
        }

        if (Input.GetMouseButton(0))
        {
            MoveCamera();
        }
    }

    private void MoveCamera()
    {
        newPosition = Camera.main.ScreenToWorldPoint((Input.mousePosition));

        Vector3 direction = firstTouch - newPosition;
        Vector3 position = cameraPosition + direction;
        
        transform.position = new Vector3(
            Mathf.Clamp(Mathf.Lerp(cameraPosition.x, position.x, movementSpeed), -33.65f, -1.82f),
            Mathf.Clamp(Mathf.Lerp(cameraPosition.y, position.y, movementSpeed), -29.2f, -8.6f),
            -13.74f);
    }
}
