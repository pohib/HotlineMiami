using System.Collections;
using UnityEngine;
using TMPro;

public class TextEffect1 : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI WinText;
    public float fadeInSp = 0.5f;

    private void Start()
    {
        StartCoroutine(FadeInTex1t());
    }

    private IEnumerator FadeInTex1t()
    {
        WinText.alpha = 0f;
        while (WinText.alpha < 1f)
        {
            WinText.alpha += fadeInSp * Time.deltaTime;
            yield return null;
        }
    }
}