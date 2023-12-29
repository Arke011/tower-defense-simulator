using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 5f;

    private Transform target;
    private int wavepointCount = 0;

    void Start()
    {
        target = Waypoints.points[0];

    }

    void Update()
    {
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();

        }

        void GetNextWaypoint()
        {
            if (wavepointCount >= Waypoints.points.Length - 1)
            {
                Destroy(gameObject);
                return;
            }

            wavepointCount++;
            target = Waypoints.points[wavepointCount];
        }
    }
}
