using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camfollow : MonoBehaviour
{
    //taking the transform values of our GO that we want our cam to follow 
    public Transform target;
    public Vector3 offset;



    

    private void LateUpdate()
    {

        // setting the position of our cam to be equal to the GO + the amount of distance between them 
        transform.position = target.position + offset;
        // ordering the cam to be pointed at our GO at all time
        transform.LookAt(target);



            }
}
