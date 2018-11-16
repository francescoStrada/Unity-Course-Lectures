using UnityEngine;
using System.Collections;

public class SpawnnerManager : MonoBehaviour
{
    private EnemySpawner[] spawners;

    // Use this for initialization
    void Start()
    {
        spawners = FindObjectsOfType<EnemySpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            int randomSpawnSpot = Random.Range(0, spawners.Length);
            spawners[randomSpawnSpot].SpawnEnemy(Random.Range(1,5));
        }
    }
}
