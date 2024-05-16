using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    [SerializeField] private int hitPoints;

    public Action deadAction;

    private bool isDead;

    public bool IsDead { get => isDead; }

    public void GetHit()
    {
        if(isDead) return;

        Debug.Log($"{gameObject.name} is get hit");

        hitPoints -= 1;

        if( hitPoints <= 0 )
        {
            hitPoints = 0;
            isDead = true;
            deadAction?.Invoke();
        }
    }
}
