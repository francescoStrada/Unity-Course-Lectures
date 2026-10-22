using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class AxisInput : MonoBehaviour
{
    public float range = 2.0f;
    public bool axisInput = true;
    public InputActionReference moveAction;

    // Same values as the Horizontal and Vertical axes in the legacy Input Manager
    public float sensitivity = 3f;
    public float gravity = 3f;

    private Vector3 initialPosition;

    // Eased axis values, kept from one frame to the next like Input.GetAxis does
    private float h;
    private float v;

    void OnEnable()
    {
        // Project-wide actions are shared by every script, so they are enabled here but never disabled
        moveAction.action.Enable();
    }

    // Use this for initialization
    void Start()
    {
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (axisInput)
        {
            // Legacy Input (as in the videos):
            // float h = Input.GetAxis("Horizontal");
            // float v = Input.GetAxis("Vertical");
            Vector2 move = moveAction.action.ReadValue<Vector2>();
            h = Ease(h, move.x);
            v = Ease(v, move.y);
            float xPos = h * range + initialPosition.x;
            float zPos = v * range + initialPosition.z;

            transform.position = new Vector3(xPos, initialPosition.y, zPos);
        }

        else
        {
            Keyboard keyboard = Keyboard.current;
            if (keyboard == null)
                return;

            float xPos = initialPosition.x;
            float zPos = initialPosition.z;

            // Legacy Input (as in the videos):
            // if (Input.GetKey(KeyCode.W))
            if (keyboard.wKey.isPressed)
                zPos = initialPosition.z + range;

            // if (Input.GetKey(KeyCode.S))
            if (keyboard.sKey.isPressed)
                zPos = initialPosition.z - range;

            // if (Input.GetKey(KeyCode.A))
            if (keyboard.aKey.isPressed)
                xPos = initialPosition.x - range;

            // if (Input.GetKey(KeyCode.D))
            if (keyboard.dKey.isPressed)
                xPos = initialPosition.x + range;


            transform.position = new Vector3(xPos, initialPosition.y, zPos);
        }
    }

    // Approximates the legacy Input Manager: ease towards the input at Sensitivity,
    // back to rest at Gravity, and snap to 0 when the direction reverses.
    float Ease(float current, float target)
    {
        if (target != 0f && current != 0f && Mathf.Sign(target) != Mathf.Sign(current))
            current = 0f;
        float speed = target != 0f ? sensitivity : gravity;
        return Mathf.MoveTowards(current, target, speed * Time.deltaTime);
    }
}
