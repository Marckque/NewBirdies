using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class BoidDebug
{
    public bool seeDesiredVelocity;
    public bool seeTargetVelocity;
    public bool seeBoidAvoidanceVelocity;
}

public class Boid : MonoBehaviour
{
    public BoidDebug bdDbg;
    public Transform m_Target;
    public float m_Speed;
    public float minSpeed;
    public float m_MinimumDistanceToOtherBoid;

    private Vector3 m_TargetVelocity;
    public List<Boid> m_OtherBoids = new List<Boid>();
    private Vector3 m_BoidAvoidanceVelocity;
    private Vector3 m_DesiredVelocity;

    protected void Update()
    {
        SetAllVelocities();

        if (bdDbg.seeDesiredVelocity) Debug.DrawRay(transform.position, m_DesiredVelocity, Color.green);

        if (m_DesiredVelocity.magnitude > minSpeed)
        {
            transform.Translate(m_DesiredVelocity.normalized * m_Speed * Time.deltaTime);
        }

        ResetVelocities();
    }

    private void AddAcceleration(Vector3 force)
    {
        m_DesiredVelocity += force;
    }

    private void ResetVelocities()
    {
        m_TargetVelocity = Vector3.zero;
        m_BoidAvoidanceVelocity = Vector3.zero;
    }

    private void SetAllVelocities()
    {
        TargetVelocity();
        BoidAvoidanceVelocity();
    }

    private void TargetVelocity()
    {
        m_TargetVelocity = m_Target.position - transform.position;

        if (bdDbg.seeTargetVelocity) Debug.DrawRay(transform.position, m_TargetVelocity, Color.magenta);
        
        AddAcceleration(m_TargetVelocity);
    }

    private void BoidAvoidanceVelocity()
    {
        foreach(Boid boid in m_OtherBoids)
        {
            Vector3 boidDifference = transform.position - boid.transform.position;
            if (boidDifference.sqrMagnitude < m_MinimumDistanceToOtherBoid)
            {
                m_BoidAvoidanceVelocity += boidDifference;
            }
        }

        if (bdDbg.seeBoidAvoidanceVelocity) Debug.DrawRay(transform.position, m_BoidAvoidanceVelocity, Color.cyan);

        AddAcceleration(m_BoidAvoidanceVelocity);
    }
}