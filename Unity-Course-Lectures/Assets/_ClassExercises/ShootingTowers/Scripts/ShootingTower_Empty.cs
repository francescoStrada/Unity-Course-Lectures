using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingTower_Empty : MonoBehaviour
{
    //Define here all the variables you will be needing in the script and also all the objects you with to set a reference via the inspector
    public GameObject bullet;
    void Start()
    {
        //Retrieve here all the references to other object you will need in the script.
    }

    void Update()
    {
        // Constantly Rotate Tower if Target is NOT in Sight
        //You can use the function transform.Rotate(): https://docs.unity3d.com/ScriptReference/Transform.Rotate.html

        //Check if Target is visible to the tower
        if (IsTargetVisible(/* Some varialbes...*/))
        {
            PointTarget(/* Some varialbes...*/);
            
            //Start Shooting, if already started Shooting don't invoke again
            //Have a peek to the way we manage an automatic repeated function call in the ShootingTower.cs script. 
            //As a suggestion, we use the function InvokeRepeating(): https://docs.unity3d.com/ScriptReference/MonoBehaviour.InvokeRepeating.html
            Shoot();

            return;
        }
        
    }

    private void Shoot()
    {
        //Find a creative way to display the shooting behaviour
    }

    private bool IsTargetVisible(/* Some varialbes...*/)
    {
        //In this function you need to check if the target is visible to the tower. This is achieved by checking the three below conditions
        
        //CHECK IF IS WITHIN VIEW DISTANCE
        
        //CHECK IF FALLS WITHIN VIEW ANGLE
            
        //CHECK IF THERE ARE NO OBSTACLES
                
        return true;
    }

    private void PointTarget(/* Some varialbes...*/)
    {
        //Rotate the tower in order to always face the target
    }
}
