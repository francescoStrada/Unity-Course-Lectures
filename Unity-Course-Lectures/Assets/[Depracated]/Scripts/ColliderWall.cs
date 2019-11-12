using UnityEngine;
using System.Collections;

public class ColliderWall : MonoBehaviour
{
    public GameObject completeMesh;
    public GameObject singleParts;
    public Transform explosionPosition;

    

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "MovingCube")
        {
            explosionPosition.position = collision.contacts[0].point;
            completeMesh.SetActive(false);
            singleParts.SetActive(true);

            
        }
        
    }
}
