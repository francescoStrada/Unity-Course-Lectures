using UnityEngine;
using System.Collections;

public class SpawnnerManager : MonoBehaviour
{
    public bool singleButtonSpawn = false;

    private EnemySpawner[] spawners;

    // Use this for initialization
    void Start()
    {
        spawners = FindObjectsOfType<EnemySpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!singleButtonSpawn && Input.GetKeyDown(KeyCode.Space))
            Spawn();
        else if (singleButtonSpawn && (Input.GetKeyDown(KeyCode.V) || Input.GetKeyDown(KeyCode.M)))
            Spawn();
    }

    private void Spawn()
    {
        int randomSpawnSpot = Random.Range(0, spawners.Length);
        spawners[randomSpawnSpot].SpawnEnemy(Random.Range(1, 5));
    }
}
