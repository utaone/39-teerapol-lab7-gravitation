using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Attrator : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    const float G = 667.4f;

    public static List<Attrator> Attractors;

    private void FixedUpdate()
    {
        foreach (var attrator in Attractors)
        {
            if (attrator != this)
            Attract(attrator);
        }
    }

    //store planets in list of Attrators;
    private void OnEnable()
    {
        if (Attractors == null)
        {
            Attractors = new List<Attrator>();
        }
        
        Attractors.Add(this);
            
    }
    
    //calculate Universal Gravitation
    void Attract(Attrator other)
    {
        Rigidbody rbOther = other.rb;
        
        //F = G(m1*m2)/r^2
        Vector3 direction = rb.position - rbOther.position;

        float distance = direction.magnitude;

        float forceMignitude = G * (rb.mass * rbOther.mass)/ Mathf.Pow(distance,2);

        Vector3 finalForce = forceMignitude * direction.normalized;
        
        rbOther.AddForce(finalForce);

    }
}
