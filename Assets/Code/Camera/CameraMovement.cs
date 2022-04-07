using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // These are used to prevent camera movement while a menu is open.
    [SerializeField] private GameObject helpMenu;
    [SerializeField] private GameObject spawnMenu;
    
    // This is used to store the information of the initial tap
    Vector2 hit_position = Vector2.zero;
    
    // This is used to store the information of the current camera position
    Vector2 current_position = Vector2.zero;
    
    // This is used to calculate the new camera position
    Vector2 camera_position = Vector2.zero;

    private void Update()
    {
        // Check if either of the menus is active, if yes then return
        if (helpMenu.activeSelf || spawnMenu.activeSelf)
        {
            return;
        }
        
        // Detection for the initial tap and storing the information
        if(Input.GetMouseButtonDown(0))
        {
            hit_position = Input.mousePosition;
            camera_position = transform.position;
        }
        
        // Detection for holding finger on the screen, if held go on to drag method
        if(Input.GetMouseButton(0))
        {
            current_position = Input.mousePosition;
            LeftMouseDrag();
        }
    }

    // Drag method for holding finger down on screen
    private void LeftMouseDrag()
    {
        // Get direction of movement.
        if (Camera.main != null)
        {
            Vector2 direction = Camera.main.ScreenToWorldPoint(current_position) - Camera.main.ScreenToWorldPoint(hit_position);

            // Invert direction
            direction = direction * -1;

            Vector2 position = camera_position + direction;

            // Using Clamp to limit cameras movement to the gamearea boundaries
            transform.position = new Vector3(
                Mathf.Clamp(position.x, -33.65f, -1.82f),
                Mathf.Clamp(position.y, -29.2f, -8.6f),
                -13.74f);
        }
    }
}
