using System.Collections;
using UnityEngine;
using TMPro;

public class TextEffect : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI deathText;
    private bool isFading = false;
    public float fadeInSpeed = 0.5f;

    private void Start()
    {
        StartCoroutine(FadeInText());
    }

    private IEnumerator FadeInText()
    {
        deathText.alpha = 0f;
        while (deathText.alpha < 1f)
        {
            deathText.alpha += fadeInSpeed * Time.deltaTime;
            yield return null;
        }

        yield return new WaitForSeconds(1f);

        while (true)
        {
            deathText.alpha = 0f;
            yield return new WaitForSeconds(0.8f);
            deathText.alpha = 1f;
            yield return new WaitForSeconds(0.8f);
        }
    }
}