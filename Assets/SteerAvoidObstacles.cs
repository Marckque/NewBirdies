using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SteerAvoidObstacles : Steer
{
    [SerializeField, Range(0f, 5f)]
    private float maxVelocity = 1f;
    [SerializeField, Range(-1f, 1f)]
    private float obstacleDotValue = 0f;
    public float dot;
    private Vector3 obstacleDirection;

    protected void Update()
    {
        boid.Acceleration(AvoidObstacle());
    }

    private Vector3 AvoidObstacle()
    {
        foreach (Obstacle obstacle in Manager.Instance.Obstacles)
        {
            obstacleDirection = (transform.position - obstacle.transform.position);
            float distance = obstacleDirection.magnitude;
            float dott = Vector3.Dot(boid.Velocity.normalized, -obstacleDirection.normalized);
            //dot = dott - (1 / Mathf.Pow(distance, 2));
            dot = dott;
            
            if (dot > obstacleDotValue)
            {
                desiredVelocity += obstacleDirection;
                Debug.DrawRay(transform.position, desiredVelocity, Color.magenta);
                return desiredVelocity;
                //desiredVelocity *= (1 / obstacleDirection.magnitude + 1);
            }
            else
            {
                return Vector3.zero;
            }
        }

        //desiredVelocity = Vector3.ClampMagnitude(desiredVelocity, maxVelocity);
        Debug.DrawRay(transform.position, desiredVelocity, Color.cyan);
        return Vector3.zero;
        
    }
}