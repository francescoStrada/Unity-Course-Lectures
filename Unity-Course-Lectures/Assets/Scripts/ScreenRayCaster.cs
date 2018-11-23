using System;
using UnityEngine;
using System.Collections;

public class ScreenRayCaster : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    
    // Use this for initialization
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                Interactable interactable = hit.transform.GetComponent<Interactable>();
                
                if (interactable != null)
                    interactable.Interact(gameObject);
                
            }
        }
    }
}
