using UnityEngine;

public class WaypointPath : MonoBehaviour
{
    public Transform[] waypoints;

    public Transform GetWaypoint(int index)
    {
        return waypoints[index];
    }

    public int Length => waypoints.Length;
}
