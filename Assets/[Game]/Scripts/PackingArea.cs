using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PackingArea : MonoBehaviour
{   
    public List<Points> itemPoints;
    public float itemDownScale = 0.1f;
    public float tweenDelay = 0.2f;
    private List<GameObject> packedItems = new List<GameObject>();
    private bool isColliding;

    private void OnTriggerEnter(Collider other)
    {
        if (isColliding) return;

        Item item = other.GetComponent<Item>();
        if (item != null && item.isPackable)
        {
            if (!ItemLevelManager.Instance.activeOrder.ContainsKey(item.itemID))
                return;
            isColliding = true;            
            PackItem(other.gameObject);
            ResetItem(other.gameObject);
        }
    }

    private void PackItem(GameObject go) 
    {
        packedItems.Add(go);
        int count = packedItems.Count;
        if (count > itemPoints.Count)
        {
            packedItems.Remove(go);
            return;
        }        
        for (int i = 0; i < packedItems.Count; i++)
        {
            packedItems[i].transform.DOMove(itemPoints[count - 1].points[i].position, tweenDelay);
            packedItems[i].transform.DORotate(new Vector3(0, 90f, 90f), tweenDelay);
            packedItems[i].transform.DOScale(Vector3.one * itemDownScale, tweenDelay);
        }        
    }

    private void ResetItem(GameObject go) 
    {
        go.GetComponent<BoxCollider>().enabled = false;
        go.GetComponent<Rigidbody>().isKinematic = true;
        isColliding = false;
    }

}

[System.Serializable]
public class Points 
{
    public Transform[] points;
}
