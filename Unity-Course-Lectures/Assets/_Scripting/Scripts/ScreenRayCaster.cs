using System;
using UnityEngine;
using UnityEngine.InputSystem;
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
        Mouse mouse = Mouse.current;
        if (mouse == null)
            return;

        // Legacy Input (as in the videos):
        // if (Input.GetMouseButtonDown(1))
        if (mouse.rightButton.wasPressedThisFrame)
        {
            // Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            Ray ray = _camera.ScreenPointToRay(mouse.position.ReadValue());
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
