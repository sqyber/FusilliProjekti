using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadWaypoint : Waypoints
{


    // 
    public override Transform GetNextWaypoint(Transform currentWaypoint)
    {

        if (currentWaypoint == null)
        {
            return transform.GetChild(0);
        }
        
        if (currentWaypoint.GetSiblingIndex() < transform.childCount - 1)
        {
            return transform.GetChild(currentWaypoint.GetSiblingIndex() + 1);
        }
        else
        {
            //move to the next waypoint system

            return null;
        } 
    }
}
