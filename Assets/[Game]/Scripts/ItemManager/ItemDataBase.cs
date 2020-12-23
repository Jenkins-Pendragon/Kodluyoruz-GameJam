using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ItemDataBase : Singleton<ItemDataBase>
{
    public List<Item> myToys;
    // Bütün Toylarımız Burda    
    // Sadece Random Parametre Kadar Toy Getiriyor
    public Dictionary<string, Item> CreateLevelToys(int count = 10)
    {
        Dictionary<string, Item> myToyDic = new Dictionary<string, Item>();
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
    public Dictionary<string, Item> GenerateOrder(int orderObjectCount, Dictionary<string, Item> myCurrentPool)
    {
        Dictionary<string, Item> myToyDic = new Dictionary<string, Item>();
        for (int i = 0; i < orderObjectCount; i++)
        {
            int j = Random.Range(0, myCurrentPool.Count);            
            
            if (!myToyDic.ContainsKey(myCurrentPool.Keys.ElementAt(j)))
            {
                myToyDic.Add(myCurrentPool.Keys.ElementAt(j), myCurrentPool.Values.ElementAt(j));
            }
            else
            {
                i--;
            }
        }
        return myToyDic;
    }

    
}
