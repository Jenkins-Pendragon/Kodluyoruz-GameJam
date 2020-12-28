using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class Item : MonoBehaviour
{
    public string itemID;
    public Sprite toyIcon;
    public GameObject itemPrefab;
    [HideInInspector]
    public bool isPackable = true;
    private void OnEnable()
    {
        Add();
    }
    public void OnDisable()
    {
        if (ItemDataBase.Instance!=null)
        {
            Remove();
        }        
        transform.DOKill();
    }

    private void Add() 
    {
        if (!ItemDataBase.Instance.activeItems.ContainsKey(this.itemID))
        {
            ItemDataBase.Instance.activeItems.Add(this.itemID, this);
        }
    }
    private void Remove()
    {
        ItemDataBase.Instance.activeItems.Remove(this.itemID);
    }
}