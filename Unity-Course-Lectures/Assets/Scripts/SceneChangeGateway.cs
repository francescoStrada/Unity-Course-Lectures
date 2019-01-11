using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeGateway : MonoBehaviour
{
    [SerializeField] private BoxCollider _sceneChangeTriggerEnter;
    [SerializeField] private BoxCollider _sceneChangeTrigger;

    [SerializeField] string _sceneToLoad;
    [SerializeField] bool _loadAdditively = false;
    [SerializeField] bool _loadAsync = false;

    private ColliderEventDispatcher _sceneChangeTriggerEnterDispatcher;
    private ColliderEventDispatcher _sceneChangeTriggerDispatcher;

    // Start is called before the first frame update
    void Start()
    {
        _sceneChangeTrigger.enabled = false;

        _sceneChangeTriggerEnterDispatcher = _sceneChangeTriggerEnter.GetComponent<ColliderEventDispatcher>();
        _sceneChangeTriggerEnterDispatcher.TriggerEnter += OnEnteredGateway;

        _sceneChangeTriggerDispatcher = _sceneChangeTrigger.GetComponent<ColliderEventDispatcher>();
        _sceneChangeTriggerDispatcher.TriggerEnter += OnEnteredSceneChangeTrigger;

    }

    private void OnEnteredGateway(Collider other)
    {
        _sceneChangeTrigger.enabled = true;
    }

    private void OnEnteredSceneChangeTrigger(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            LoadSceneMode loadingMode = _loadAdditively ? LoadSceneMode.Additive : LoadSceneMode.Single;
            MySceneManager.Instance.LoadScene(_sceneToLoad, loadingMode, _loadAsync);
            _sceneChangeTrigger.enabled = false;
        }


    }
}
