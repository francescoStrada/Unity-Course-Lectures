using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeOfCubesCreator : MonoBehaviour
{
    public int cubesPerSide = 10;
    public float cubesSize = 0.4f;
    public float rigidBodyMass = 0.1f;
    public Material materialToAssign;

    // Start is called before the first frame update
    void Start()
    {
        CreateCubeOfCubes();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateCubeOfCubes()
    {
        if (cubesPerSide < 1)
            return;
        if (cubesSize < 0.01f)
            return;

        for(int y = 0; y < cubesPerSide; y++)
        {
            for (int x = 0; x < cubesPerSide; x++)
                for (int z = 0; z < cubesPerSide; z++)
                {
                    GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    cube.transform.parent = transform;
                    cube.transform.localScale = new Vector3(cubesSize, cubesSize, cubesSize);
                    
                    float xPos = transform.position.x - (cubesPerSide * cubesSize) / 2 + cubesSize * x;
                    float zPos = transform.position.z - (cubesPerSide * cubesSize) / 2 + cubesSize * z;
                    float yPos = transform.position.y - (cubesPerSide * cubesSize) / 2 + cubesSize * y;

                    cube.transform.position = new Vector3(xPos, yPos, zPos);

                    Rigidbody rb = cube.AddComponent<Rigidbody>();
                    rb.mass = rigidBodyMass;
                    rb.isKinematic = true;

                    cube.GetComponent<MeshRenderer>().sharedMaterial = materialToAssign;

                }
        }
    }
}
