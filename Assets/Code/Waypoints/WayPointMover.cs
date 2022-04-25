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
    
    [SerializeField] private Animator animator;
    private float deadzone = 0.3f;
    private float xDifference;
    private float yDifference;

    private Transform currentWaypoint;
    private bool IsMoving = true;
    
    public Status lahetti;
    
    private void Start()
    {
        //set initial position to the first waypoint
        currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint, ref lahetti);
        transform.position = currentWaypoint.position;
        
        //set the next waypoint target
        currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint, ref lahetti);
        
        delivered.gameObject.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        if (!IsMoving)
        {
            return;
        }
        CalculateDirection();
        MoveCharacter();
    }

    public void OnDelivered()
    {
        delivered.gameObject.SetActive(false);

        IsMoving = true;
        waypoints.ResetDelivered();
    }

    // Function used to move the character
    private void MoveCharacter()
    {
        transform.position =
            Vector2.MoveTowards(transform.position, currentWaypoint.position, moveSpeed * Time.deltaTime);
        if (Vector2.Distance(transform.position, currentWaypoint.position) < 0.1)
        {
            if (lahetti == Status.Arrived)
            {
                IsMoving = false;
                delivered.gameObject.SetActive(true);
                SetAnimatorBools();
            }
            
            currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint, ref lahetti);
            
            if (currentWaypoint != null)
            {
                return;
            }
            
            waypoints = waypoints.GetNextSystem();
            currentWaypoint = waypoints.GetNextWaypoint(null, ref lahetti);
        }
    }

    // Function used to calculate the direction differences from currentposition to next position and then applying the
    // correct animation based on that
    private void CalculateDirection()
    {
        Vector2 currentPos = transform.position;
        Vector2 currentWaypointPos = currentWaypoint.position;
        
        xDifference = Mathf.Abs(currentPos.x - currentWaypointPos.x);
        yDifference = Mathf.Abs(currentPos.y - currentWaypointPos.y);
        
        if (currentPos.x  < currentWaypointPos.x && yDifference < deadzone)
        {
            SetAnimatorBools();
            animator.SetBool("goingEast", true);
            return;
        }

        if (currentPos.x  > currentWaypointPos.x && yDifference < deadzone)
        {
            SetAnimatorBools();
            animator.SetBool("goingWest", true);
            return;
        }

        if (currentPos.y < currentWaypointPos.y && xDifference < deadzone)
        {
            SetAnimatorBools();
            animator.SetBool("goingNorth", true);
            return;
        }

        if (currentPos.y > currentWaypointPos.y && xDifference < deadzone)
        {
            SetAnimatorBools();
            animator.SetBool("goingSouth", true);
        }
    }

    // function to reset animation bools
    private void SetAnimatorBools()
    {
        animator.SetBool("goingNorth", false);
        animator.SetBool("goingSouth", false);
        animator.SetBool("goingEast", false);
        animator.SetBool("goingWest", false);
    }
}
