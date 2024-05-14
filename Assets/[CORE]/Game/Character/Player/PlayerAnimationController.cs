using NUnit.Framework;
using PLAYER;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class PlayerAnimationController : CharacterAnimation
{
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

    IEnumerator shooting(float r)
    {
        anim.SetTrigger("attack");
        shoot = false;

        yield return new WaitForSeconds(r);
        shoot = true;
    }
}
