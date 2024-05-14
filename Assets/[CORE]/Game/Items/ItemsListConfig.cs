using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemsListConfig", menuName = "GAME/Items/ItemsListConfig")]
public class ItemsListConfig : ScriptableObject
{
    public List<ItemConfig> list = new();

    public ItemConfig GetItem(ItemType type)
    {
        return list.Find(x=>x.Type == type);
    }
}
