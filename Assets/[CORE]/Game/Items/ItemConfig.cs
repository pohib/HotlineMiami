using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "item config", menuName = "GAME/Items/Create item")]
public class ItemConfig : ScriptableObject
{
    public ItemType Type;
    public float DistanceToAttack;
    public int maxHit;
    public Sprite icon;
}
