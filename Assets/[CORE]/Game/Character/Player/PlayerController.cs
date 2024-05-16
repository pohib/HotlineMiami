using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PLAYER;

public class PlayerController : ICharacter
{
    private IModel model;
    private IView view;

    private GameManager gameManager;

    public InventoryAndEquipment InventoryAndEquipment { get ; set; }
    private PlayerAttackController characterAttack;

    public PlayerController(IView _view)
    {
        model = new PlayerModel();
        view = _view;
        InventoryAndEquipment = new(view.components.config.currentWeapon);
        view.Init(InventoryAndEquipment);
        view.components.animationController.WeaponAnimation(InventoryAndEquipment.currentWeapon);
    }

    public void Tick()
    {
        if(view.components.characterStats.IsDead) return;

        view.Move(model.moveDirection(view.components.config.walkSpeed));
        model.RotatePlayer(view.components.my_Root);
        InventoryAndEquipment.Tick();
        characterAttack.Tick();
    }

    public void Init(GameManager _gameManager)
    {
        gameManager = _gameManager;
        view.components.characterStats.deadAction += () => { gameManager.Lose(); };
        characterAttack = new(view.components, InventoryAndEquipment);
    }
}

