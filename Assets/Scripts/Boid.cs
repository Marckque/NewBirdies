using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Boid : MonoBehaviour
{
    [SerializeField, Range(0f, 10f)]
    private float maxVelocity;

    private Vector3 acceleration;
    public Vector3 Velocity { get; private set; }

    protected void Update()
    {
        ApplyForce();
    }

    public void Acceleration(Vector3 force)
    {
        acceleration += force;
    }

    public void ApplyForce()
    {
        Velocity = acceleration;
        Velocity = Vector3.ClampMagnitude(Velocity, maxVelocity);

        transform.Translate(Velocity);

        acceleration = Vector3.zero;
    }
}