using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleThirdPersonController_Empty : MonoBehaviour
{
    //Which public variables do you need?
    // A Camera
    // A Rotation Speed
    // A Movement Speed
    

    void Update()
    {
        //Get the Input using Input.GetAxis() & assign the values to a new direction Vector3

        //Compute direction According to Camera Orientation (use function TransformDirection)
        //Reference: https://docs.unity3d.com/ScriptReference/Transform.TransformDirection.html
        
        //Calculate the new direction vector between the current forward and the target direction calculated previously.
        //To calculate it use the RotateTowards method
        //Reference: https://docs.unity3d.com/ScriptReference/Vector3.RotateTowards.html

        //Rotate the object, you can use Quaternion.LookRotation() function.
        //Reference: https://docs.unity3d.com/ScriptReference/Quaternion.LookRotation.html

        //Translate along forward

    }
}
