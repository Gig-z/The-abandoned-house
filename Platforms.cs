using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platforms : MonoBehaviour
{
    //public Transform[] PatrolPoints;
    //public float moveSpeed;
    //public int patrolDestination;

    //void Update()
    //{
    //    {
    //        if (patrolDestination == 0)
    //        {
    //            transform.position = Vector2.MoveTowards(transform.position, PatrolPoints[0].position, moveSpeed * Time.deltaTime);
    //            if (Vector2.Distance(transform.position, PatrolPoints[0].position) < .2f)
    //            {
    //                patrolDestination = 1;
    //            }
    //        }

    //        if (patrolDestination == 1)
    //        {
    //            transform.position = Vector2.MoveTowards(transform.position, PatrolPoints[1].position, moveSpeed * Time.deltaTime);
    //            if (Vector2.Distance(transform.position, PatrolPoints[1].position) < .2f)
    //            {
    //                patrolDestination = 0;
    //            }
    //        }
    //    }

    //}

    public Transform[] waypoints;
    public float speed;
    private Transform targetWaypoint;
    private int currentWaypointIndex = 0;
    public float checkDistance = 0.05f;



    private void Start()
    {
        targetWaypoint = waypoints[0];
    }

    private Transform GetNextWaypoint()
    {
        currentWaypointIndex++;
        if(currentWaypointIndex >= waypoints.Length)
        {
            currentWaypointIndex = 0;
        }

        return waypoints[currentWaypointIndex];
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetWaypoint.position, speed * Time.deltaTime);

        if(Vector2.Distance(transform.position, targetWaypoint.position) < checkDistance)
        {
            targetWaypoint = GetNextWaypoint();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        var Moving = other.collider.GetComponent<Moving>();
        if(Moving != null)
        {
            Moving.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        var Moving = other.collider.GetComponent<Moving>();
        if (Moving != null)
        {
            Moving.ResetParent();
        }
    }
}
