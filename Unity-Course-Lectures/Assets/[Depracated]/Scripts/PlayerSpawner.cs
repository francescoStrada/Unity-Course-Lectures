using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _playerPrefab;
    [SerializeField] private Transform _spawnTransform;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(_playerPrefab, _spawnTransform.position, _spawnTransform.rotation);        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
