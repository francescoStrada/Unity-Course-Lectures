using UnityEngine;
using UnityEngine.InputSystem;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab;   // the Ball prefab

    void Update()
    {
        if (Keyboard.current == null) return;
        if (!Keyboard.current.spaceKey.wasPressedThisFrame) return;

        GameObject ball =
            Instantiate(ballPrefab, transform.position, transform.rotation);
        ball.AddComponent<Rigidbody>();   // a component added at run time
        Destroy(ball, 3f);                // gone after three seconds
    }
}
