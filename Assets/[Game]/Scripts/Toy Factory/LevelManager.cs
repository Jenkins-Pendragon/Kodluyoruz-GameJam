using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public List<Level> myAllLevels = new List<Level>();
    private ToyDatabase toyDatabase;
    public Dictionary<int, Toy> activePool;
    public Dictionary<int, Toy> activeOrder;
    private int currentLevel;
    private void Awake()
    {
        toyDatabase = GetComponent<ToyDatabase>();
    }
    private void OnEnable()
    {
        currentLevel = PlayerPrefs.GetInt("Level");
        activePool = toyDatabase.CreateLevelToys(myAllLevels[currentLevel].poolCount); // 5
        NewOrder();
    }
    public void NewOrder()
    {
        activeOrder = toyDatabase.GenerateOrder(myAllLevels[currentLevel].spawnedCount, activePool); // 2
    }
    public void LevelUp()
    {
        PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);
    }
}
[System.Serializable]
public class Level
{
    public int spawnedCount;
    public int poolCount;
    public Level(int spawnedCount, int poolCount)
    {
        this.spawnedCount = spawnedCount;
        this.poolCount = poolCount;
    }
}
