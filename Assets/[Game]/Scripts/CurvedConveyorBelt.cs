using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurvedConveyorBelt : MonoBehaviour
{
    public float speed;
    public Rigidbody rb;
    public float direction;



    // Update is called once per frame
    void FixedUpdate()
    {
        /*
        Quaternion pos = rb.rotation;
        Debug.Log(rb.rotation.eulerAngles);
        rb.rotation = Quaternion.AngleAxis(-45, Vector3.up);
        Debug.Log(rb.rotation.eulerAngles);  
        rb.MoveRotation(pos);
        */
        Quaternion pos = rb.rotation;
        rb.rotation *= Quaternion.Euler(0, direction * speed * Time.fixedDeltaTime, 0); 
        rb.MoveRotation(pos);
    }
}
