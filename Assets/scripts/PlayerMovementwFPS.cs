using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script deals with player movement while using first person camera settings
public class PlayerMovementwFPS : MonoBehaviour
{
    //  creating a ref of the player's char controller so we can call it to move the player
    public CharacterController CTRL;
    //setting up movement speed
    public float speed ;
    
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
    
    [SerializeField] 
    public int coinAmount ;    //creating a var to store the amount of coins collected so we can use the amount to open the door later

    [SerializeField] //to attach the GO in the script showed on the inspector
    private GameObject myCoin; //calling GO to use in destroy() 
    private void OnTriggerEnter(Collider myCoin)
    {
        if (myCoin.gameObject.CompareTag("coin"))
        {
            speed += 2; //the same speed var used in the movement code
            coinAmount += 1; // saves the coin amount in the var
            MouseCam.MouseSensitivity += 3; //called the var from another script (had to set it as static there)
            Destroy(myCoin.gameObject);
        }
    }

    [SerializeField] private GameObject exit;
    private void OnControllerColliderHit (ControllerColliderHit exit) //using this instead of oncolliderenter becz th game attached to this script has a char controller and wont be affected by it
    {
        if (coinAmount == 3 && exit.gameObject.CompareTag("exit"))
        {
            Destroy(exit.gameObject);
        }
        else if (coinAmount < 3 && exit.gameObject.CompareTag("exit"))
        {
            Debug.Log("collect all three speedboosts to open");
        }
    }
}
