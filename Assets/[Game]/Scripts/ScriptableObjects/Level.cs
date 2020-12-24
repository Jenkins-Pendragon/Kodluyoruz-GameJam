using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Level", menuName = "Level")]
public class Level: ScriptableObject
{
    public int orderItemSize;
    public int levelItemSize;
    public Level(int _orderItemSize, int _levelItemSize)
    {
        this.orderItemSize = _orderItemSize;
        this.levelItemSize = _levelItemSize;
    }
}
