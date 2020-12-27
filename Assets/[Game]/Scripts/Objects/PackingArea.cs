using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Linq;

public class PackingArea : MonoBehaviour
{
    public List<Points> itemPoints;
    public float itemDownScale = 0.1f;
    public float tweenDelay = 0.2f;
    public Transform jumpPoint;
    public WaitForSeconds checkDelay = new WaitForSeconds(0.5f);

    //List for items in the gif box
    private List<GameObject> packedItems = new List<GameObject>();
    private bool isColliding;
    

    #region Perspective Camera Simulation
    private float defaultItemScale;
    private float maxItemScale;
    private float DefaultItemScale
    {
        get
        {
            if (defaultItemScale == 0)
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
    #endregion

    private void OnEnable()
    {
        EventManager.OnOrderFailed.AddListener(ResetPackedItemList);
    }

    private void OnDisable()
    {
        EventManager.OnOrderFailed.RemoveListener(ResetPackedItemList);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (isColliding) return;

        Item item = other.GetComponent<Item>();
        if (item != null && item.isPackable)
        {
            //Check if the item ordered
            //|| packedItems.Find(go => go.GetComponent<Item>().itemID == item.itemID) != null)
            if (!OrderManager.Instance.orderItems.ContainsKey(item.itemID))
            {
                WrongItem(other.gameObject);
                return;
            }

            OrderManager.Instance.orderItems.Remove(item.itemID);
            isColliding = true;
            PackItem(other.gameObject);
            DisableItem(other.gameObject);
            StartCoroutine(CheckOrder());
        }
    }

    IEnumerator CheckOrder() 
    {
        yield return checkDelay;
        if (OrderManager.Instance.orderItems.Count == 0)
        {
            EventManager.OnOrderCompleted.Invoke();
            ResetPackedItemList();
        }
    }

    private void ResetPackedItemList()
    {
        foreach (GameObject item in packedItems)
        {
            Destroy(item);
        }
        packedItems = new List<GameObject>();
    }

    private void PackItem(GameObject go)
    {
        packedItems.Add(go);        
        int count = packedItems.Count;
        //Safety for bugs
        if (count > itemPoints.Count)
        {
            packedItems.Remove(go);
            return;
        }
        //Kill all tweens relavent with this object.        
        go.transform.DOKill();
        for (int i = 0; i < packedItems.Count; i++)
        {
            packedItems[i].transform.DOMove(itemPoints[count - 1].points[i].position, tweenDelay);
            packedItems[i].transform.DORotate(new Vector3(0, 90f, 90f), tweenDelay);
            packedItems[i].transform.DOScale(Vector3.one * itemDownScale, tweenDelay);
        }
    }



    //If the item dosent ordered, jump though the belt
    private void WrongItem(GameObject go)
    {        
        go.transform.DORotate(new Vector3(0, 90f, 90f), 0.5f);
        go.transform.DOJump(jumpPoint.position, 1.75f, 1, 0.5f);

        
        Sequence seq = DOTween.Sequence();
        seq.Append(go.transform.DOScale(Vector3.one * MaxItemScale, 0.25f));
        seq.Append(go.transform.DOScale(Vector3.one * DefaultItemScale, 0.25f));
        
    }

    private void DisableItem(GameObject go)
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
