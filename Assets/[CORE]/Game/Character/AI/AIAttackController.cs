using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAttackController : CharacterAttack
{
    private AI.Components components;
    public AIAttackController(AI.Components components)
    {
        this.components = components;
    }

    public override void SetAttack()
    {
        RaycastHit hit;
        ItemConfig item = GameInstanceContainer.instance.itemsListConfig.GetItem(components.config.currentWeapon);

        if (Physics.Raycast(components.my_transform.position, components.my_transform.TransformDirection(Vector3.forward), out hit, item.DistanceToAttack))
        {
            Debug.DrawRay(components.my_transform.position, components.my_transform.TransformDirection(Vector3.forward) * item.DistanceToAttack, Color.yellow);

            if (hit.transform.TryGetComponent(out CharacterStats stats))
            {
                stats.GetHit();
            }
        }
    }
}
