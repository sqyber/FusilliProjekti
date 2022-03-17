using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class LahioWaypoints : Waypoints
{



    // TODO enum lähetin tilasta ja yhdistä switch case rakenteeseen.
    // TODO kolmeen vaiheeseen eri tilat switchiin.
    System.Random rnd = new System.Random();



    public enum Status
    {
        Arrived,
        Delivered,
        Leaving
    }

    private Status lahetti;

    public override Transform GetNextWaypoint(Transform currentWaypoint, Status statuscheck)
    {
        // gives number between 1 and child count
        int housenumber = rnd.Next(1, transform.childCount);
        // marks for lahetti to move to next rail

        switch (statuscheck)
        {
            case Status.Arrived:
                return transform.GetChild(housenumber);
            
            case Status.Delivered:
                return transform.GetChild(0);
            
            case Status.Leaving:
                GetNextSystem();
                break;

            default:
                return null;
        }

        /* Järjestys
         * Saapuu 0 pisteeseen
         *  siirtyy random houseen
         *  takaisin 0 pisteeseen
         *  0 pisteestä seuraavalle raiteelle
         */
        if (currentWaypoint == null)
        {
            //Move to first waypoint
            return transform.GetChild(0);
        }

        if (currentWaypoint.GetSiblingIndex() == 0)
        {
            lahetti = Status.Arrived;
            //pick random house
            //return transform.GetChild(housenumber);

        }
        if (currentWaypoint.GetSiblingIndex() != 0)
        {
            lahetti = Status.Delivered;
            return null;
        }

        if (currentWaypoint.GetSiblingIndex() == 0 && lahetti == Status.Delivered  )
        {
            //change bool to mark delivery done and prepare for next waypoint system
            lahetti = Status.Leaving;
        }
        
        return null;
    }
}

