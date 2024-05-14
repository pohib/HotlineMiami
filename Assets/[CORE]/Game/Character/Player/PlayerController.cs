using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PLAYER;

public class PlayerController : ICharacter
{
    private IModel model;
    private IView view;

    public IView View { get => view; }

    public PlayerController(IView _view)
    {
        model = new PlayerModel();
        view = _view;
    }

    public void Tick()
    {
        view.Move(model.moveDirection(view.components.speed));
        model.RotatePlayer(view.components.my_Root);
    }

    public void Init(GameManager _gameManager)
    {

    }
}

