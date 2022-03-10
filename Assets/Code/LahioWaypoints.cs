using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class LahioWaypoints : Waypoints
{
    
    System.Random rnd = new System.Random();
    
    public override Transform GetNextWaypoint(Transform currentWaypoint)
    {
        // the cap of houses +1 --> 6 max = 5 houses
       int housenumber = rnd.Next(1, 6);
      
        
        if (currentWaypoint.GetSiblingIndex() == 0)
        {
            return transform.GetChild(housenumber);
        }
        else if(currentWaypoint == null)
        {
            //wait for button

            return transform.GetChild(0);
        }
        else
        {
            return null;
        }
    }
}

