using UnityEngine;

public class NullReferenceDemo : MonoBehaviour
{
    [SerializeField] private Transform target;      // left EMPTY in the scene on purpose
    [SerializeField] private float speed = 2f;

    void Update()
    {
        // Step 1 (live): this line throws a NullReferenceException while "target" is empty.
        Vector3 toTarget = target.position - transform.position;
        transform.position += toTarget.normalized * speed * Time.deltaTime;
    }

    // Step 2 (live): replace the body of Update with this to see "check, log, keep going".
    //
    // if (target == null)
    // {
    //     Debug.LogError("NullReferenceDemo: no target assigned", this);
    //     enabled = false;   // off, instead of an error every frame
    //     return;
    // }
}
