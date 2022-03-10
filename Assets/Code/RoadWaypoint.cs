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
            Debug.Log("nollaanpääyti");
            return transform.GetChild(0);
        }
        
        if (currentWaypoint.GetSiblingIndex() < transform.childCount - 1)
        {
            Debug.Log("sibling ylös");
            return transform.GetChild(currentWaypoint.GetSiblingIndex() + 1);
        }
        else if (currentWaypoint.GetSiblingIndex() == transform.childCount -1)
        {
            Debug.Log("_Next");
            GetNextSystem();
        }
        
        {
            //move to the next waypoint system
            Debug.Log("nulliin päätyi");
            return null;
        } 
    }
}
