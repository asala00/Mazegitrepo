
using System;
using Unity.VisualScripting;
using UnityEngine;

public class CyMover : MonoBehaviour
{

    public CharacterController _controller;

    [SerializeField] public float _speed = 5.0f;

    //ref for our cam so we can use it to change where our GO's forward is (the way the camera is facing)
    public Transform cam;

  

    void Update()
    {
        float horizInput = Input.GetAxisRaw("Horizontal") * _speed;
        float verticInput = Input.GetAxisRaw("Vertical") * _speed;

        Vector3 _direction = new Vector3(horizInput, 0f, verticInput).normalized;

        //telling the player to move according to the input
        if (_direction.magnitude >= 0.1f)
        {
            //to point our player facing forward with each turn (aka rotation)
            //+ the * by radius is cuz the atan will return a radius value
            //used cam.eulerAngles.y to add it the targets angle by the cameras
            float _targetAngel = Mathf.Atan2(_direction.x, _direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            //setting our rotation according to the previous line of code
            transform.rotation = Quaternion.Euler(0f, _targetAngel, 0f);
            //changes the GO dierction istead of just rotation
            Vector3 moveDirection = Quaternion.Euler(0f, _targetAngel, 0f) * Vector3.forward;

            _controller.Move(moveDirection.normalized * _speed * Time.deltaTime);
        }

    }

    [SerializeField] 
    public int coinAmount ;    //creating a var to store the amount of coins collected so we can use the amount to open the door later

    [SerializeField] //to attach the GO in the script showed on the inspector
    private GameObject myCoin; //calling GO to use in destroy() 
    private void OnTriggerEnter(Collider myCoin)
    {
        if (myCoin.gameObject.CompareTag("coin"))
        {
            _speed += 1; //the same speed var used in the movement code
            coinAmount += 1; // saves the coin amount in the var
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
    }
}

