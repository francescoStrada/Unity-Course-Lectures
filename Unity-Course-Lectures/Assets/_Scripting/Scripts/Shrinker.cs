using UnityEngine;
using System.Collections;

public class Shrinker : Interactable
{
    
    public override void Interact(GameObject caller)
    {
        //Debug.Log(caller.name + "is interacting with shrinking object " + gameObject.name);
        transform.localScale = transform.localScale / 2f;
    }
    
}
