using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Level Level1 = new Level(2,20);


}
public class Level
{
    public int spawnedCount;
    public int poolCount;
    public Level(int orderCount, int poolCount)
    {
        spawnedCount = orderCount;
        this.poolCount = poolCount;
    }
}
