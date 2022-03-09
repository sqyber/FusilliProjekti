using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointMover : MonoBehaviour
{
    
    // reference to the waypoint system
    [SerializeField] private Waypoints waypoints;
    [SerializeField] private float moveSpeed = 5f;

    private Transform currentWaypoint;
    
    
    void Start()
    {
        //set initial position to the first waypoint
        currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
        transform.position = currentWaypoint.position;
        
        //set the next waypoint target
        currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position =
            Vector2.MoveTowards(transform.position, currentWaypoint.position, moveSpeed * Time.deltaTime);
        if (Vector2.Distance(transform.position, currentWaypoint.position) < 0.1)
        {
            currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
            if (currentWaypoint == null)
            {
                waypoints = waypoints.GetNextSystem();
                currentWaypoint = waypoints.GetNextWaypoint(null);
            }
        }
    }
}
