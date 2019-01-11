using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChangeTrigger : MonoBehaviour
{
    [SerializeField] string _sceneToLoad;
    [SerializeField] bool _loadAdditively = false;
    [SerializeField] bool _loadAsync = false;
    [SerializeField] bool _removeCurrent = false;


    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            LoadSceneMode loadingMode = _loadAdditively ? LoadSceneMode.Additive : LoadSceneMode.Single;
            MySceneManager.Instance.LoadScene(_sceneToLoad, loadingMode, _loadAsync);

        }
    }
    
}
