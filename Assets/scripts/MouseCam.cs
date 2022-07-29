using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script will deal with moving the player with FPS camera
public class MouseCam : MonoBehaviour
{
    //to control the speed the mouse looks around with
    public float MouseSensitivity = 100f;
    //creating a var to represent the player GO so we can use it for moving left and right
    public Transform OurPlayer;
    // creating a var for the rotation around the x axis so we can use it to look up and down with the cam
     float rotationXX = 0f;
    void Start()
    {
        //to lock the cursor to the center of the screen
        Cursor.lockState = CursorLockMode.Locked;
    }

   
    void Update()
    {
        //getting the mouse input for the player to look up and donw and left and right with the cam
        float mousexx = Input.GetAxis("Mouse X") * MouseSensitivity * Time.deltaTime;
        float mouseyy = Input.GetAxis("Mouse Y")* MouseSensitivity * Time.deltaTime;

        //setting up rotation up and down instead of doing the rotate method so we can clamp (restrict) it to 90 degrees 
        rotationXX += mouseyy;
        //clamping the rotation from line 31
        rotationXX = Mathf.Clamp(rotationXX, -90f, 90f);
        
        //rotating up and down
        transform.localRotation = Quaternion.Euler(rotationXX,0f,0f);
        // linking the mouse x input to the player so itll rotate with where the mouse moved the camera
        OurPlayer.Rotate(Vector3.up * mousexx);
    }
}
