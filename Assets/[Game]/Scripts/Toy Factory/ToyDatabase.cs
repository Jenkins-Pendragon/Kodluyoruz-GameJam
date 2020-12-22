using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class ToyDatabase : MonoBehaviour
{
    // Bütün Toylarımız Burda
    public List<Toy> myToys;
    // Sadece Random Parametre Kadar Toy Getiriyor
    public Dictionary<int, Toy> CreateLevelToys(int count = 10)
    {
        Dictionary<int, Toy> myToyDic = new Dictionary<int, Toy>();
        for (int i = 0; i < count; i++)
        {
            int randomNumber = Random.Range(0, myToys.Count);
            if (!myToyDic.ContainsKey(myToys[randomNumber].itemID))
            {
                myToyDic.Add(myToys[randomNumber].itemID, myToys[randomNumber]);
            }
            else
            {
                i--;
            }
        }
        return myToyDic;
    }
    public Dictionary<int, Toy> GenerateOrder(int orderObjectCount, Dictionary<int, Toy> myCurrentPool)
    {
        Dictionary<int, Toy> myToyDic = new Dictionary<int, Toy>();
        for (int i = 0; i < orderObjectCount; i++)
        {
            int j = Random.Range(0, myCurrentPool.Count);
            myToyDic.Add(myCurrentPool[i].itemID, myCurrentPool[j]);
        }
        return myToyDic;
    }
}
[System.Serializable]
public class Toy
{
    public Sprite toyIcon;
    public int itemID;
    public GameObject itemPrefab;
}

