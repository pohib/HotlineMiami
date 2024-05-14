using AI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AIConfig", menuName = "GAME/AI/Create Enemy")]
public class AIConfig : ScriptableObject
{
    public AIType type;
    public ItemType currentWeapon;
    public bool isPatrol;
    public float walkSpeed;
    public float runSpeed;
    public float defaultStopDistance;
}
