using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PLAYER;
using AI;

public class GameContainer : MonoBehaviour
{
    [SerializeField] private PlayerView playerView;
    [SerializeField] private AIView[] aIViewsEnemy;

    public PlayerView GetPlayerView
    {
        get { return playerView; }
    }

    public AIView[] AIViewsEnemy
    {
        get { return aIViewsEnemy; }
    }
}
