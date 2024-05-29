using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameContainer gameContainer;
    [SerializeField] private TMPro.TextMeshProUGUI deathText;
    [SerializeField] private TMPro.TextMeshProUGUI WinText;
    private PlayerController playerController;
    private GameAIController aIController;
    private bool isGameOver = false;

    private void Start()
    {
        aIController = new GameAIController(gameContainer, this);
        aIController.Init();
        playerController = new PlayerController(gameContainer.GetPlayerView);
        playerController.Init(this);
    }

    private void Update()
    {
        if (isGameOver && Input.GetKeyDown(KeyCode.R))
        {
            RestartLevel();
            isGameOver = false;
        }
        else
        {
            playerController.Tick();
            aIController.Tick();
        }
    }

    public void Lose()
    {
        
       Debug.Log("Lose!");
        isGameOver = true;
        deathText.text = "¬€ œ–Œ»√–¿À»... \nR ƒÀﬂ œ≈–≈«¿œ”— ¿";
    }

    public void Win()
    {

        Debug.Log("Win!");
        WinText.text = "»ƒ»   Ã¿ÿ»Õ≈...";
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
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
