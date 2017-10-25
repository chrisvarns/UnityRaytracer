using UnityEngine;
using UnityEditor;
public class RayTracerViewport : EditorWindow
{
    static Texture2D texture;

    static Color[] colors;

    // Add menu named "My Window" to the Window menu
    [MenuItem("Raytracer/Viewport")]
    static void Init()
    {
        // Get existing open window or if none, make a new one:
        RayTracerViewport window = EditorWindow.GetWindow(typeof(RayTracerViewport)) as RayTracerViewport;
        window.Show();
        texture = new Texture2D(800, 600);
        colors = new Color[800 * 600];
        for (int y = 0; y < 600; y++)
        {
            for (int x = 0; x < 800; x++)
            {
                colors[(y * 800) + x] = new Color(((float)x % 256) / 256, ((float)y % 256) / 256, 0, 1);
            }
        }
    }

    void OnGUI()
    {
        if (texture == null) Init();
        texture.SetPixels(colors);
        texture.Apply();
        GUI.DrawTexture(new Rect(0, 0, texture.width, texture.height), texture);
    }
}