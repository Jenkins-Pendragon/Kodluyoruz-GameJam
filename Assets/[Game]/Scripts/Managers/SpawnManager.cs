using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SpawnManager : MonoBehaviour
{

    public Transform spawnLeft;
    public Transform spawnRight;
    public Transform spawnRotation;

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
            Vector3 randomPos = new Vector3(Random.Range(spawnLeft.position.x, spawnRight.position.x),
                spawnLeft.position.y + Random.Range(0.5f,1f),
                Random.Range(spawnLeft.position.z, spawnRight.position.z));

            int random = Random.Range(0, OrderManager.Instance.levelItems.Count);
            Instantiate(OrderManager.Instance.levelItems.Values.ElementAt(random).itemPrefab.gameObject, randomPos, spawnRotation.rotation);
            yield return new WaitForSeconds(LevelManager.Instance.CurrentLevel.spawnDelay);
        }
    }
}
