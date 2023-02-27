using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointMovement : MonoBehaviour
{

    public GameObject[] waypoints;
    int current = 0;
    public float speed = 1f;
    public bool rotate = true;


    void Update()
    {
        if (Vector3.Distance(transform.position, waypoints[current].transform.position) < 0.1f)
        {
            current++;
            if (current >= waypoints.Length)
            {
                current = 0;
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, waypoints[current].transform.position, speed*Time.deltaTime);

        if (rotate)
        {
            transform.LookAt(waypoints[current].transform.position);
        }

        
    }
}
