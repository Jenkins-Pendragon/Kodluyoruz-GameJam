using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DragAndDropTest : MonoBehaviour
{
    private bool dragging = false;
    private float distance;
    private float height;
    private Rigidbody rb;
    private Item item;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        item = GetComponent<Item>();
    }
    
    void OnMouseDown()
    {
        Vector3 dir = (this.transform.position - Camera.main.transform.position).normalized;
        transform.position -= dir * 2.5f;
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);

        height = transform.position.y;
        dragging = true;
        rb.isKinematic = true;
        item.isPackable = false;
        transform.DORotate(new Vector3(0, 90f, 90f), 0.3f);
    }

    void OnMouseUp()
    {
        dragging = false;
        rb.isKinematic = false;
        item.isPackable = true;
    }

    void Update()
    {
        if (dragging)
        {   
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(distance)+Vector3.up*2f;
            rayPoint.y = height;
            transform.position = rayPoint;
        }
    }
}


