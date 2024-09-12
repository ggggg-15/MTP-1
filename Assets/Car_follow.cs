 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_follow : MonoBehaviour
{
    /////////////////////// attempt one 

    // public Transform player;
    // public Vector3 offset;
 

    // // Update is called once per frame
    // void Update()
    // {
    //     Debug.Log(player.position); // need to add the postions of the player in a csv file
    //     transform.position = player.position + offset;
        

    // }

    ///////////////////////
    /////////////////////// attempt two
     public GameObject player;
     public float speed;
    public Vector3 offset;
    // public float player_location;

     private void Awake(){
            player = GameObject.FindGameObjectWithTag("grey_car_1");
     }

     private void FixedUpdate(){
        follow(); 
     }

     private void follow(){
        
         gameObject.transform.position = Vector3.Lerp(transform.position,player.transform.position,speed*Time.deltaTime)+offset;
        // gameObject.transform.position = player.transform.position + offset;
         gameObject.transform.LookAt(player.gameObject.transform.position);
     }
}
