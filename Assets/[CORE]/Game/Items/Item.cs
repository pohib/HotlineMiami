using PLAYER;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Item : MonoBehaviour
{ 
    public ItemType wtype;

    public ItemConfig config {  get; private set; }

    private void Start()
    {
        SceneItemsContainer.instance.AddToList(this);
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out PlayerView player))
        {
            player.InventoryAndEquipment.SetTriggeredItem(this);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out PlayerView player))
        {
            player.InventoryAndEquipment.ResetTrigger();
        }
    }
}

public enum ItemType
{
    Null = 0,
    Pistol = 1,
    Shotgun = 2,
    Rifle = 3,
    Bat = 4,
    HalfLife3 = 5,
    BottleFLIPCHE = 6
}
