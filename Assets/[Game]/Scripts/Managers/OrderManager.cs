using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class OrderManager : Singleton<OrderManager>
{    
    private List<Item> ItemList { get { return ItemDataBase.Instance.itemDataBase; }}

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
        EventManager.OnOrderCompleted.AddListener(NewOrder);
    }

    private void OnDisable()
    {
        EventManager.OnGameStarted.RemoveListener(NewOrder);
        EventManager.OnOrderCompleted.RemoveListener(NewOrder);
    }

    public void NewOrder()
    {
        orderItems = GenerateOrder(LevelManager.Instance.CurrentLevel.orderItemSize, levelItems);
        EventManager.OnOrderGenerated.Invoke();
    }

    public void SetLevelItems()
    {
        levelItems = SelectLevelItems(LevelManager.Instance.CurrentLevel.levelItemSize);
    }



    
    
}
