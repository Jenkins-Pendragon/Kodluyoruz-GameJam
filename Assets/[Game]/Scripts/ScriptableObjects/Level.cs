using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Level", menuName = "Level")]
public class Level: ScriptableObject
{
    public int orderItemSize;
    public int levelItemSize;
    public float conveyorBeltSpeed;
    [Range(1f, 10f)]
    public float spawnDelay;
    public float defaultItemScale;
    public float maxItemScale;
    public float happinessTotal;
}
