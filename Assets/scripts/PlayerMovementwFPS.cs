using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script deals with player movement while using first person camera settings
public class PlayerMovementwFPS : MonoBehaviour
{
    //  creating a ref of the player's char controller so we can call it to move the player
    public CharacterController CTRL;
    //setting up movement speed
    public float speed = 10f;
    void Update()
    {
        //getting input
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        
        //using vector3 with .forward & .right instead of vector3 , , , as a direction so the player doesnt move according to global orrintation
        Vector3 diresction = transform.right * x + transform.forward * z;
        //using the char controller to order the player to move according to the direction we set up
        CTRL.Move(diresction* speed* Time.deltaTime) ;
    }
}
