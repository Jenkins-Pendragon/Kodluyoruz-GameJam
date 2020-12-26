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

    public void OnDisable()
    {
        transform.DOKill();
    }
}