using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TowerGuardFSM : MonoBehaviour
{
    [SerializeField] private List<Transform> _waypoints;
    [SerializeField] private GameObject _target;
    [SerializeField] private float _minChaseDistance = 3f;
    [SerializeField] private float _minAttackDistance = 2f;

    [SerializeField] private Transform _gunPivot;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private float _shootFrequency;
    [SerializeField] private float _shootForce;

    private FiniteStateMachine<TowerGuardFSM> _stateMachine;

    private NavMeshAgent _navMeshAgent;
    private int _currentWayPointIndex = 0;
    private Renderer _renderer;
    private Color _originalColor;

    public Renderer Renderer => _renderer;
    public Color OriginalColor => _originalColor;

    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _renderer = GetComponent<Renderer>();
        _originalColor = _renderer.material.color;

        _stateMachine = new FiniteStateMachine<TowerGuardFSM>(this);

        //STATES
        State patrolState = new TowerGuardPatrolState("Patrol", this);
        State chaseState = new TowerGuardChaseState("Chase", this);
        State attackState = new TowerGuardAttackState("Attack", this);

        //TRANSITIONS
        _stateMachine.AddTransition(patrolState, chaseState, () => DistanceFromTarget() <= _minChaseDistance);
        _stateMachine.AddTransition(chaseState, patrolState, () => DistanceFromTarget() > _minChaseDistance);
        _stateMachine.AddTransition(chaseState, attackState, () => DistanceFromTarget() <= _minAttackDistance);
        _stateMachine.AddTransition(attackState, chaseState, () => DistanceFromTarget() >= _minAttackDistance);

        //START STATE
        _stateMachine.SetState(patrolState);
    }

    void Update() => _stateMachine.Tik();
    public void SetNextWayPointDestination(bool startRandom = false)
    {
        if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance && _navMeshAgent.velocity.sqrMagnitude <= 0f)
        {
            if (startRandom) _currentWayPointIndex = Random.Range(0, _waypoints.Count);
            else _currentWayPointIndex = (_currentWayPointIndex + 1) % _waypoints.Count;
            
            Vector3 nextWayPointPos = _waypoints[_currentWayPointIndex].position;
            _navMeshAgent.SetDestination(new Vector3(nextWayPointPos.x, transform.position.y, nextWayPointPos.z));
        }
    }
    public void FollowTarget() => _navMeshAgent.SetDestination(_target.transform.position);

    public IEnumerator ShootCoroutine()
    {
        while (true)
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

    //TRANSITION FUNCTIONS
    private float DistanceFromTarget() => Vector3.Distance(_target.transform.position, transform.position);
}

public class TowerGuardPatrolState : State
{
    private TowerGuardFSM _guard;
    public TowerGuardPatrolState(string name, TowerGuardFSM guard) : base(name)
    {
        _guard = guard;
    }

    public override void Enter()
    {
        _guard.Renderer.material.color = _guard.OriginalColor;
        _guard.SetNextWayPointDestination(true);
    }

    public override void Tik()
    {
        _guard.SetNextWayPointDestination();
    }

    public override void Exit()
    {

    }
}

public class TowerGuardChaseState : State
{
    private TowerGuardFSM _guard;
    public TowerGuardChaseState(string name, TowerGuardFSM guard) : base(name)
    {
        _guard = guard;
    }

    public override void Enter()
    {
        _guard.Renderer.material.color = Color.yellow;
    }

    public override void Tik()
    {
        _guard.FollowTarget();
    }

    public override void Exit()
    {
    }
}

public class TowerGuardAttackState : State
{
    private TowerGuardFSM _guard;
    public TowerGuardAttackState(string name, TowerGuardFSM guard) : base(name)
    {
        _guard = guard;
    }

    public override void Enter()
    {
        _guard.Renderer.material.color = Color.red;
        _guard.StartCoroutine(_guard.ShootCoroutine());
    }

    public override void Tik()
    {
        _guard.FollowTarget();
    }

    public override void Exit()
    {
        _guard.StopAllCoroutines();
    }
}
