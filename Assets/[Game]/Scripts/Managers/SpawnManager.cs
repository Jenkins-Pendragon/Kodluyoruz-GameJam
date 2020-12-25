using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SpawnManager : Singleton<SpawnManager>
{

    public Transform SpawnLeft;
    public Transform SpawnRight;
    [Tooltip("Oyuncak spawn hızını belirler")]
    public float SpawnRatio = 3;    
   
    private void Start()
    {        
        StartCoroutine(SpawnCo());
    }
    
    IEnumerator SpawnCo()
    {
        while (true)
        {           
            Vector3 posR = new Vector3(Random.Range(SpawnLeft.position.x, SpawnRight.position.x), -0.87f, -1.472f);
            int random = Random.Range(0, LevelManager.Instance.levelItems.Count);
            Instantiate(LevelManager.Instance.levelItems.Values.ElementAt(random).itemPrefab.gameObject, posR, Quaternion.identity);
            yield return new WaitForSeconds(LevelManager.Instance.CurrentLevel.spawnRate);
        }
    }
}
