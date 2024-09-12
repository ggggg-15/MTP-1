using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class traffic_pos_z : MonoBehaviour
{
    // write a code to give the rigid body a force to move the car forward
    
    public Rigidbody rb;
    // public float forwardForce = 20f;

    // Update is called once per frame
    void FixedUpdate()
    {

        rb.AddForce(0, 0, 12);
        
    }
}
