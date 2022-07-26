
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private int speed = 10;
    private Rigidbody _rb;
    private int rotSpeed = 30;
    void Start()
    {
        //getting the component rigidbody from the GO
        _rb = GetComponent<Rigidbody>();
    }

 
    void Update()
    {

        //defining the input keys for the vertical and horizontal movements
        float horizInput = Input.GetAxisRaw("Horizontal") * speed;
        float verticInput = Input.GetAxisRaw("Vertical") * speed;
       
        //apply the input defined ^ into vector 3 format
        Vector3 movement = new Vector3(horizInput, 0, verticInput);
        transform.Rotate(0, Input.GetAxis("Horizontal") * rotSpeed , 0);

        //applying the input to the GO's component (rigidbody) ((called in start))
        _rb.velocity = movement;
        movement.Normalize();
    }
}
