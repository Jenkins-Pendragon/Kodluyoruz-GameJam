using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LevelManager : Singleton<LevelManager>
{
    public List<Level> myAllLevels = new List<Level>();    
    public Dictionary<string, Item> activePool;
    public Dictionary<string, Item> activeOrder;
    private int currentLevel;
   
    private void OnEnable()
    {
        currentLevel = PlayerPrefs.GetInt("Level");
        activePool = ItemDataBase.Instance.CreateLevelToys(myAllLevels[currentLevel].poolCount); // 5
        /*
        for (int i = 0; i < activePool.Count; i++)
        {
            Debug.Log("Pool Item: " + activePool.Keys.ElementAt(i));
        }
        */
        NewOrder();
    }
    public void NewOrder()
    {
        activeOrder = ItemDataBase.Instance.GenerateOrder(myAllLevels[currentLevel].spawnedCount, activePool); // 2        
    }
    public void LevelUp()
    {
        PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);
    }
}

