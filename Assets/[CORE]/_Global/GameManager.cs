using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameContainer gameContainer;
    [SerializeField] private GameUIContainer uIContainer;

    private PlayerController playerController;
    private GameAIController aIController;

    private void Start()
    {
        /*uiManager = new GameUIManager(uIContainer);
        uiManager.Init();*/
        aIController = new GameAIController(gameContainer, this);
        aIController.Init();
        playerController = new PlayerController(gameContainer.GetPlayerView);
    }

    private void Update()
    {
        playerController.Tick();
        //uiManager.Tick();
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


}
