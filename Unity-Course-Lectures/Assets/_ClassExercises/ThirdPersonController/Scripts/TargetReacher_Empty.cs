using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetReacher_Empty : MonoBehaviour
{
    //What do you need?
    // A reference to the Character GameObject
    // A variable to store the minimum distance
    
    void Start()
    {
        //Position the target in a random position, you can use a custom method
    }

    void Update()
    {
        //Check if the Chracter reference is valid 

        //If it exists check if the distance between the target and the moving character is smaller than the a minimum distance
        //To calculate distance use the function Vector3.Distance();
        //Reference: https://docs.unity3d.com/ScriptReference/Vector3.Distance.html

        //If the character has reached the target, reposition it (this game object) in a new random position
    }

}
