using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingTowerFSM : MonoBehaviour
{
    [SerializeField] private Transform _rotatingBase;
    [SerializeField] private Transform _gunPivot;
    [SerializeField] private Transform _rayOrigin;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _targetFoundRotationSpeed;
    [SerializeField] private float _maxTargetDistance;
    [SerializeField] private LayerMask _visibilityRaLayerMask;
    [Range(0, 360)]
    [SerializeField] private float _viewAngle;

    [SerializeField] private Bullet _bullet;
    [SerializeField] private float _shootFrequency;
    [SerializeField] private float _shootForce;

    private FiniteStateMachine<ShootingTowerFSM> _stateMachine;


    private Target _target;
    
    void Start()
    {
        //Get Initial References
        _target = FindObjectOfType<Target>();
        _rotatingBase.Rotate(Vector3.up, Random.Range(0f, 355f));

        _stateMachine = new FiniteStateMachine<ShootingTowerFSM>(this);

        //STATES
        State patrolState = new TowerPatrolState("Patrol", this);
        State attackState = new TowerAttackState("Attack", this);

        //TRANSITIONS
        _stateMachine.AddTransition(patrolState, attackState, IsTargetInSight);
        _stateMachine.AddTransition(attackState, patrolState, () => !IsTargetInSight());

        //START STATE
        _stateMachine.SetState(patrolState);
    }


    void Update() => _stateMachine.Tik();

    private bool IsTargetInSight()
    {
        //CHECK IF IS WITHIN VIEW DISTANCE
        Vector3 directionToTarget = _target.transform.position - transform.position;
        float squareTargetDistance = (directionToTarget).sqrMagnitude;
        if (squareTargetDistance <= _maxTargetDistance * _maxTargetDistance)
        {
            //CHECK IF FALLS WITHIN VIEW ANGLE
            float angleToTarget = Vector3.Angle(_rotatingBase.forward, directionToTarget.normalized);
            if (angleToTarget < _viewAngle * 0.5f)
            {
                //CHECK IF THERE ARE NO OBSTACLES
                RaycastHit hitInfo;
                Ray ray = new Ray(_rayOrigin.position, (_target.HeadPosition.transform.position - _rayOrigin.position).normalized);
                Debug.DrawRay(_rayOrigin.position, (_target.HeadPosition.transform.position - _rayOrigin.position).normalized * _maxTargetDistance, Color.cyan);

                if (Physics.Raycast(ray, out hitInfo, _maxTargetDistance, _visibilityRaLayerMask))
                {
                    Target target = hitInfo.transform.GetComponentInParent<Target>();
                    if (target)
                        return true;
                }
            }
        }
        return false;
    }

    public void ContinuousRotation()
    {
        _rotatingBase.Rotate(Vector3.up, _rotationSpeed * Time.deltaTime);
    }

    public void PointTarget()
    {
        Vector3 directionToTarget = _target.transform.position - transform.position;
        directionToTarget.y = 0f;
        directionToTarget.Normalize();

        Vector3 newDir = Vector3.RotateTowards(_rotatingBase.forward, directionToTarget, _targetFoundRotationSpeed * Time.deltaTime, 0f);
        _rotatingBase.rotation = Quaternion.LookRotation(newDir);
    }
    public IEnumerator ShootCoroutine()
    {
        while(true)
        {
            Vector3 targetHead = _target.transform.position + Vector3.up * 4f;
            Vector3 shootingDirection = (targetHead - _gunPivot.position).normalized;
            Bullet bullet = Instantiate(_bullet, _gunPivot.position, Quaternion.identity);
            bullet.transform.up = shootingDirection;

            Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
            bulletRb.AddForce(shootingDirection * _shootForce, ForceMode.Impulse);

            yield return new WaitForSeconds(_shootFrequency);
        }

    }
}
public class TowerPatrolState : State
{
    private ShootingTowerFSM _tower;
    public TowerPatrolState(string name, ShootingTowerFSM tower) : base(name)
    {
        _tower = tower;
    }

    public override void Enter()
    {
       
    }

    public override void Tik()
    {
        _tower.ContinuousRotation();
    }

    public override void Exit()
    {

    }
}

public class TowerAttackState : State
{
    private ShootingTowerFSM _tower;
    public TowerAttackState(string name, ShootingTowerFSM tower) : base(name)
    {
        _tower = tower;
    }

    public override void Enter()
    {
        _tower.StartCoroutine(_tower.ShootCoroutine());
    }

    public override void Tik()
    {
        _tower.PointTarget();
    }

    public override void Exit()
    {
        _tower.StopAllCoroutines();
    }
}

