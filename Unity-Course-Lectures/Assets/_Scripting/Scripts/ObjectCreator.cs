using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCreator : MonoBehaviour
{
    public GameObject ObjectToSpawn;
    public int ObjectsToSpawn = 0;
    
    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            KeyboardInputColorChanger[] objectsToDestroy = GameObject.FindObjectsOfType<KeyboardInputColorChanger>();
            for(int i = 0; i < objectsToDestroy.Length; i++)
                Destroy(objectsToDestroy[i].gameObject);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            for (int i = 0; i < ObjectsToSpawn; i++)
            {
                GameObject go = Instantiate(ObjectToSpawn);
                go.transform.position = new Vector3(Random.Range(0, 10), 0f, Random.Range(0, 10));
            }
        }
    }


}
