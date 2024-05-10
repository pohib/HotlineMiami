using System.Collections;
using System.Reflection;
using UnityEngine;

public class PlayerWeaponManager : MonoBehaviour
{
    public string currentWeaponTp;
    public bool isTrigger = false, shoot;
    public Transform bulletSpawn;

    void Start()
    {

    }


    void Update()
    {
        WeaponManager();      
        AttackManager(GetComponent<PlayerAnimationController>().wID);
    }

    public void dropWeapon(string wps)
    {
        if (currentWeaponTp != "Null")
        {
            Instantiate(Resources.Load($"Prefabs/Items/{wps}"), transform.position, Quaternion.identity);
            if (!isTrigger)
            {
                currentWeaponTp = "Null";
                
            }   
        }
        else
        {
            Debug.Log("orujie net");
        }
        return;
    }
    void WeaponManager()
    {
        if (Input.GetMouseButtonDown(1) && !isTrigger)
        {
            dropWeapon(currentWeaponTp);
        }
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
        Instantiate(Resources.Load($"Prefabs/Items/{currentWeaponTp}B   ullet"), bulletSpawn.position, bulletSpawn.rotation);
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
