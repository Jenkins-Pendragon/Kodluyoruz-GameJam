
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    private float speed;
   
    public Rigidbody rb;
    public Vector3 direction; //To forward 0,0,-1


    private void OnEnable()
    {
        EventManager.OnLevelSuccesed.AddListener(StopConveyorBelt);
        EventManager.OnLevelFinished.AddListener(StopConveyorBelt);
    }

    private void OnDisable()
    {
        EventManager.OnLevelSuccesed.RemoveListener(StopConveyorBelt);
        EventManager.OnLevelFinished.RemoveListener(StopConveyorBelt);
    }
    private void Start()
    {
        //0.5f static value that provide synchronization with curved roads
        speed = 0.5f * LevelManager.Instance.CurrentLevel.conveyorBeltSpeed;
    }
    private void StopConveyorBelt()
    {
        speed = 0f;
    }    
    void FixedUpdate()
    {  
        Vector3 pos = rb.position;
        rb.position += direction * speed * Time.fixedDeltaTime;
        rb.MovePosition(pos);  
    }
}
