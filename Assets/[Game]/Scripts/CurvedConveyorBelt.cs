using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurvedConveyorBelt : MonoBehaviour
{
    public float speed;
    public Rigidbody rb;    

    void FixedUpdate()
    {
        Quaternion pos = rb.rotation;
        rb.rotation *= Quaternion.Euler(0, speed * Time.fixedDeltaTime, 0); 
        rb.MoveRotation(pos);
    }
}
