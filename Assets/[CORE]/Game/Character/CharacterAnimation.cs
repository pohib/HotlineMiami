using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CharacterAnimation : MonoBehaviour
{
    internal Animator anim;
    public int wID = 0;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void WeaponAnimation(ItemType wp)
    {
        wID = (int)wp;
        anim.SetInteger("wps", wID);
    }
}
