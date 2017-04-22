using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Manager : MonoBehaviour
{
    private static Manager m_Instance;
    public static Manager Instance { get { return m_Instance; } }

    public Obstacle[] Obstacles { get; private set; }

    protected void Awake()
    {
        if (m_Instance == null)
        {
            m_Instance = this;
        }

        GetAllObstacles();    
    }

    private void GetAllObstacles()
    {
        /*
        MonoBehaviour[] scripts = FindObjectsOfType<MonoBehaviour>();
        foreach (MonoBehaviour script in scripts)
        {
            script.enabled = false;
        }
        */

        //Obstacle[] o = FindObjectsOfType<Obstacle>();
        Obstacles = FindObjectsOfType<Obstacle>();
    }
}