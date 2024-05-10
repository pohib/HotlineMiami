using System.Collections;
using System.Reflection;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    
    Animator anim;
    PlayerWeaponManager pwm;
    public int wID = 0;
    bool shoot;
    void Start()
    {
        anim = GetComponent<Animator>();
        pwm = GetComponent<PlayerWeaponManager>();
    }


    void Update()
    {
        WeaponAnimation(pwm.currentWeaponTp);
        anim.SetInteger("wps", wID);
        AttackAnim();
    }
    void AttackAnim()
    {
        shoot = pwm.shoot;
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
    void WeaponAnimation(string wp)
    { 
        switch (wp)
        {
            case "Null":
                wID = 0;              
                break;
            case "Pistol":
                wID = 1;               
                break;
            case "Rifle":
                wID = 2;              
                break;
            case "Shotgun":
                wID = 3;              
                break;
            case "Bat":
                wID = 4;                
                break;
            case "BottleFLIPCHE":
                wID = 5;
                break;
            case "HalfLife3":
                wID = 6;
                break;
            default:
                break;
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
