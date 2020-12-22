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
            myToyDic.Add(myToys[randomNumber].itemID, myToys[randomNumber]);
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

