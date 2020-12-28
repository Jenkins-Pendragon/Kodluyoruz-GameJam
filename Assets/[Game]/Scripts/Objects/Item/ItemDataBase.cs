using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ItemDataBase : Singleton<ItemDataBase>
{
    public List<Item> itemDataBase;
    public Dictionary<string, Item> activeItems = new Dictionary<string, Item>();
}
