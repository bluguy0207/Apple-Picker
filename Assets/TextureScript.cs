using UnityEngine;

public class TexturePainter : MonoBehaviour
{
    public int textureSize = 512;
    public int brushSize = 20;

    private Texture2D texture;
    private Renderer objectRenderer;

    void Start()
    {
        objectRenderer = GetComponent<Renderer>();

        // Create a new texture
        texture = new Texture2D(textureSize, textureSize);

        // Fill the texture with yellow
        Color[] pixels = new Color[textureSize * textureSize];

        for (int i = 0; i < pixels.Length; i++)
        {
            pixels[i] = Color.yellow;
        }

        texture.SetPixels(pixels);
        texture.Apply();

        // Put the texture on the object's material
        objectRenderer.material.mainTexture = texture;
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Paint();
        }
    }

    void Paint()
    {
        Camera cam = Camera.main;

        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.gameObject == gameObject)
            {
                Vector2 uv = hit.textureCoord;

                int x = (int)(uv.x * textureSize);
                int y = (int)(uv.y * textureSize);

                for (int i = -brushSize; i < brushSize; i++)
                {
                    for (int j = -brushSize; j < brushSize; j++)
                    {
                        int pixelX = x + i;
                        int pixelY = y + j;

                        if (pixelX >= 0 && pixelX < textureSize &&
                            pixelY >= 0 && pixelY < textureSize)
                        {
                            float distance = Mathf.Sqrt(i * i + j * j);

                            if (distance < brushSize)
                            {
                                texture.SetPixel(pixelX, pixelY, Color.black);
                            }
                        }
                    }
                }

                texture.Apply();
            }
        }
    }
}