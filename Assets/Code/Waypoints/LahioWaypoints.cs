using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;



public enum Status
{
    Arriving,
    Arrived,
    Delivered,
    Leaving,
    None
}
public class LahioWaypoints : Waypoints
{
    System.Random rnd = new System.Random();
    
    public override Transform GetNextWaypoint(Transform currentWaypoint, ref Status statuscheck)
    {
        
        if (currentWaypoint == null)
        {
            //Move to first waypoint
            statuscheck = Status.Arriving;
            return transform.GetChild(0);
        }

        if (currentWaypoint.GetSiblingIndex() == 0 && statuscheck != Status.Delivered )
        {
            statuscheck = Status.Arrived;
            //pick random house
        }
        
        if (currentWaypoint.GetSiblingIndex() !=0 )
        {
            statuscheck = Status.Delivered;
        }
        else if (statuscheck == Status.Delivered )
        {
            
            //change bool to mark delivery done and prepare for next waypoint system
            statuscheck = Status.Leaving;
        }
        
        // gives number between 1 and child count
        int housenumber = rnd.Next(1, transform.childCount);
        // marks for lahetti to move to next rail
        
        /* Järjestys
        * Saapuu 0 pisteeseen
        *  siirtyy random houseen
        *  takaisin 0 pisteeseen
        *  0 pisteestä seuraavalle raiteelle
        */

        switch (statuscheck)
        {
            case Status.Arriving:
                // go to first waypoint
                return transform.GetChild(0);
            
            case Status.Arrived:
                //set delivery to true to enable button
                IsDelivered = true;
                // go to random house
                return transform.GetChild(housenumber);
            
            case Status.Delivered:
                
                //return to first waypoint
                return transform.GetChild(0);
       
            case Status.Leaving:
                //move back to road waypoints
                
                GetNextSystem();
                break;
        }
        return null;
    }
}

