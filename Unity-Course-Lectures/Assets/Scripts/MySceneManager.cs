using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManager : MonoBehaviour
{
    [SerializeField] private bool _persistent = true;
    [SerializeField] private RectTransform _loadingIconT;
    [SerializeField] private float _loadingIconRotationSpeed = 5f;


    private static MySceneManager _instance;

    public static MySceneManager Instance { get { return _instance; } }
 
    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

        if(_persistent)
        DontDestroyOnLoad(this);

        _loadingIconT.gameObject.SetActive(false);

    }

    public void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;

    }

    private IEnumerator LoadSceneAsync(string sceneName, LoadSceneMode mode)
    {
        Debug.Log("Async loading scene: " + sceneName);

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName, mode);

        _loadingIconT.gameObject.SetActive(true);
        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            _loadingIconT.Rotate(Vector3.forward * _loadingIconRotationSpeed * Time.deltaTime);
            yield return null;
        }

        _loadingIconT.gameObject.SetActive(false);
    }

    public void LoadScene(string sceneName, LoadSceneMode mode, bool asyncLoad = false)
    {
        Scene activeScene = SceneManager.GetActiveScene();
        if (activeScene.name == sceneName)
            return;

        if(mode == LoadSceneMode.Additive)
        {
            for(int i = 0; i < SceneManager.sceneCount; i++)
            {
                if (SceneManager.GetSceneAt(i).name == sceneName)
                    return;
            }

        }

        if (!asyncLoad)
            SceneManager.LoadScene(sceneName, mode);

        else
            StartCoroutine(LoadSceneAsync(sceneName, mode));
        
    }

    public void OnSceneLoaded(Scene loadedScene, LoadSceneMode mode)
    {
        Debug.Log("Completed loading " + loadedScene.name);
        SceneManager.SetActiveScene(loadedScene);
    }

    public void LoadAllScenes()
    {

    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
