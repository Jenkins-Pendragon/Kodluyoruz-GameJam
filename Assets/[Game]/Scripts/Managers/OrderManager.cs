using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class OrderManager : Singleton<OrderManager>
{    
    private List<Item> ItemList { get { return ItemDataBase.Instance.itemDataBase; }}
    private Dictionary<string, Item> ActiveItems { get { return ItemDataBase.Instance.activeItems; } }

    //To select items in itemdatabase for the level
    public Dictionary<string, Item> SelectLevelItems(int levelItemSize)
    {        
        Dictionary<string, Item> levelItems = new Dictionary<string, Item>();
        for (int i = 0; i < levelItemSize; i++)
        {            
            int randomNumber = Random.Range(0, ItemList.Count);
            //Check if item aldready in levelItems
            if (!levelItems.ContainsKey(ItemList[randomNumber].itemID))
            {
                levelItems.Add(ItemList[randomNumber].itemID, ItemList[randomNumber]);
            }
            else i--;            
        }
        return levelItems;
    }
    public Dictionary<string, Item> GenerateOrder(int orderSize, Dictionary<string, Item> levelItems)
    {
        Dictionary<string, Item> orderItems = new Dictionary<string, Item>();
        for (int i = 0; i < orderSize; i++)
        {
            int randomNum = Random.Range(0, levelItems.Count);
            //Check if item aldready in orderItems
            if (!orderItems.ContainsKey(levelItems.Keys.ElementAt(randomNum)))
            {
                orderItems.Add(levelItems.Keys.ElementAt(randomNum), levelItems.Values.ElementAt(randomNum));
            }
            else i--;            
        }
        return orderItems;
    }
    public Dictionary<string, Item> orderItems = new Dictionary<string, Item>();
    public Dictionary<string, Item> levelItems = new Dictionary<string, Item>();

    private void OnEnable()
    {
        EventManager.OnGameStarted.AddListener(NewOrder);        
    }

    private void OnDisable()
    {
        EventManager.OnGameStarted.RemoveListener(NewOrder);        
    }

    public void NewOrder()
    {        
        if (ActiveItems.Count == 0)
        {
            orderItems = GenerateOrder(LevelManager.Instance.CurrentLevel.orderItemSize, levelItems);
        }
        else 
        {
            orderItems = GenerateOrder(LevelManager.Instance.CurrentLevel.orderItemSize, ActiveItems);
        }
        Debug.Log("#######################");
        Debug.Log("CurrentLevel:" + LevelManager.Instance.CurrentLevel);
        for (int i = 0; i < orderItems.Count; i++)
        {
            Debug.Log("Order Items" + i+": " + orderItems.ElementAt(i).Key);
        }
        Debug.Log("#######################");

        for (int i = 0; i < ActiveItems.Count; i++)
        {
            Debug.Log("ActiveItems" + i + ": " + ActiveItems.ElementAt(i).Key);
        }
        Debug.Log("#######################");
        for (int i = 0; i < ActiveItems.Count; i++)
        {
            Debug.Log("LevelItems" + i + ": " + levelItems.ElementAt(i).Key);
        }
        Debug.Log("#######################");
        EventManager.OnOrderGenerated.Invoke();
    }
    public void SetLevelItems()
    {
        levelItems = SelectLevelItems(LevelManager.Instance.CurrentLevel.levelItemSize);
    }
    
}
