using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // This is used to store the information of the initial tap
    Vector3 hit_position = Vector3.zero;
    
    // This is used to store the information of the current camera position
    Vector3 current_position = Vector3.zero;
    
    // This is used to calculate the new camera position
    Vector3 camera_position = Vector3.zero;

    void Update(){
        // Detection for the initial tap and storing the information
        if(Input.GetMouseButtonDown(0)){
            hit_position = Input.mousePosition;
            camera_position = transform.position;

        }
        
        // Detection for holding finger on the screen, if held go on to drag method
        if(Input.GetMouseButton(0)){
            current_position = Input.mousePosition;
            LeftMouseDrag();        
        }
    }

    // Drag method for holding finger down on screen
    void LeftMouseDrag(){
        current_position.z = hit_position.z = camera_position.y;

        // Get direction of movement.
        if (Camera.main != null)
        {
            Vector3 direction = Camera.main.ScreenToWorldPoint(current_position) - Camera.main.ScreenToWorldPoint(hit_position);

            // Invert direction
            direction = direction * -1;

            Vector3 position = camera_position + direction;

            transform.position = position;
        }
    }
}
