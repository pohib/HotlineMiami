using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameContainer gameContainer;

    private PlayerController playerController;
    private GameAIController aIController;

    private void Start()
    {
        aIController = new GameAIController(gameContainer, this);
        aIController.Init();
        playerController = new PlayerController(gameContainer.GetPlayerView);
        playerController.Init(this);
    }

    private void Update()
    {
        playerController.Tick();
        aIController.Tick();
    }

    public void Lose()
    {
        SceneManager.LoadScene(0);
        Debug.Log("Lose!");
    }

    public void Win()
    {
        SceneManager.LoadScene(0);
        Debug.Log("Win!");
    }

    public bool IsAllEnemiesDead()
    {
        foreach (var item in gameContainer.AIViewsEnemy)
        {
            if(!item.Components.characterStats.IsDead)
                return false;
        }

        return true;
    }
}
