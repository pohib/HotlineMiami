using AI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AIConfig", menuName = "GAME/AI/Create Enemy")]
public class AIConfig : CharacterConfig
{
    public AIType type;
    public bool isPatrol;
    public float runSpeed;
    public float defaultStopDistance;
}
