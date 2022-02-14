using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public static class SceneViewFocuser
{
    static SceneViewFocuser() => UnityToolbarExtender.ToolbarExtender.RightToolbarGUI.Add(OnToolbarGUI);

    static void OnToolbarGUI()
    {
        var tex = EditorGUIUtility.IconContent(@"UnityEditor.SceneView").image;
        GUILayout.Toggle(false, new GUIContent(null, tex, "Open Tile Palette"), "Command");
        if (GUI.changed) EditorApplication.ExecuteMenuItem("Window/2D/Tile Palette");
    }
}


