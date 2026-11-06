using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
#endif

/// <summary>
/// Put this on one object of the ENVIRONMENT scene (A2-Environment).
///
/// Edit mode: the Inspector shows a button that opens the lighting scene next to the
///            environment one and makes it the active scene. Lighting data is saved against
///            the active scene, so bake only when the Inspector says the lighting scene is active.
/// Play mode: if you press Play with the environment scene alone, the lighting scene
///            is loaded for you (additively) and made active.
///
/// Builds: both scenes must be in File > Build Profiles > Scene List.
/// </summary>
[DisallowMultipleComponent]
public class LightingSceneLoader : MonoBehaviour
{
    [Tooltip("Exact name of the lighting scene file, without the .unity extension.")]
    [SerializeField] string lightingSceneName = "A2-Lighting";

    [Tooltip("When pressing Play, load the lighting scene if it is not already loaded.")]
    [SerializeField] bool loadOnPlay = true;

    // ---------------------------------------------------------------- Play mode / player

    void Start()
    {
        if (!loadOnPlay || SceneManager.GetSceneByName(lightingSceneName).isLoaded)
            return;

        AsyncOperation load = LoadLightingSceneAdditively();
        if (load == null)
        {
            Debug.LogError($"[LightingSceneLoader] Cannot load '{lightingSceneName}': is it in the Build Settings?");
            return;
        }

        // Same rule as in the editor: the lighting scene is the active one.
        load.completed += _ => SceneManager.SetActiveScene(SceneManager.GetSceneByName(lightingSceneName));
    }

    AsyncOperation LoadLightingSceneAdditively()
    {
#if UNITY_EDITOR
        // In the Editor the scene does not need to be in the Build Settings to try it out.
        string path = FindScenePath(lightingSceneName);
        return path == null
            ? null
            : EditorSceneManager.LoadSceneAsyncInPlayMode(path, new LoadSceneParameters(LoadSceneMode.Additive));
#else
        return Application.CanStreamedLevelBeLoaded(lightingSceneName)
            ? SceneManager.LoadSceneAsync(lightingSceneName, LoadSceneMode.Additive)
            : null;
#endif
    }

    // ---------------------------------------------------------------- Edit mode (Editor only)

#if UNITY_EDITOR
    public bool IsLightingSceneLoaded => SceneManager.GetSceneByName(lightingSceneName).isLoaded;
    public bool IsLightingSceneActive => SceneManager.GetActiveScene().name == lightingSceneName;

    /// <summary>True when baking, building and editing the lights is safe.</summary>
    public bool ReadyToBake => IsLightingSceneLoaded && IsLightingSceneActive;

    public bool IsInBuildSettings()
    {
        foreach (EditorBuildSettingsScene s in EditorBuildSettings.scenes)
            if (s.enabled && System.IO.Path.GetFileNameWithoutExtension(s.path) == lightingSceneName)
                return true;
        return false;
    }

    public void LoadLightingSceneAndMakeItActive()
    {
        Scene lighting = SceneManager.GetSceneByName(lightingSceneName);
        if (!lighting.isLoaded)
        {
            string path = FindScenePath(lightingSceneName);
            if (path == null)
            {
                Debug.LogError($"[LightingSceneLoader] No scene named '{lightingSceneName}' in the project.");
                return;
            }
            lighting = EditorSceneManager.OpenScene(path, OpenSceneMode.Additive);
        }
        SceneManager.SetActiveScene(lighting);
    }

    public void MakeThisSceneActiveAgain() => SceneManager.SetActiveScene(gameObject.scene);

    static string FindScenePath(string sceneName)
    {
        foreach (string guid in AssetDatabase.FindAssets("t:Scene " + sceneName))
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            if (System.IO.Path.GetFileNameWithoutExtension(path) == sceneName)
                return path;
        }
        return null;
    }

    [CustomEditor(typeof(LightingSceneLoader))]
    class LightingSceneLoaderEditor : Editor
    {
        // The status below must follow scene changes made anywhere in the Editor.
        public override bool RequiresConstantRepaint() => true;

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            var loader = (LightingSceneLoader)target;

            EditorGUILayout.Space();
            using (new EditorGUI.DisabledScope(Application.isPlaying))
            {
                if (GUILayout.Button("Load lighting scene and make it active"))
                    loader.LoadLightingSceneAndMakeItActive();
                if (GUILayout.Button("Make this scene active again"))
                    loader.MakeThisSceneActiveAgain();
            }

            EditorGUILayout.Space();
            if (Application.isPlaying)
                EditorGUILayout.HelpBox("Play mode: the lighting scene is loaded automatically if needed.", MessageType.None);
            else if (!loader.IsLightingSceneLoaded)
                EditorGUILayout.HelpBox("Lighting scene NOT loaded. Do not bake yet: load it with the button above.", MessageType.Warning);
            else if (!loader.IsLightingSceneActive)
                EditorGUILayout.HelpBox("Lighting scene is loaded but NOT active. A bake now would save the lighting data against the wrong scene.", MessageType.Warning);
            else
                EditorGUILayout.HelpBox("READY: the lighting scene is loaded and active. You can bake, build and edit the lights.", MessageType.Info);

            if (!Application.isPlaying && !loader.IsInBuildSettings())
                EditorGUILayout.HelpBox("The lighting scene is not in the Build Settings. Add both scenes before making a build.", MessageType.Warning);
        }
    }
#endif
}
