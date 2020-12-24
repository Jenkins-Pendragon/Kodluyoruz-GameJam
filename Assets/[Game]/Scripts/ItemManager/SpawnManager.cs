using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SpawnManager : Singleton<SpawnManager>
{
    
    Vector3 pos = new Vector3(-1.589f, 0f, -1.472f);
    
   private void SpawnToy()
    {
        for (int i = 0; i < ItemLevelManager.Instance.activePool.Count; i++)
        {
            Instantiate(ItemLevelManager.Instance.activePool.Values.ElementAt(i).itemPrefab.gameObject, pos, Quaternion.identity);
        }
    }

    private void Start()
    {
            StartCoroutine(SpawnCo());
    }

    IEnumerator SpawnCo()
    {
        while (true)
        {
            Vector3 posR = new Vector3(Random.Range(-2.1f, -0.8f), 0f, -1.472f);
            int random = Random.Range(0, ItemLevelManager.Instance.activePool.Count);
            Instantiate(ItemLevelManager.Instance.activePool.Values.ElementAt(random).itemPrefab.gameObject, posR, Quaternion.identity);
            yield return new WaitForSeconds(2);
        }
    }
}
