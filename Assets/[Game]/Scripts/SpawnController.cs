using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SpawnController : MonoBehaviour
{

    public Transform spawnLeft;
    public Transform spawnRight;
    public Transform spawnRotation;
    private Dictionary<string, Item> levelItemsClone;
    private bool canSpawn = true;

    private void OnEnable()
    {
        EventManager.OnLevelFinished.AddListener(() => canSpawn = false);
    }
    private void OnDisable()
    {
        EventManager.OnLevelFinished.RemoveListener(() => canSpawn = false);
    }
    private void Awake()
    {
        OrderManager.Instance.SetLevelItems();
        Spawn();
    }
    private void Spawn()
    {
        ResetClone();
        StopAllCoroutines();
        StartCoroutine(SpawnCo());
    }  

    private void ResetClone() 
    {
        levelItemsClone = new Dictionary<string, Item>(OrderManager.Instance.levelItems);
    }
    IEnumerator SpawnCo()
    {
        while (canSpawn)
        {           
            Vector3 randomPos = new Vector3(Random.Range(spawnLeft.position.x, spawnRight.position.x),
                spawnLeft.position.y + Random.Range(0.5f,1f),
                Random.Range(spawnLeft.position.z, spawnRight.position.z));

            int random = Random.Range(0, levelItemsClone.Count);
            Instantiate(levelItemsClone.Values.ElementAt(random).itemPrefab.gameObject, randomPos, spawnRotation.rotation);

            
            levelItemsClone.Remove(levelItemsClone.Keys.ElementAt(random));
            if (levelItemsClone.Count == 0) ResetClone();

            yield return new WaitForSeconds(LevelManager.Instance.CurrentLevel.spawnDelay);
        }
    }
}
