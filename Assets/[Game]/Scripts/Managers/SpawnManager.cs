using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SpawnManager : MonoBehaviour
{

    public Transform SpawnLeft;
    public Transform SpawnRight;

    private void OnEnable()
    {
        EventManager.OnLevelStarted.AddListener(Spawn);
    }

    private void OnDisable()
    {
        EventManager.OnLevelStarted.RemoveListener(Spawn);
    }

    private void Spawn()
    {
        StopAllCoroutines();
        StartCoroutine(SpawnCo());
    }  
    IEnumerator SpawnCo()
    {
        while (true)
        {           
            Vector3 randomPos = new Vector3(Random.Range(SpawnLeft.position.x, SpawnRight.position.x),
                SpawnLeft.position.y + Random.Range(0.5f,1.5f),
                Random.Range(SpawnLeft.position.z, SpawnRight.position.z));

            int random = Random.Range(0, LevelManager.Instance.levelItems.Count);
            Instantiate(LevelManager.Instance.levelItems.Values.ElementAt(random).itemPrefab.gameObject, randomPos, Quaternion.identity);
            yield return new WaitForSeconds(LevelManager.Instance.CurrentLevel.spawnRate);
        }
    }
}
