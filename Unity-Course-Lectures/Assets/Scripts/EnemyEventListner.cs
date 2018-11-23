using System;
using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;

public class EnemyEventListner : MonoBehaviour
{
    public float rotationSpeed = 2f;
    public float movSpeed = 4f;
    public float minDistanceToTarget = 0.5f;

    private TargetEventLauncher[] _targets;
    private Vector3 _targetPosition;
    private bool _targetReached = false;
    protected bool _targetAssigned = false;
    private bool _dead = false;
    private EnemyBoss boss;
    

    // Use this for initialization
    protected void Start()
    {
        SubscribeToTargets();

        boss = FindObjectOfType<EnemyBoss>();
        if(boss != null)
            boss.BossHt += OnBossHt;

        movSpeed = Random.Range(4f, 10f);
    }

    private void OnBossHt()
    {
        _targetAssigned = false;
        _dead = true;
        //gameObject.AddComponent<Rigidbody>();
        Destroy(gameObject);
        //boss.BossHt -= OnBossHt;
    }

    private void OnPlayerReachedTarget(Vector3 targetPosition)
    {
        _targetReached = false;
        _targetAssigned = true;
        _targetPosition = targetPosition;
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (_dead)
            return;

        if (!_targetReached && _targetAssigned)
        {
            Vector3 targetDirection = _targetPosition - transform.position;
            targetDirection.y = 0f;
            targetDirection.Normalize();

            float step = rotationSpeed * Time.deltaTime;
            Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDirection, step, 0.0f);
            transform.rotation = Quaternion.LookRotation(newDir, transform.up);

            Vector3 movVec = Vector3.forward * movSpeed * Time.deltaTime;
            Debug.DrawRay(transform.position + (2 * Vector3.up), transform.forward * 3.0f, new Color(0.61f, 0.45f, 0.45f));

            transform.Translate(movVec);

            _targetReached = TargetReached();
            if (_targetReached)
            {
                _targetReached = true;
                _targetAssigned = false;
            }

        }

    }

    private bool TargetReached()
    {
        Vector3 enemyPos = transform.position;
        enemyPos.y = 0f;

        Vector3 targetPos = _targetPosition;
        targetPos.y = 0f;

        float distanceSquared = (enemyPos - targetPos).sqrMagnitude;

        return (distanceSquared <= minDistanceToTarget * minDistanceToTarget);
    }

    protected void SubscribeToTargets()
    {
        _targets = FindObjectsOfType<TargetEventLauncher>();
        foreach (TargetEventLauncher target in _targets)
        {
            target.PlayerReachedTarget += OnPlayerReachedTarget;
        }
    }
}
