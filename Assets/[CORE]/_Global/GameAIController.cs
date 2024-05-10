using System;
using System.Collections.Generic;
using UnityEngine;

public class GameAIController : IGameController
{
    private readonly GameContainer gameContainer;
    private readonly GameManager gameManager;

    private List<IBot> ai_enemy = new List<IBot>();

    public GameAIController(GameContainer gameContainer, GameManager gameManager)
    {
        this.gameContainer = gameContainer;
        this.gameManager = gameManager;
    }

    public void Init()
    {
        for (int i = 0; i < gameContainer.AIViewsEnemy.Length; i++)
        {
            var mob = new AIController(gameContainer.AIViewsEnemy[i], gameContainer.GetPlayerView);
            mob.Init(gameManager);
            ai_enemy.Add(mob);
        }
    }

    public void Tick()
    {
        foreach (var mob in ai_enemy)
        {
            mob.Tick();
        }
    }
}
