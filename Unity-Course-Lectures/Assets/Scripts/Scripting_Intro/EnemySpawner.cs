using UnityEngine;
using System.Collections;
using System.ComponentModel.Design;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyToSpawn;

    public void SpawnEnemy(int number)
    {
        Transform enemiesRoot = GameObject.Find("Enemies").transform;

        for (int i = 0; i < number; i++)
        {
            GameObject enemyGO = Instantiate(enemyToSpawn,enemiesRoot) as GameObject;
            enemyGO.transform.position = new Vector3(transform.position.x, 1.0f, transform.position.z);
        }
       

    }

}
