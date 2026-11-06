using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class FirstPersonController : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private InputActionReference moveAction;
    [SerializeField] private InputActionReference lookAction;

    [SerializeField] private float speed = 5f;               // metres per second
    [SerializeField] private float lookSensitivity = 1.5f;   // the Look action already scales the mouse by 0.1
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private float jumpHeight = 1.2f;        // metres

    private CharacterController characterController;
    private float pitch;            // the camera's up/down angle
    private float verticalSpeed;    // falling and jumping speed

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    void OnEnable()
    {
        moveAction.action.Enable();
        lookAction.action.Enable();
    }

    void OnDisable()
    {
        moveAction.action.Disable();
        lookAction.action.Disable();
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (Keyboard.current == null) return;

        // Cursor: Esc frees it and pauses the controls, a click in the Game view locks it again
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
            Cursor.lockState = CursorLockMode.None;
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
            Cursor.lockState = CursorLockMode.Locked;
        if (Cursor.lockState != CursorLockMode.Locked) return;

        // Look: x turns the whole body, y tilts only the camera.
        // No Time.deltaTime here: the mouse delta is already "how far it moved this frame".
        Vector2 look = lookAction.action.ReadValue<Vector2>() * lookSensitivity;
        transform.Rotate(Vector3.up * look.x);
        pitch = Mathf.Clamp(pitch - look.y, -90f, 90f);
        cameraTransform.localRotation = Quaternion.Euler(pitch, 0f, 0f);

        // Move: along the body's own right and forward axes
        Vector2 move = moveAction.action.ReadValue<Vector2>();
        Vector3 direction = transform.right * move.x + transform.forward * move.y;
        characterController.Move(direction * speed * Time.deltaTime);

        // Gravity: keep a small downward push on the ground, accelerate in the air
        if (characterController.isGrounded && verticalSpeed < 0f)
            verticalSpeed = -2f;
        verticalSpeed += gravity * Time.deltaTime;

        // Jump: the speed needed to reach jumpHeight (v = sqrt(2 * g * h))
        if (characterController.isGrounded && Keyboard.current.spaceKey.wasPressedThisFrame)
            verticalSpeed = Mathf.Sqrt(jumpHeight * -2f * gravity);

        characterController.Move(Vector3.up * verticalSpeed * Time.deltaTime);
    }
}
