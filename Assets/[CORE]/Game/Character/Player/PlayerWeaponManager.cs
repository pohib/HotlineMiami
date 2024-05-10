using PLAYER;
using System.Collections;
using System.Reflection;
using UnityEngine;

public class PlayerWeaponManager : MonoBehaviour
{
    public WeaponType currentWeapon;
    public bool shoot;
    public Transform bulletSpawn;

    private PlayerAnimationController animationController;

    [SerializeField] private Item triggeredItem = null;

    void Start()
    {
        animationController = PlayerView.instance.Components.animationController;
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if(triggeredItem != null)
            {
                SceneItemsContainer.instance.RemoveWeaponFromScene(triggeredItem);
                SwitchOrDropWeapon(triggeredItem.wtype);
            }
            else
                SwitchOrDropWeapon(currentWeapon);
        }
      
        AttackManager(animationController.wID);
    }
    
    public void SwitchOrDropWeapon(WeaponType weapon)
    {
        if (triggeredItem == null)
        {
            if (currentWeapon == WeaponType.Null)
            {
                Debug.Log("orujie net");
                return;
            }

            SceneItemsContainer.instance.SetWeaponOnScene(currentWeapon, transform.position);
            currentWeapon = WeaponType.Null;
            ResetTrigger();
        }
        else
        {
            SceneItemsContainer.instance.SetWeaponOnScene(currentWeapon, transform.position);
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

    void AttackManager(int id)
    {
        if (Input.GetMouseButtonDown(0))
        {
            switch (id)
            {
                case 1:
                    if (shoot)
                    {
                        StartCoroutine("shooting", 0.5f);
                    }
                    break;
                case 2:
                    if (shoot)
                    {
                        StartCoroutine("shooting", 0.2f);
                    }
                    break;
                case 3:
                    if (shoot)
                    {
                        StartCoroutine("shooting", 1f);
                    }
                    break;
                default:                    
                    break;
            }
        }
    }
    IEnumerator shooting(float r)
    {
        Instantiate(Resources.Load($"Prefabs/Items/{currentWeapon}B   ullet"), bulletSpawn.position, bulletSpawn.rotation);
        shoot = false;

        yield return new WaitForSeconds(r);
        shoot = true;
    }
    public void HandTrigger()
    {
        StartCoroutine("waitHand", 0.2f);
    }
    IEnumerator waitHand(float r)
    {
        bulletSpawn.GetComponent<BoxCollider2D>().enabled = true;
        yield return new WaitForSeconds(r);
        bulletSpawn.GetComponent<BoxCollider2D>().enabled = false;
    }
}
