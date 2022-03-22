using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadWaypoint : Waypoints
{


    // 
    public override Transform GetNextWaypoint(Transform currentWaypoint, Status statuscheck)
    {
 
        if (currentWaypoint == null)
        {
            //First waypoint
            return transform.GetChild(0);
        }
        
        if (currentWaypoint.GetSiblingIndex() < transform.childCount - 1)
        {
            //Moves to next child in waypoint tree
            return transform.GetChild(currentWaypoint.GetSiblingIndex() + 1);
        }
        if (currentWaypoint.GetSiblingIndex() == transform.childCount -1)
        {
            //Changes the waypoint rail
            GetNextSystem();
        }
        
        
        //move to the next waypoint system
        return null;
         
    }
}
