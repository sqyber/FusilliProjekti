using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    [SerializeField] private Waypoints nextSystem;
    protected bool delivered;
    public bool IsDelivered
    {
        get { return delivered; }
    }
    
    private void OnDrawGizmos()

    {
        foreach (Transform t in transform)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(t.position, 1f);
        }

        Gizmos.color = Color.red;
        for (int i = 0; i < transform.childCount - 1; i++)
        {
            Gizmos.DrawLine(transform.GetChild(i).position, transform.GetChild(i + 1).position);
        }
        //go to first child
        Gizmos.DrawLine(transform.GetChild(transform.childCount -1).position, transform.GetChild(0).position);
    }
    
    public virtual Transform GetNextWaypoint(Transform currentWaypoint, Status statuscheck)
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
            return transform.GetChild(0);
        }
    }

    public Waypoints GetNextSystem()
    {
        return nextSystem;
    }

    public void ResetDelivered()
    {
        delivered = false;
    }
}
