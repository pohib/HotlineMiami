using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : Item
{
    PlayerWeaponManager pwm;
    void Start()
    {
        pwm = FindObjectOfType<PlayerWeaponManager>();
    }


    void Update()
    {

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            collision.GetComponent<PlayerWeaponManager>().isTrigger = true;
            if (Input.GetMouseButtonDown(1))
            {
                StartCoroutine("wait");
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            collision.GetComponent<PlayerWeaponManager>().isTrigger = false;
        }
    }
    IEnumerator wait()
    {
        if (pwm.currentWeaponTp != "Null")
        {
            pwm.dropWeapon(pwm.currentWeaponTp);
        }
        yield return new WaitForSeconds(0.05f);
        pwm.currentWeaponTp = item.wtype.ToString();
        Destroy(gameObject);
    }
}
