using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class traffic_neg_z : MonoBehaviour
{
    public Rigidbody rb;
    // public float forwardForce = 20f;

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(0, 0, -12);
    }
}
