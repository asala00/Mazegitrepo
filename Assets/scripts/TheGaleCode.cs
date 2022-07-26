
using UnityEngine;

public class TheGaleCode : MonoBehaviour
{

    private GameObject Player;
    private CharacterController charCntrol;
    public CharacterController _controller;
    public float _speed = 5f;



    // Update is called once per frame
    void Update()
    {
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
           //// Vector3 final_di = transform.TransformDirection(_direction);
            _controller.Move(_direction * _speed * Time.deltaTime);
            
        }
        handleMovement();


        
    }
    void handleMovement()
    {
        var direction = GetMove();
        var rota = Player.transform.rotation.eulerAngles;

        rota.x = 0f;
        Quaternion q = Quaternion.Euler(rota);
        rota = q * direction;

        charCntrol.Move(rota);

    }

    Vector3 GetMove()
    {
        float horzInput = Input.GetAxisRaw("Horizontal");
        float verInput = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(horzInput, 0, verInput);
        if (movement.magnitude > 1f)
        {
            movement.Normalize();

        }

        return movement;
    }
}
