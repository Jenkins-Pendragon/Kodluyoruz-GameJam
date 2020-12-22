using DG.Tweening;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private Vector3 mOffest;
    private float mZCoord;
    private Rigidbody rb;
    private readonly float rotationDelay = 0.3f;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnMouseDown()
    {
        rb.isKinematic = true;
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        mOffest = gameObject.transform.position + Vector3.up - GetMouseWorldPos();
        ResetRotation();
    }
    private void OnMouseUp()
    {
        rb.isKinematic = false;
    }
    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mZCoord;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    private void OnMouseDrag()
    {        
        transform.position = GetMouseWorldPos() + mOffest;
    }

    private void ResetRotation() 
    {
        transform.DORotate(new Vector3(0, 90f, 90f), rotationDelay);
    }
}