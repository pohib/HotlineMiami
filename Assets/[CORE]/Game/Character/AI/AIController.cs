using System;
using UnityEngine;
using AI;

public class AIController : IBot
{
    private IModel model;
    private IView view;
    private GameManager gameManager;
    private PLAYER.PlayerView player;

    public AIAttackController characterAttack {  get; private set; }

    public AIController(IView view, PLAYER.PlayerView player)
    {
        this.view = view;
        this.player = player;
        model = new AIModel(view.components.my_transform, player.transform);
    }

    public void Init(GameManager _gameManager)
    {
        gameManager = _gameManager;

        characterAttack = new(view.components);

        switch (view.components.config.type)
        {
            case AIType.Enemy:
                
                view.lowDistanceAction += ()=> characterAttack.SetAttack();
                view.components.characterStats.deadAction += () => 
                {
                    view.components.agent.ResetPath();
                    view.components.my_transform.gameObject.SetActive(false);
                    /* dead animation etc.*/
                };
                break;
        }
        
    }

    public void Tick()
    {
        if(view.components.characterStats.IsDead) return;

        view.Move(model.moveDirection(view.components));

        if(model.CheckDistanceToTarget(view.components))
        {
            view.LookToTarget(player.transform);
            view.lowDistanceAction?.Invoke();
        }
    }
}
