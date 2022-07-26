
using UnityEngine;

public class CyMover : MonoBehaviour
{
    //private int rotSpeed = 200;
    public CharacterController _controller;
    public float _speed = 5f;
    
   
    
    void Start()
    {
        // controller = GetComponent<CharacterController>();  
    }


    void Update()
    {
        // float horizInput = Input.GetAxisRaw("Horizontal");
        // float verticInput = Input.GetAxisRaw("Vertical");
        //
        // Vector3 movDirec = new Vector3(horizInput, 0, verticInput);
        //
        // float magnitude = Mathf.Clamp01(movDirec.magnitude) * speed;
        // movDirec.Normalize();
        //
        // //SimpleMove method have time.delta built in
        // controller.SimpleMove(movDirec * magnitude);
        //
        //
        // if (movDirec != Vector3.zero)
        // {
        //     Quaternion torotate = Quaternion.LookRotation(movDirec, Vector3.up);
        //     transform.rotation = Quaternion.RotateTowards(transform.rotation, torotate, rotSpeed * Time.deltaTime);
        // }
        float horizInput = Input.GetAxisRaw("Horizontal") * _speed;
        float verticInput = Input.GetAxisRaw("Vertical") * _speed;

        Vector3 _direction = new Vector3(horizInput, 0f, verticInput).normalized;

        //telling the player to move according to the input
        if (_direction.magnitude >= 0.1f)
        {
            //to point our player facing forward with each turn (aka rotation) + the * by radius is cuz the atan will return a radius value
            float _targetAngel = Mathf.Atan2(_direction.x, _direction.z) * Mathf.Rad2Deg;
            //setting our rotation according to the previous line of code
            transform.rotation = Quaternion.Euler(0f, _targetAngel, 0f);

            //changes the GO 
          Vector3 final_di = transform.TransformDirection( _direction );
            _controller.Move(_direction  * _speed * Time.deltaTime );
          //  Debug.Log($"Move Vector: {_direction} -- Transformed Vector: {final_di}");

        }
        
       
        
       

    }
    
}

