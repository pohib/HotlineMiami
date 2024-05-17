using PLAYER;
using UnityEngine;

public class InventoryAndEquipment : ITick
{
    public ItemType currentWeapon;

    private PlayerAnimationController animationController;

    private Item triggeredItem = null;

    public InventoryAndEquipment(ItemType weaponToStart, PlayerAnimationController animationController)
    {
        this.animationController = animationController;
        currentWeapon = weaponToStart;
    }
    
    public void SwitchOrDropWeapon(ItemType weapon)
    {
        if (triggeredItem == null)
        {
            if (currentWeapon == ItemType.Null)
            {
                Debug.Log("orujie net");
                return;
            }

            SceneItemsContainer.instance.SetWeaponOnScene(currentWeapon, animationController.transform.position);
            currentWeapon = ItemType.Null;
            ResetTrigger();
        }
        else
        {
            SceneItemsContainer.instance.SetWeaponOnScene(currentWeapon, animationController.transform.position);
            currentWeapon = weapon;
            ResetTrigger();
        }

        animationController.WeaponAnimation(currentWeapon);
    }

    public void SetTriggeredItem(Item item)
    {
        if (item == null) return;

        triggeredItem = item;
    }

    public void ResetTrigger()
    {
        triggeredItem = null;
    }

    public void Tick()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (triggeredItem != null)
            {
                SceneItemsContainer.instance.RemoveWeaponFromScene(triggeredItem);
                SwitchOrDropWeapon(triggeredItem.wtype);
            }
            else
                SwitchOrDropWeapon(currentWeapon);
        }
    }
}
