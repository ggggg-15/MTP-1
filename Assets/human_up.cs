using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class human_up : MonoBehaviour
{
     public Rigidbody rb;
    // public float forwardForce = 20f;

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(0, 0, 14);
    }
}
