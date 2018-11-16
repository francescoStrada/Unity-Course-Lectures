using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour
{
    public Color ReachedColor = new Color(0.34f, 0.84f, 0.2f);
    public Color NoEnemyColor = new Color(178/255f, 77/255f, 77/255f);
    public Color PointingTargetColor = new Color(0f, 0f, 0.8f);

    private Renderer renderer;
   

    void Awake()
    {
        renderer = gameObject.GetComponent<Renderer>();
        renderer.material.color = NoEnemyColor;
    }

    public void TargetReached()
    {
        renderer.material.color = ReachedColor;
    }

    public void PointingTarget()
    {
        renderer.material.color = PointingTargetColor;
    }
}
