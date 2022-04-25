using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraMovement : MonoBehaviour
{
    // These are used to prevent camera movement while a menu is open.
    [SerializeField] private GameObject helpMenu;

    [SerializeField] private float zoomOutMin = 5;
    [SerializeField] private float zoomOutMax = 9;
    
    // This is used to store the information of the initial tap
    private Vector2 initialTouch = Vector2.zero;
    
    // This is used to store the current finger position
    private Vector2 fingerPosition = Vector2.zero;
    
    // This is used to store the cameras position
    private Vector2 cameraPosition = Vector2.zero;

    private bool twoFingers;

    private Touch touchZero;
    private Touch touchOne;

    private void LateUpdate()
    {
        // Check if either of the menus is active, if yes then return
        if (helpMenu.activeSelf)
        {
            return;
        }
        
        // Detection for the initial tap and storing the information
        if(Input.GetMouseButtonDown(0))
        {
            initialTouch = Input.mousePosition;
            cameraPosition = transform.position;
            twoFingers = false;
        }

        if (Input.touchCount == 2)
        {
            twoFingers = true;
            
            touchZero = Input.GetTouch(0);
            touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

            float difference = currentMagnitude - prevMagnitude;

            Zoom(difference * 0.01f);
        }
        
        // Detection for holding finger on the screen, if held go on to drag method
        else if(Input.GetMouseButton(0) && twoFingers == false)
        {
            fingerPosition = Input.mousePosition;
            MoveCamera();
            Zoom(Input.GetAxis("Mouse ScrollWheel"));
        }
    }

    // Drag method for holding finger down on screen
    private void MoveCamera()
    {
        // Get direction of movement.
        if (Camera.main != null)
        {
            Vector2 direction = Camera.main.ScreenToWorldPoint(fingerPosition) - Camera.main.ScreenToWorldPoint(initialTouch);

            // Invert direction
            direction = direction * -1;

            Vector2 position = cameraPosition + direction;

            // Using Clamp to limit cameras movement to the gamearea boundaries
            transform.position = new Vector3(
                Mathf.Clamp(position.x, -33.65f, -1.82f),
                Mathf.Clamp(position.y, -29.2f, -8.6f),
                -13.74f);
        }
    }

    // Simple zoom function for the camera
    private void Zoom(float increment)
    {
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - increment, zoomOutMin, zoomOutMax);
    }
}
