using UnityEngine;
using UnityEngine.UI;

public class GradientText : MonoBehaviour
{
    public Color topColor;
    public Color bottomColor;

    void Start()
    {
        Text text = GetComponent<Text>();
        if (text != null)
        {
            Gradient gradient = new Gradient();
            gradient.SetKeys(
                new GradientColorKey[] { new GradientColorKey(topColor, 0.0f), new GradientColorKey(bottomColor, 1.0f) },
                new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(1.0f, 1.0f) }
            );

            text.material = new Material(Shader.Find("GUI/Text Shader"));
            text.material.SetColor("_Color", topColor);

            text.material.SetColor("_TopColor", topColor);
            text.material.SetColor("_BottomColor", bottomColor);
        }
    }

    public void SetGradientColors(Color top, Color bottom)
    {
        topColor = top;
        bottomColor = bottom;
        Text text = GetComponent<Text>();
        if (text != null)
        {
            text.material.SetColor("_TopColor", topColor);
            text.material.SetColor("_BottomColor", bottomColor);
        }
    }
}