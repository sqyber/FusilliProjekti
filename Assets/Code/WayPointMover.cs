using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WayPointMover : MonoBehaviour
{
    
    // reference to the waypoint system
    [SerializeField] private Waypoints waypoints;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Button delivered;
    private Transform currentWaypoint;
    private bool IsMoving = true;
    
    
    void Start()
    {
        //set initial position to the first waypoint
        currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
        transform.position = currentWaypoint.position;
        
        //set the next waypoint target
        currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
        
        delivered.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsMoving)
        {
            return;
        }
        
        transform.position =
            Vector2.MoveTowards(transform.position, currentWaypoint.position, moveSpeed * Time.deltaTime);
        if (Vector2.Distance(transform.position, currentWaypoint.position) < 0.1)
        {
            
            if (waypoints.IsDelivered == true)
            {
                IsMoving = false;
                delivered.gameObject.SetActive(true);
            }
            currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
            
            if (currentWaypoint == null)
            {
                waypoints = waypoints.GetNextSystem();
                currentWaypoint = waypoints.GetNextWaypoint(null);
              
                
                }
        }
        
    }

    public void OnDelivered()
    {
        delivered.gameObject.SetActive(false);

        IsMoving = true;
        waypoints.ResetDelivered();
    }
}
