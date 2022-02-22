using UnityEditor;

[CustomEditor(typeof(LevelDoorVolume))]
public class LevelDoorVolumeEditor : Editor
{
    string levelToLoad;
    SceneAsset sceneAsset;
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        /*
                LevelDoorVolume myScript = (LevelDoorVolume)target;
                sceneAsset = (SceneAsset)EditorGUILayout.ObjectField("Scene to load", AssetDatabase.LoadAssetAtPath(myScript.scenePath, typeof(SceneAsset)), typeof(SceneAsset), false);
                if (sceneAsset != null)
                {
                    myScript.levelToLoad = sceneAsset.name;
                    myScript.scenePath = AssetDatabase.GetAssetPath(sceneAsset);
                }
                */
        //TODO: finish this
    }

}