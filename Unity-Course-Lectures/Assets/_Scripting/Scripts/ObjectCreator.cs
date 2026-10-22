using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ObjectCreator : MonoBehaviour
{
    public GameObject ObjectToSpawn;
    public int ObjectsToSpawn = 0;
    
    void Start()
    {
        
    }
    void Update()
    {
        Keyboard keyboard = Keyboard.current;
        if (keyboard == null)
            return;

        // Legacy Input (as in the videos):
        // if (Input.GetKeyDown(KeyCode.D))
        if (keyboard.dKey.wasPressedThisFrame)
        {
            // Deprecated (as in the videos):
            // KeyboardInputColorChanger[] objectsToDestroy = GameObject.FindObjectsOfType<KeyboardInputColorChanger>();
            KeyboardInputColorChanger[] objectsToDestroy = FindObjectsByType<KeyboardInputColorChanger>(FindObjectsSortMode.None);
            for(int i = 0; i < objectsToDestroy.Length; i++)
                Destroy(objectsToDestroy[i].gameObject);
        }

        // if (Input.GetKeyDown(KeyCode.S))
        if (keyboard.sKey.wasPressedThisFrame)
        {
            for (int i = 0; i < ObjectsToSpawn; i++)
            {
                GameObject go = Instantiate(ObjectToSpawn);
                go.transform.position = new Vector3(Random.Range(0, 10), 0f, Random.Range(0, 10));
            }
        }
    }


}
