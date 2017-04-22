using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Boid))]
public class Steer : MonoBehaviour
{
    protected Boid boid;
    protected Vector3 desiredVelocity;

    protected void Awake()
    {
        boid = GetComponent<Boid>();
    }
}