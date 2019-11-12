using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbductionEnemy : MonoBehaviour
{
    public float rotationSpeed = 2f;
    public float movSpeed = 4f;
    public float minDistanceToTarget = 0.5f;
    public AbductionPlayerController.PlayerType enemyOfPlayer;
    public Material abductionP1Mat, abductionP2Mat;

    private MovingTarget[] targets;
    private GameObject[] targetsGO;
    private MovingTarget currentTarget;
    private bool targetReached = false;

    private bool _targetsReached;
    private Rigidbody rigidbody;

    private bool _abduct = false;


    private void Start()
    {
        //Find targets with components
        targets = FindObjectsOfType<MovingTarget>();
        
        AssignNewTarget();

        movSpeed = Random.Range(5f, 12f);

        //Assign same material color to according Player
        MeshRenderer mRenderer = gameObject.GetComponent<MeshRenderer>();
        if (mRenderer != null)
            mRenderer.material = enemyOfPlayer == AbductionPlayerController.PlayerType.PlayerL ? abductionP1Mat : abductionP2Mat;

    }

    // Update is called once per frame
	void Update ()
    {
        if (!targetReached && currentTarget != null)
        {
            Vector3 targetDirection = currentTarget.transform.position - transform.position;
            targetDirection.y = 0f;
            targetDirection.Normalize();

            float step = rotationSpeed * Time.deltaTime;
            Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDirection, step, 0.0f);
            transform.rotation = Quaternion.LookRotation(newDir, transform.up);

            Vector3 movVec = Vector3.forward * movSpeed * Time.deltaTime;
            Debug.DrawRay(transform.position + (2 * Vector3.up), transform.forward * 3.0f, new Color(0.61f, 0.45f, 0.45f));

            transform.Translate(movVec);

            targetReached = TargetReached();
            if (targetReached)
            {
                targetReached = true;
                Invoke("AssignNewTarget", 0.1f);
            }

        }

    }

    void FixedUpdate()
    {
        if (_abduct)
        {
            rigidbody.AddForce(Vector3.up, ForceMode.Impulse);
            rigidbody.AddTorque(Vector3.right, ForceMode.Impulse);
        }
    }

    private void AssignNewTarget()
    {
        targetReached = false;
        currentTarget = GetRandomTarget();
    }

    private bool TargetReached()
    {
        Vector3 enemyPos = transform.position;
        enemyPos.y = 0f;

        Vector3 targetPos = currentTarget.transform.position;
        targetPos.y = 0f;

        float distanceSquared = (enemyPos - targetPos).sqrMagnitude;

        return (distanceSquared <= minDistanceToTarget * minDistanceToTarget);
    }

    private MovingTarget GetRandomTarget()
    {
        if (targets.Length == 0)
            return null;

        int randomIndex = Random.Range(0, targets.Length);
        return targets[randomIndex];
    }

    public void Abduct()
    {
        _abduct = true;
        rigidbody = gameObject.GetComponent<Rigidbody>();
        rigidbody.isKinematic = false;
        rigidbody.mass = 1f;
        rigidbody.drag = 0.05f;
        rigidbody.angularDrag = 2.5f;

    }

}
