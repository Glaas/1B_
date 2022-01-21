using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class SceneLoader : MonoBehaviour
{
    public string InitSceneName;
    public string UISceneName;
    public string MusicSceneName;
    public string CurrentLevelName;
    public string[] LevelNames;

    public static SceneLoader instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        LoadMandatoryComponents();
    }

    void LoadMandatoryComponents()
    {
        int countLoaded = SceneManager.sceneCount;
        Scene[] loadedScenes = new Scene[countLoaded];
        for (int i = 0; i < countLoaded; i++) loadedScenes[i] = SceneManager.GetSceneAt(i);

        //Check if UI is loaded
        if (!loadedScenes.Contains(SceneManager.GetSceneByName(UISceneName))) SceneManager.LoadScene(UISceneName, LoadSceneMode.Additive);

        //Check if MusicScene is loaded
        if (!loadedScenes.Contains(SceneManager.GetSceneByName(MusicSceneName))) SceneManager.LoadScene(MusicSceneName, LoadSceneMode.Additive);

        Scene[] GameLevels = new Scene[LevelNames.Length];
        for (int i = 0; i < LevelNames.Length; i++) GameLevels[i] = SceneManager.GetSceneByName(LevelNames[i]);
        //if no game scene is loaded, load the first level additively and set it as current level
        bool isOneGameLevelLoaded = false;
        for (int i = 0; i < GameLevels.Length; i++)
        {
            if (loadedScenes.Contains(GameLevels[i]))
            {
                AssignLevelNames(i);
                isOneGameLevelLoaded = true;
                return;
            }
        }
        if (!isOneGameLevelLoaded)
        {
            Debug.LogWarning("No game level is loaded, you need to drag and drop one game level in the inspector to load it additively.\n Loading first level by default.");
            SceneManager.LoadScene(LevelNames[0], LoadSceneMode.Additive);
            AssignLevelNames(0);
        }

    }
    void AssignLevelNames(int i)
    {
        CurrentLevelName = LevelNames[i];
    }

    public IEnumerator SceneTransition(string levelToLoad)
    {
        print("SceneTransition to " + levelToLoad);
        yield return StartCoroutine(UIManager.instance.Fade("out", 1f));
        SceneManager.UnloadSceneAsync(CurrentLevelName);
        print("Unloaded level: " + CurrentLevelName);
        SceneManager.LoadSceneAsync(levelToLoad, LoadSceneMode.Additive);
        print("Loaded level: " + levelToLoad);
        CurrentLevelName = levelToLoad;
        yield return StartCoroutine(UIManager.instance.Fade("in", 1f));
        print("transition complete");
    }
    private void OnGUI()
    {

        GUI.Label(new Rect(0, 15, 100, 100), "Current Level: " + CurrentLevelName);
    }
}
