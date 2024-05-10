using UnityEngine;

public class GradientBackground : MonoBehaviour
{
    public Color[] colors;
    public float duration = 2.0f;

    void Update()
    {
        float t = Mathf.PingPong(Time.time, duration) / duration;
        int colorIndex = Mathf.FloorToInt(t * (colors.Length - 1));
        float tBlend = (t * (colors.Length - 1)) - colorIndex;
        Camera.main.backgroundColor = Color.Lerp(colors[colorIndex], colors[colorIndex + 1], tBlend);
    }
}