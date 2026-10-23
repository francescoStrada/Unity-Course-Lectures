using UnityEngine;
using UnityEngine.InputSystem;

public class VariableScopeReader : MonoBehaviour
{
    [SerializeField] private VariableScopeDemo demo;

    void Update()
    {
        if (Keyboard.current == null) return;

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
            demo.PublicSpeed = 5f;      // allowed: the field is public

        // demo.serializedSpeed = 5f;   // would not compile: the field is private
    }
}
