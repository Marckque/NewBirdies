using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SteerGoToTarget : Steer
{
    [Header("Target"), SerializeField]
    private Transform target;

    [Header("Steering"), SerializeField, Range(0f, 10f)]
    private float maxVelocity = 1f;

    protected void Update()
    {
        boid.Acceleration(GoToTarget());
    }

    private Vector3 GoToTarget()
    {
        desiredVelocity = (target.transform.position - transform.position);
        desiredVelocity = Vector3.ClampMagnitude(desiredVelocity, maxVelocity);
        Debug.DrawRay(transform.position, desiredVelocity, Color.red);

        return desiredVelocity;
    }
}