using UnityEngine;
using UnityEditor;
public class RayTracerViewport : EditorWindow
{
    string myString = "Hello World";
    bool groupEnabled;
    bool myBool = true;
    float myFloat = 1.23f;

    // Add menu named "My Window" to the Window menu
    [MenuItem("Raytracer/Viewport")]
    static void Init()
    {
        // Get existing open window or if none, make a new one:
        RayTracerViewport window = EditorWindow.GetWindow(typeof(RayTracerViewport)) as RayTracerViewport;
        window.Show();
    }

    void OnGUI()
    {
        var cam = Camera.main;
        RenderTexture currentRT = RenderTexture.active;
        RenderTexture.active = cam.targetTexture;
        cam.Render();
        Texture2D image = new Texture2D(cam.targetTexture.width, cam.targetTexture.height);
        image.ReadPixels(new Rect(0, 0, cam.targetTexture.width, cam.targetTexture.height), 0, 0);
        image.Apply();
        RenderTexture.active = currentRT;
        GUI.DrawTexture(new Rect(0, 0, cam.targetTexture.width, cam.targetTexture.width), image);
    }
}