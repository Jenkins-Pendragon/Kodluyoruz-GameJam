using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurvedConveyorBelt : MonoBehaviour
{
    private float speed;
    private float Speed
    { get
        {
            if (speed == 0)
            {
                //20f static value that provide synchronization with straight roads
                speed = -20f * LevelManager.Instance.CurrentLevel.conveyorBeltSpeed;
            }
            return speed;
        }
    }
    public Rigidbody rb;    

    void FixedUpdate()
    {
        Quaternion pos = rb.rotation;
        rb.rotation *= Quaternion.Euler(0, Speed * Time.fixedDeltaTime, 0); 
        rb.MoveRotation(pos);
    }
}
