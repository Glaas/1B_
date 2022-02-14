using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class InitLoader
{
    public static string sceneName;

    [MenuItem("Load Scenes/Load setup scenes only")]
    static void LoadAll()
    {
        LoadInit();
        LoadUI();
        LoadMusic();
    }
    static void LoadInit()
    {
        sceneName = "Init";
        EditorSceneManager.OpenScene("Assets/Scenes/" + sceneName + ".unity", OpenSceneMode.Additive);
    }
    static void LoadUI()
    {
        sceneName = "UIScene";
        EditorSceneManager.OpenScene("Assets/Scenes/" + sceneName + ".unity", OpenSceneMode.Additive);
    }
    static void LoadMusic()
    {
        sceneName = "MusicScene";
        EditorSceneManager.OpenScene("Assets/Scenes/" + sceneName + ".unity", OpenSceneMode.Additive);
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
    [MenuItem("Load Scenes/Game scenes/ Load Level 3")]
    static void LoadLevel3()
    {
        sceneName = "Level3";
        LoadMyScene(sceneName);
    }
    [MenuItem("Load Scenes/Game scenes/ Load Level 4")]
    static void LoadLevel4()
    {
        sceneName = "Level4";
        LoadMyScene(sceneName);
    }
    [MenuItem("Load Scenes/Game scenes/ Load Level 5")]
    static void LoadLevel5()
    {
        sceneName = "Level5";
        LoadMyScene(sceneName);
    }
    [MenuItem("Load Scenes/Game scenes/ Load Level 6")]
    static void LoadLevel6()
    {
        sceneName = "Level6";
        LoadMyScene(sceneName);
    }
    [MenuItem("Load Scenes/Game scenes/ Load Level 7")]
    static void LoadLevel7()
    {
        sceneName = "Level7";
        LoadMyScene(sceneName);
    }
    [MenuItem("Load Scenes/Open SceneLoader editor")]
    static void OpenInitLoaderScript()
    {
        UnityEditorInternal.InternalEditorUtility.OpenFileAtLineExternal("Assets/Scripts/Editor/InitLoader.cs", 1);
    }
    public static void LoadMyScene(string sceneName)
    {
        if (!EditorSceneManager.GetSceneByName(sceneName).isLoaded)
            EditorSceneManager.OpenScene("Assets/Scenes/GameLevels/" + sceneName + ".unity", OpenSceneMode.Single);
        LoadAll();
        if (!EditorSceneManager.GetSceneByName("Init").isLoaded || !EditorSceneManager.GetSceneByName("UIScene").isLoaded || !EditorSceneManager.GetSceneByName("MusicScene").isLoaded)
            Debug.LogError("Some of the mandatory scenes are not loaded. Make sure you have loaded all the mandatory scenes.");
    }
    public static void UnloadAllScenes()
    {
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            Scene scene = SceneManager.GetSceneAt(i);
            if (scene.name != "Init" && scene.name != "UIScene" && scene.name != "MusicScene")
                EditorSceneManager.CloseScene(scene, true);
        }
    }

}