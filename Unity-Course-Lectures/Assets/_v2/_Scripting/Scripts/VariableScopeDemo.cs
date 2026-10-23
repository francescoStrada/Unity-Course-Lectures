using UnityEngine;

public class VariableScopeDemo : MonoBehaviour
{
    public float PublicSpeed = 1f;                      // in the Inspector, any script can change it
    [SerializeField] private float serializedSpeed = 1f; // in the Inspector, only this script can change it
    private float hiddenSpeed = 1f;                     // not in the Inspector, only this script

    void Update()
    {
        // The cube spins at the sum of the three, so changing any field is visible.
        float total = PublicSpeed + serializedSpeed + hiddenSpeed;
        transform.Rotate(Vector3.up * total * 45f * Time.deltaTime);
    }
}
