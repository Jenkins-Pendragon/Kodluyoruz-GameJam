using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundaries : MonoBehaviour
{
    private BoxCollider conveyorBelt;
    private float objectWidth;
    private float objectHeight;
    
    private void Start()
    {        
        //To Do: Get Conveyor Belt collider only once with static manager
        conveyorBelt = GameObject.FindGameObjectWithTag("ConveyorBelt").gameObject.GetComponent<BoxCollider>();
        
        var collider = gameObject.GetComponent<BoxCollider>();
        //We use (z,y) instead (x,z) because we rotate the object when onmousedrag.
        objectWidth = collider.bounds.size.z;
        objectHeight = collider.bounds.size.y;
    }

    private void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, conveyorBelt.bounds.min.x + objectWidth, conveyorBelt.bounds.max.x- objectWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, -1*Camera.main.transform.position.y / 2f, Camera.main.transform.position.y / 4f);
        viewPos.z = Mathf.Clamp(viewPos.z, conveyorBelt.bounds.min.z + objectHeight, conveyorBelt.bounds.max.z - objectHeight);
        transform.position = viewPos;
    }
}
