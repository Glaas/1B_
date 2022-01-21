using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

public class InitLoader
{
    public static string sceneName;

    [MenuItem("Load Scenes/Load all")]
    static void LoadAll()
    {
        LoadInit();
        LoadUI();
        LoadMusic();
    }
    [MenuItem("Load Scenes/Load Init")]
    static void LoadInit()
    {
        sceneName = "Init";
        LoadMyScene(sceneName);
    }
    [MenuItem("Load Scenes/Load UI")]
    static void LoadUI()
    {
        sceneName = "UIScene";
        LoadMyScene(sceneName);
    }
    [MenuItem("Load Scenes/Load Music")]
    static void LoadMusic()
    {
        sceneName = "MusicScene";
        LoadMyScene(sceneName);
    }

    [MenuItem("Load Scenes/Game scenes/ Load Level 1")]
    static void LoadLevel1()
    {
        sceneName = "Level1";
        LoadMyScene(sceneName);
    }
    [MenuItem("Load Scenes/Game scenes/ Load Level 2")]
    static void LoadLevel2()
    {
        sceneName = "Level2";
        LoadMyScene(sceneName);
    }
    public static void LoadMyScene(string sceneName)
    {
        if (!EditorSceneManager.GetSceneByName(sceneName).isLoaded)
            EditorSceneManager.OpenScene("Assets/Scenes/" + sceneName + ".unity", OpenSceneMode.Additive);
    }

}