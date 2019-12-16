using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SceneViewExtensionsEditor
{
    [MenuItem("Tools/Scene Extensions/Empty In Selection Center")]
    private static void CreateEmptyInSelection()
    {
        Bounds centerBounds = new Bounds(Vector3.zero, Vector3.zero);
        Transform[] transforms = Selection.transforms;
        for (int i = 0; i < Selection.transforms.Length; i++)
        {
            Bounds extensionBounds;
            Renderer r = transforms[i].GetComponent<Renderer>();

            if (r != null)
                extensionBounds = r.bounds;
            else
                extensionBounds = new Bounds(transforms[i].position, Vector3.zero);

            if (i == 0)
            {
                centerBounds = extensionBounds;
            }

            else
                centerBounds.Encapsulate(extensionBounds);
        }


        GameObject empty = new GameObject("New Empty");
        empty.transform.position = centerBounds.center;
    }
}
