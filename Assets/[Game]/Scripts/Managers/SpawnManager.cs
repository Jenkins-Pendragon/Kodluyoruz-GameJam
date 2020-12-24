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
    Vector3 pos = new Vector3(-1.589f, 0f, -1.472f);
    
   private void SpawnToy()
    {
        for (int i = 0; i < LevelManager.Instance.levelItems.Count; i++)
        {
            Instantiate(LevelManager.Instance.levelItems.Values.ElementAt(i).itemPrefab.gameObject, pos, Quaternion.identity);
        }
    }

    private void Start()
    {
        int limit = LevelManager.Instance.CurrentLevel.levelItemSize;
        StartCoroutine(SpawnCo(limit));
    }
    
    IEnumerator SpawnCo(int limit)
    {
        int count = 0;
        while (count < limit)
        {
            count++;
            Vector3 posR = new Vector3(Random.Range(SpawnLeft.position.x, SpawnRight.position.x), -0.87f, -1.472f);
            int random = Random.Range(0, LevelManager.Instance.levelItems.Count);
            Instantiate(LevelManager.Instance.levelItems.Values.ElementAt(random).itemPrefab.gameObject, posR, Quaternion.identity);
            yield return new WaitForSeconds(LevelManager.Instance.CurrentLevel.spawnRate);
        }
    }
}
