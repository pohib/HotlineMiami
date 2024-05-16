using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackController : CharacterAttack, ITick
{
    private PLAYER.Components components;
    private InventoryAndEquipment equipment;

    public PlayerAttackController(PLAYER.Components components, InventoryAndEquipment equipment)
    {
        this.components = components;
        this.equipment = equipment;
    }

    public override void SetAttack()
    {
        Debug.Log("Is Attack");
        RaycastHit hit;
        ItemConfig item = GameInstanceContainer.instance.itemsListConfig.GetItem(equipment.currentWeapon);
        
        Debug.DrawRay(components.my_Root.position, components.my_transform.TransformDirection(components.my_Root.forward) * item.DistanceToAttack, Color.yellow);

        if (Physics.Raycast(components.my_Root.position, components.my_transform.TransformDirection(components.my_Root.forward), out hit, item.DistanceToAttack))
        {

            if (hit.transform.TryGetComponent(out CharacterStats stats))
            {
                stats.GetHit();
            }
        }
    }

    public void Tick()
    {
        if(Input.GetMouseButton(0))
        {
            SetAttack();
        }
    }
}
