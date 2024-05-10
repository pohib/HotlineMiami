using System;
using UnityEngine;
using AI;

public class AIController : IBot
{
    private IModel model;
    private IView view;
    private GameManager gameManager;
    private PLAYER.PlayerView player;

    public AIController(IView view, PLAYER.PlayerView player)
    {
        this.view = view;
        this.player = player;
        model = new AIModel(view.components.my_transform, player.transform);
    }

    public void Init(GameManager _gameManager)
    {
        gameManager = _gameManager;

        switch (view.components.type)
        {
            case AIType.Enemy:
                
                view.lowDistanceAction += ()=> Debug.Log("Enemy is Attack"); //gameManager.Lose;
                break;
        }
        
    }

    public void Tick()
    {
        view.Move(model.moveDirection(view.components));

        if(model.CheckDistanceToTarget(view.components))
        {
            view.LookToTarget(player.transform);
            view.lowDistanceAction?.Invoke();
        }
    }
}
