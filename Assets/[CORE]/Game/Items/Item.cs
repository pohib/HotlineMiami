using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Item : MonoBehaviour
{ 
    public WeaponType wtype;
    public float distanceToAttack;

    private void Start()
    {
        SceneItemsContainer.instance.AddToList(this);
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out PlayerWeaponManager player))
        {
            player.SetTriggeredItem(this);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out PlayerWeaponManager player))
        {
            player.ResetTrigger();
        }
    }
}

public enum WeaponType
{
    Null = 0,
    Pistol = 1,
    Shotgun = 2,
    Rifle = 3,
    Bat = 4,
    HalfLife3 = 5,
    BottleFLIPCHE = 6
}
