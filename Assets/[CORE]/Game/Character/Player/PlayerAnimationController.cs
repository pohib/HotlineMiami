using NUnit.Framework;
using PLAYER;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    Animator anim;
    InventoryAndEquipment pwm;
    public int wID = 0;
    bool shoot;
    void Start()
    {
        anim = GetComponent<Animator>();
        pwm = PlayerView.instance.Components.weaponManager;
    }


    void Update()
    {
        AttackAnim();
    }
    void AttackAnim()
    {

        if (Input.GetMouseButtonDown(0))
        {
            switch (wID)
            {        
                case 0:
                case 4:
                case 5:
                case 6:
                    anim.SetTrigger("attack");
                    break;
                case 1:
                    if (shoot)
                    {
                        StartCoroutine("shooting", 0.7f);                        
                    }
                    break;
                case 2:
                    if (shoot)
                    {
                        StartCoroutine("shooting", 0.4f);
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

    public void WeaponAnimation(ItemType wp)
    { 
        wID = (int)wp;
        anim.SetInteger("wps", wID);
    }

    IEnumerator shooting(float r)
    {
        anim.SetTrigger("attack");
        shoot = false;

        yield return new WaitForSeconds(r);
        shoot = true;
    }
}
