using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public Transform[] PatrolPoints;
    public float moveSpeed;
    public int patrolDestination;

    void Update()
    {
        {
            if (patrolDestination == 0)
            {
                transform.position = Vector2.MoveTowards(transform.position, PatrolPoints[0].position, moveSpeed * Time.deltaTime);
                if (Vector2.Distance(transform.position, PatrolPoints[0].position) < .2f)
                {
                    transform.localScale = new Vector3(1, 1, 1);
                    patrolDestination = 1;
                }
            }

            if (patrolDestination == 1)
            {
                transform.position = Vector2.MoveTowards(transform.position, PatrolPoints[1].position, moveSpeed * Time.deltaTime);
                if (Vector2.Distance(transform.position, PatrolPoints[1].position) < .2f)
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                    patrolDestination = 0;
                }
            }
        }
 
    }
}
