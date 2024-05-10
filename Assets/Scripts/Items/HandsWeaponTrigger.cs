using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandsWeaponTrigger : MonoBehaviour
{
    public float Dmg;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<EnemyOptions>())
        {
            Debug.Log("хуйнул врата");
        }

        if (collision.tag == "other")
        {
            Debug.Log("куда ты ху€ришь епт");
        }
    }
}
