using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
