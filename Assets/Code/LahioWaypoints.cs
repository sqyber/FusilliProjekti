using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class LahioWaypoints : Waypoints
{
    
    System.Random rnd = new System.Random();
    bool delivered;
    
    public override Transform GetNextWaypoint(Transform currentWaypoint)
    {
        // gives number between 1 and child count
       int housenumber = rnd.Next(1, transform.childCount);
       // marks for lahetti to move to next rail
       


       if (currentWaypoint == null)
       {
           //Move to first waypoint

           return transform.GetChild(0);
       }

       if (currentWaypoint.GetSiblingIndex() == 0 && !delivered)
       {
           
           //pick random house 
           return transform.GetChild(housenumber);

           
       }
       if (currentWaypoint.GetSiblingIndex() != 0)
       {
           //change bool to mark delivery done and prepare for next waypoint system
           delivered = true;
           return transform.GetChild(0);
       }

       if (delivered)
       {
           GetNextSystem();
           delivered = false;
       }
       
       return null;
    }
}

