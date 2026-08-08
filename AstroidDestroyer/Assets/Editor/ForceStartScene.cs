#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;

[InitializeOnLoad]
public class ForceStartScene
{
    static ForceStartScene()
    {
        if (EditorBuildSettings.scenes.Length > 0)
        {
            string scenePath = EditorBuildSettings.scenes[0].path;
            SceneAsset sceneAsset = AssetDatabase.LoadAssetAtPath<SceneAsset>(scenePath);
            
            EditorSceneManager.playModeStartScene = sceneAsset;
        }
    }
}
#endif