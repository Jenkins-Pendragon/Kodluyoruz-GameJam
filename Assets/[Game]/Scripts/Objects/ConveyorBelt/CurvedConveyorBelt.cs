using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurvedConveyorBelt : MonoBehaviour
{
    private float speed;   
    public Rigidbody rb;

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
        //20f static value that provide synchronization with straight roads
        speed = -20f * LevelManager.Instance.CurrentLevel.conveyorBeltSpeed;
    }
    private void StopConveyorBelt() 
    {
        speed = 0f;
    }

    void FixedUpdate()
    {
        Quaternion pos = rb.rotation;
        rb.rotation *= Quaternion.Euler(0, speed * Time.fixedDeltaTime, 0); 
        rb.MoveRotation(pos);
    }
}
