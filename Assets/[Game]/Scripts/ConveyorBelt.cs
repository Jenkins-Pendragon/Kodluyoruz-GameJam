
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    public float speed;
    public Rigidbody rb;
    public Vector3 direction; //To forward 0,0,-1
    
    void FixedUpdate()
    {  
        Vector3 pos = rb.position;
        rb.position += direction * speed * Time.fixedDeltaTime;
        rb.MovePosition(pos);  
    }
}
