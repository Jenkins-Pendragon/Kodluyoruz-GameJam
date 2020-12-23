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

    private void OnTriggerEnter(Collider other)
    {
        Item item = other.GetComponent<Item>();
        if (item != null)
        {
            PackItem(other.gameObject);
        }
    }

    private void PackItem(GameObject go) 
    {
        packedItems.Add(go);
        go.GetComponent<Rigidbody>().isKinematic = true;
        int count = packedItems.Count;
        for (int i = 0; i < packedItems.Count; i++)
        {
            packedItems[i].transform.DOMove(itemPoints[count - 1].points[i].position, tweenDelay);
            packedItems[i].transform.DOScale(Vector3.one * itemDownScale, tweenDelay);
        }        
    }

}

[System.Serializable]
public class Points 
{
    public Transform[] points;
}
