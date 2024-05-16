using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterConfig", menuName = "GAME/Character/Create character")]
public class CharacterConfig : ScriptableObject
{
    public ItemType currentWeapon;
    public float walkSpeed;
}
