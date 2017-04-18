using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Item : MonoBehaviour
{
    protected void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MainAction();
        }

        if (Input.GetMouseButtonDown(1))
        {
            SecondaryAction();
        }
    }

    protected virtual void MainAction()
    {   
    }

    protected virtual void SecondaryAction()
    {
    }

    public virtual void OnActivation()
    {
        gameObject.SetActive(true);
    }

    public virtual void OnDeactivation()
    {
        gameObject.SetActive(false);
    }
}