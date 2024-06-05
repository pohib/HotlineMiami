using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class Interaction : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI WinTxt;
    [SerializeField] private TMPro.TextMeshProUGUI PressedKeyTxt;
    private GameManager gameManager;


    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        if (gameManager == null)
        {
            Debug.LogError("GameManager reference is not set!");
        }
        WinTxt.enabled = false;
    }

    private void OnTriggerEnter(Collider car)
    {
        if (car.CompareTag("Player"))
        {
            Debug.Log("vrode vivodit");
            WinTxt.text = "[F ДЛЯ ВЗАИМОДЕЙСТВИЯ]";
            WinTxt.enabled = true;
        }
    }

    private void OnTriggerExit(Collider car)
    {
        if (car.CompareTag("Player"))
        {
            WinTxt.enabled = false;
        }
    }

    private void Update()
    {
        if (gameManager != null && Input.GetKeyDown(KeyCode.F))
        {
            HandleFKeyInput();
        }
    }

    private void HandleFKeyInput()
    {
        if (gameManager.IsAllEnemiesDead())
        {
            PressedKeyTxt.text = "ПОБЕДА";
            gameManager.WinText.text = "";
            WinTxt.enabled = false;
        }
        else
        {
            WinTxt.text = "ТЫ ЕЩЕ НЕ ЗАКОНЧИЛ!";
        }
    }
}
