using UnityEngine;
using UnityEditor;
public class RayTracerViewport : EditorWindow
{
    string myString = "Hello World";
    bool groupEnabled;
    bool myBool = true;
    float myFloat = 1.23f;

    static Texture windowImage;

    // Add menu named "My Window" to the Window menu
    [MenuItem("Raytracer/Viewport")]
    static void Init()
    {
        // Get existing open window or if none, make a new one:
        RayTracerViewport window = EditorWindow.GetWindow(typeof(RayTracerViewport)) as RayTracerViewport;
        window.Show();
        windowImage = EditorGUIUtility.whiteTexture;
    }

    void OnGUI()
    {
        GUI.DrawTexture(new Rect(0, 0, 100, 100), windowImage);
    }
}