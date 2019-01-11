using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MultiSceneLauncher : MonoBehaviour
{
    [SerializeField] private string _firstScene;

    // Start is called before the first frame update
    void Awake()
    {
        SceneManager.LoadScene(_firstScene, LoadSceneMode.Additive);
        
    }
}
