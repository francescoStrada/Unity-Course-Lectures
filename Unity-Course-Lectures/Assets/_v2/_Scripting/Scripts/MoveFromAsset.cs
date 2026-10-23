using UnityEngine;
using UnityEngine.InputSystem;

public class MoveFromAsset : MonoBehaviour
{
    [SerializeField] private float speed = 4f;
    private InputAction move;

    void Awake()
    {
        move = InputSystem.actions.FindAction("Move");
    }

    void Update()
    {
        Vector2 v = move.ReadValue<Vector2>();
        transform.position += new Vector3(v.x, 0f, v.y) * speed * Time.deltaTime;
    }
}
