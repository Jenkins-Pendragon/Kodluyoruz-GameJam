
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    private float speed;
    private float Speed
    { 
        get
        {
            if (speed == 0)
            {
                speed = 0.5f * LevelManager.Instance.CurrentLevel.conveyorBeltSpeed;
            }
            return speed;
        }
    }
    public Rigidbody rb;
    public Vector3 direction; //To forward 0,0,-1
    
    void FixedUpdate()
    {  
        Vector3 pos = rb.position;
        rb.position += direction * Speed * Time.fixedDeltaTime;
        rb.MovePosition(pos);  
    }
}
