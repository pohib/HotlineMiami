using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PLAYER;

public class PlayerController : ICharacter
{
    private IModel model;
    private IView view;

    public InventoryAndEquipment InventoryAndEquipment { get ; set; }

    public PlayerController(IView _view)
    {
        model = new PlayerModel();
        view = _view;
        InventoryAndEquipment = new(ItemType.Null);
        view.Init(InventoryAndEquipment);
    }

    public void Tick()
    {
        view.Move(model.moveDirection(view.components.speed));
        model.RotatePlayer(view.components.my_Root);
        InventoryAndEquipment.Tick();
    }

    public void Init(GameManager _gameManager)
    {

    }
}

