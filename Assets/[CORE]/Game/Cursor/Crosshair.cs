using UnityEngine;

public class CursorController : MonoBehaviour
{
    public Texture2D cursorTexture;
    public Vector2 hotSpot = Vector2.zero;
    [Range(0.005f, 0.05f)]
    public float relativeCursorSize = 0.05f;

    void Start()
    {
        Cursor.SetCursor(cursorTexture, hotSpot, CursorMode.ForceSoftware);
    }

    void Update()
    {
        float screenSize = Mathf.Max(Screen.width, Screen.height);
        float newSize = screenSize * relativeCursorSize;

        Texture2D newTexture = new Texture2D((int)newSize, (int)newSize);
        for (int y = 0; y < newTexture.height; y++)
        {
            for (int x = 0; x < newTexture.width; x++)
            {   
                newTexture.SetPixel(x, y, cursorTexture.GetPixelBilinear((float)x / newTexture.width, (float)y / newTexture.height));
            }
        }
        newTexture.Apply();

        Cursor.SetCursor(newTexture, hotSpot, CursorMode.ForceSoftware);
    }
}