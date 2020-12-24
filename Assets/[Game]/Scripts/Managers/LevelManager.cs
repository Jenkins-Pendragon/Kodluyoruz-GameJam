﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LevelManager : Singleton<LevelManager>
{
    public LevelData LevelData;
    public Level CurrentLevel { get { return (LevelData.Levels[LevelIndex]); } }
    public Dictionary<string, Item> levelItems;
    public Dictionary<string, Item> orderItems;    

    public int LevelIndex
    {
        get
        {
            return PlayerPrefs.GetInt("LastLevel", 0);
        }
        set
        {
            if (value >= LevelData.Levels.Count)
                value = 0;

            PlayerPrefs.SetInt("LastLevel", value);
        }
    }

    private void SetLevelItems() 
    {
        levelItems = OrderManager.Instance.SelectLevelItems(CurrentLevel.levelItemSize);
    }
    public void NewOrder()
    {
        orderItems = OrderManager.Instance.GenerateOrder(CurrentLevel.orderItemSize, levelItems);      
    }    
}

