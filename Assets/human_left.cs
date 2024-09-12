using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class human_left : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody rb;
    // public float forwardForce = 20f;

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(-13, 0, 0);
    }
}
