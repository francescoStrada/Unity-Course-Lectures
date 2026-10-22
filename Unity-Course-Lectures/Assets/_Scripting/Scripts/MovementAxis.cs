using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementAxis : MonoBehaviour {

    public float movSpeed = 5;
    public InputActionReference moveAction;

    void OnEnable()
    {
        // Project-wide actions are shared by every script, so they are enabled here but never disabled
        moveAction.action.Enable();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        // Legacy Input (as in the videos):
        // float h = Input.GetAxis("Horizontal");
        // float v = Input.GetAxis("Vertical");
        Vector2 move = moveAction.action.ReadValue<Vector2>();
        float h = move.x;
        float v = move.y;
        Vector3 direction = new Vector3(h, 0f, v);
        direction.Normalize();

        transform.Translate(direction * movSpeed * Time.deltaTime);
    }
}
