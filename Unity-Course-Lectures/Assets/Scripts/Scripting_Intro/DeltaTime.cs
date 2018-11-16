using UnityEngine;
using System.Collections;

public class DeltaTime : MonoBehaviour
{
    public bool deltaTime = true;

    public float movSpeed = 3f;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movVec = transform.forward * movSpeed;

        if (deltaTime)
            transform.Translate(movVec * Time.deltaTime);

        else
            transform.Translate(movVec);



    }
}
