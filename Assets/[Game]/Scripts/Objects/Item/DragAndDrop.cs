using DG.Tweening;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private Vector3 mOffest;
    private float mZCoord;
    private Rigidbody rb;
    private Item item;
    private readonly float rotationDelay = 0.3f;
    private float defaultItemScale;
    private float maxItemScale;
    private float DefaultItemScale
    {
        get
        { 
            if(defaultItemScale == 0) 
            {
                defaultItemScale = LevelManager.Instance.CurrentLevel.defaultItemScale;
            }
            return defaultItemScale;
        } 
    }
    private float MaxItemScale
    {
        get
        {
            if (maxItemScale == 0)
            {
                maxItemScale = LevelManager.Instance.CurrentLevel.maxItemScale;
            }
            return maxItemScale;
        }
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        item = GetComponent<Item>();
    }

    private void OnMouseDown()
    {
        transform.DOKill();
        transform.DOScale(Vector3.one * MaxItemScale, rotationDelay);
        rb.isKinematic = true;
        item.isPackable = false;
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        mOffest = gameObject.transform.position + Vector3.up * 1.75f - GetMouseWorldPos();
        ResetRotation();
    }
    private void OnMouseUp()
    {
        transform.DOKill();
        transform.DOScale(Vector3.one * DefaultItemScale, 0.7f);
        rb.isKinematic = false;
        item.isPackable = true;
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