using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private int speed = 5;
    private Rigidbody rb;

    void Start()
    {
        //getting the component rigidbody from the GO
        rb = GetComponent<Rigidbody>();
    }

 
    void Update()
    {

        //defining the input keys for the vertical and horizontal movements
        float HorizInput = Input.GetAxisRaw("Horizontal") * speed;
        float VerticInput = Input.GetAxisRaw("Vertical") * speed;
       
        //apply the input defined ^ into vector 3 format
        Vector3 movement = new Vector3(HorizInput, 0, VerticInput);

        //applying the input to the GO's component (rigidbody) ((called in start))
        rb.velocity = movement;
    }
}
