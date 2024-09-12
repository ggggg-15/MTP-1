using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Text;
using System.IO;
public class Moving_car : MonoBehaviour
{
    // Start is called before the first frame update
    // void Start()
    // {

    // }

    // public WheelCollider[] wheels = new WheelCollider[4];
    
    // public float motorTorque = 100;
    // public int maxSteer = 4;



    ////////////
    // public float carSpeed = 0.02f;

    // // Update is called once per frame
    // private void Update()
    // {
    //     // move the car to the left if left arrow is selected, right if right arrow, and up for forward, down for backward
    //     if(gameObject.tag == "grey_car_1")
    //     {

    //         if(Input.GetKey(KeyCode.UpArrow))
    //         {
    //             transform.Translate(0,0,carSpeed);
    //         }
    //         if(Input.GetKey(KeyCode.DownArrow))
    //         {
    //             transform.Translate(0,0,-carSpeed);
    //         }
    //         // left and right arrows should help me turn the car
    //         if(Input.GetKey(KeyCode.LeftArrow))
    //         {
    //             transform.Rotate(0,-90,0);
    //         }
    //         if(Input.GetKey(KeyCode.RightArrow))
    //         {
    //             transform.Rotate(0,90,0);
    //         }
    //         // also generate a csv file with the timestamp and the position of the car
    //         string path = "Assets/MyTest.csv";
    //         StreamWriter writer = new StreamWriter(path, true);
    //         writer.WriteLine(System.DateTime.Now + "," + transform.position.x + "," + transform.position.z);
    //         writer.Close();


    //     } 
    // }

    ////////////
    ///
    // private void FixedUpdate()
    // {
    //     // give the grey car codition 
    //     // if (gameObject.tag == "grey_car_1")
    //     // {
    //         if (Input.GetKey(KeyCode.UpArrow))
    //         {
    //             for (int i = 0; i < wheels.Length; i++)
    //             {
    //                 wheels[i].motorTorque = motorTorque;
    //             }
    //         }
    //         else{
    //             for (int i = 0; i < wheels.Length; i++)
    //             {
    //                 wheels[i].motorTorque = 0;
    //             }
    //         }

    //         // else if (Input.GetKey(KeyCode.DownArrow))
    //         // {
    //         //     for (int i = 0; i < wheels.Length; i++)
    //         //     {
    //         //         wheels[i].motorTorque = -motorTorque;
    //         //     }
    //         // }

    //         // else if (Input.GetKey(KeyCode.LeftArrow))
    //         // {
    //         //     wheels[0].steerAngle = -maxSteer;
    //         //     wheels[1].steerAngle = -maxSteer;
    //         // }

    //         // else if (Input.GetKey(KeyCode.RightArrow))
    //         // {
    //         //     wheels[0].steerAngle = maxSteer;
    //         //     wheels[1].steerAngle = maxSteer;
    //         // } 
    //         // else
    //         // {
    //         //     for (int i = 0; i < wheels.Length; i++)
    //         //     {
    //         //         wheels[i].motorTorque = 0;
    //         //         wheels[i].steerAngle = 0;
    //         //     }
    //         // }
    //     // }

    // }

    //////////////// attempt 3 = makes forward and backward smooth, but the turns arent smooth

    // // This is a reference to the Rigidbody component called "rb"
	// public Rigidbody rb;

	// public float forwardForce = 200f;	// Variable that determines the forward force
	// // public float sidewaysForce = 500f;  // Variable that determines the sideways force

	// // We marked this as "Fixed"Update because we
	// // are using it to mess with physics.
	// void FixedUpdate ()
	// {
	// 	// Add a forward force
	// 	// rb.AddForce(0, 0, forwardForce * Time.deltaTime);

	// 	if (Input.GetKey(KeyCode.UpArrow))	
	// 	{
	// 		// Add a force to the right
	// 		rb.AddForce(0, 0, forwardForce * Time.deltaTime);
	// 	}

	// 	if (Input.GetKey(KeyCode.DownArrow))  
	// 	{
	// 		// Add a force to the left
	// 		rb.AddForce(0, 0, -forwardForce * Time.deltaTime);
	// 	}

    //     // if right arrow key is oressed, rotate by 90 degress
    //     if (Input.GetKey(KeyCode.RightArrow))
    //     {
    //         transform.Rotate(0,90,0);
    //     }

    //     // if left arrow key is oressed, rotate by 90 degress
    //     if (Input.GetKey(KeyCode.LeftArrow))
    //     {
    //         transform.Rotate(0,-90,0);
    //     }
	// }

    ///// Attempt 4 = makes the car move forward and backward smoothly, with the turns also being smooth

    public float Movespeed = 20f;
    public float Turnspeed = 0.4f;
    public Rigidbody rb = null;

    private void FixedUpdate()
    {
        float vert = Input.GetAxis("Vertical");     // wasd, arrows, left-analog gamepad
        float horz = Input.GetAxis("Horizontal");   // -1..0..1

        rb.AddRelativeForce(Vector3.forward * vert * Movespeed, ForceMode.Acceleration);
        rb.AddRelativeTorque(Vector3.up * horz * Turnspeed, ForceMode.VelocityChange);

        // also generate a csv file with the timestamp and whether the car is taking left right or coliding with something
            
    }

    private void OnTriggerEnter(Collider other)
    {
        // if the car collides with an 3D object, generate a csv file with the timestamp and the position of the car
        string path = "Assets/MyTest.csv";
        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine(System.DateTime.Now + "," + transform.position.x + "," + transform.position.z + "Hit detected");
        writer.Close();
        
    }

}
