using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindingTags : MonoBehaviour
{

    public bool destroyEnemy;
    public bool destroyRed;
    public bool destroyGreen;

    // Use this for initialization
    void Start()
    {
        if (destroyEnemy)
        {
            GameObject enemy = GameObject.FindGameObjectWithTag("enemy");
            if (enemy != null)
                Destroy(enemy);
        }

        if (destroyRed)
        {
            GameObject[] reds = GameObject.FindGameObjectsWithTag("red");
            foreach (GameObject go in reds)
                Destroy(go);
        }

        if (destroyGreen)
        {
            GameObject[] greens = GameObject.FindGameObjectsWithTag("green");
            foreach (GameObject go in greens)
                Destroy(go);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (destroyRed)
        {
            GameObject[] reds = GameObject.FindGameObjectsWithTag("red");
            foreach (GameObject go in reds)
                Destroy(go);

            destroyRed = false;
        }

        if (destroyGreen)
        {
            GameObject[] greens = GameObject.FindGameObjectsWithTag("green");
            foreach (GameObject go in greens)
                Destroy(go, 2f);

            destroyGreen = false;

        }

        if (destroyEnemy)
        {
            GameObject enemy = GameObject.FindGameObjectWithTag("enemy");
            if (enemy != null)
                Destroy(enemy);

            destroyEnemy = false;
        }
    }
}
