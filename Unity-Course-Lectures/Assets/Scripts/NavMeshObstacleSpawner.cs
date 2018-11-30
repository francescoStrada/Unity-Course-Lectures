using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class NavMeshObstacleSpawner : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private LayerMask _spawableLayer;
    [SerializeField] private GameObject _navMeshObstacle;

    private List<GameObject> _spawnedObstacles = new List<GameObject>();

    // Use this for initialization
    void Start ()
    {
        Assert.IsNotNull(_camera, "Missing Camera Component");
        Assert.IsNotNull(_navMeshObstacle, "Missing NavMeshObstacle GameObject");

    }

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, _spawableLayer))
            {
                Vector3 spawnPoint = new Vector3(hit.point.x,
                                                 hit.point.y + _navMeshObstacle.transform.localScale.y / 2,
                                                 hit.point.z);
                GameObject spawnedGO = Instantiate(_navMeshObstacle, spawnPoint, Quaternion.identity);
                _spawnedObstacles.Add(spawnedGO);
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
            ClearSpawnedObstacles();

    }

    public void ClearSpawnedObstacles()
    {
        foreach (GameObject go in _spawnedObstacles)
            Destroy(go);

        _spawnedObstacles.Clear();
    }
}
