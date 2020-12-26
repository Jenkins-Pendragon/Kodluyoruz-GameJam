using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LevelManager : Singleton<LevelManager>
{
    public LevelData LevelData;
    public Level CurrentLevel { get { return (LevelData.Levels[LevelIndex]); } }
    public Dictionary<string, Item> levelItems = new Dictionary<string, Item>();
    public Dictionary<string, Item> orderItems = new Dictionary<string, Item>();
    


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

    private void OnEnable()
    {
        EventManager.OnGameStarted.AddListener(SetLevelItems);
        EventManager.OnLevelStarted.AddListener(NewOrder);
        EventManager.OnOrderCompleted.AddListener(NewOrder);
    }

    private void OnDisable()
    {
        EventManager.OnGameStarted.RemoveListener(SetLevelItems);
        EventManager.OnLevelStarted.RemoveListener(NewOrder);
        EventManager.OnOrderCompleted.RemoveListener(NewOrder);
    }

    private void SetLevelItems() 
    {
        levelItems = OrderManager.Instance.SelectLevelItems(CurrentLevel.levelItemSize);
        EventManager.OnLevelStarted.Invoke();
    }
    public void NewOrder()
    {
        orderItems = OrderManager.Instance.GenerateOrder(CurrentLevel.orderItemSize, levelItems);
        EventManager.OnOrderGenerated.Invoke();        
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            NewOrder();
            
        }
    }
}

