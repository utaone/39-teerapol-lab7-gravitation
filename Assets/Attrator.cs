using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Attrator : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    const float G = 0.6674f;

    public static List<Attrator> Attrators;

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
