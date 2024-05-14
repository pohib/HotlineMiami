using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneItemsContainer : Singleton<SceneItemsContainer>
{
    [SerializeField] private List<Item> ItemsInScene;
    
    public void SetWeaponOnScene(ItemType item, Vector3 position)
    {
        if (item == ItemType.Null) return;

        Item weapon = GetFreeWeapon(item, false);

        if (weapon != null)
        {
            weapon.gameObject.SetActive(true);
            weapon.transform.position = position;
        }
    }

    public void RemoveWeaponFromScene(Item item)
    {
        if (item != null)
        {
            item.gameObject.SetActive(false);
        }
    }

    private Item GetFreeWeapon(ItemType item, bool isActive)
    {
        Item weapon = null;
        
        if(item == ItemType.Null)
        {
            return null;
        }

        foreach(Item i in ItemsInScene)
        {
            if (i.wtype != item) continue;

            if(i.gameObject.activeSelf == isActive)
            {
                weapon = i;
            }
        }

        return weapon;
    }

    public void AddToList(Item item)
    {
        ItemsInScene.Add(item);
    }
}
