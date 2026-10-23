using UnityEngine;
using UnityEngine.InputSystem;

public class MoveWithReference : MonoBehaviour
{
    [SerializeField] private InputActionReference moveAction;
    [SerializeField] private float speed = 4f;

    void OnEnable()  => moveAction.action.Enable();
    void OnDisable() => moveAction.action.Disable();

    void Update()
    {
        Vector2 move = moveAction.action.ReadValue<Vector2>();
        transform.position += new Vector3(move.x, 0f, move.y) * speed * Time.deltaTime;
    }
}
