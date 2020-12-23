using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ItemLevelManager : Singleton<ItemLevelManager>
{
    public List<Level> myAllLevels = new List<Level>();
    private ItemDataBase toyDatabase;
    public Dictionary<string, Item> activePool;
    public Dictionary<string, Item> activeOrder;
    private int currentLevel;
    private void Awake()
    {
        toyDatabase = GetComponent<ItemDataBase>();
    }
    private void OnEnable()
    {
        currentLevel = PlayerPrefs.GetInt("Level");
        activePool = toyDatabase.CreateLevelToys(myAllLevels[currentLevel].poolCount); // 5
        for (int i = 0; i < activePool.Count; i++)
        {
            Debug.Log("Pool Item: " + activePool.Keys.ElementAt(i));
        }
        NewOrder();
    }
    public void NewOrder()
    {
        activeOrder = toyDatabase.GenerateOrder(myAllLevels[currentLevel].spawnedCount, activePool); // 2
        for (int i = 0; i < activeOrder.Count; i++)
        {
            Debug.Log("Order Item: " + activeOrder.Keys.ElementAt(i));
        }
    }
    public void LevelUp()
    {
        PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);
    }
}

