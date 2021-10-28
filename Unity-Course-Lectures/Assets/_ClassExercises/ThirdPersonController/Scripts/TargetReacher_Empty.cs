using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetReacher_Empty : MonoBehaviour
{
    //What do you need?
    // A target prefab
    // A variable to store the minimum distance
    // A variable to store the last created target


    void Start()
    {
        //Create the first Target
    }

    void Update()
    {
        //Check if the target exists 

        //If it exists check if the distance between the target and the moving character is smaller than the a minimum distance
        //To calculate distance use the function Vector3.Distance();
        //Reference: https://docs.unity3d.com/ScriptReference/Vector3.Distance.html

        //If the character has reached the target destroy the current one and create a new one in a random position
    }

}
