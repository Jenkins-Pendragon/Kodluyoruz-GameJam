using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeDrag : MonoBehaviour
{
    private Vector3 moffset;
    private float mZCoord;
    private void OnMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        moffset = new Vector3(gameObject.transform.position.x,3, gameObject.transform.position.z) - GetMouseWorldPos();
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;

        mousePoint.z = mZCoord;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    private void OnMouseDrag()
    {
        transform.position = GetMouseWorldPos() + moffset;
    }
}
