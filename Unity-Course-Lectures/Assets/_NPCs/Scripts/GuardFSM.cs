using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using UnityEngine;
using UnityEngine.AI;

public class GuardFSM : MonoBehaviour
{
    [SerializeField] private List<Transform> _waypoints;
    [SerializeField] private GameObject _target;
    [SerializeField] private float _minChaseDistance = 3f;
    [SerializeField] private float _minAttackDistance = 2f;
    [SerializeField] private float _stoppingDistance = 1f;

    private FiniteStateMachine<GuardFSM> _stateMachine;

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

        _stateMachine = new FiniteStateMachine<GuardFSM>(this);

        //STATES
        State patrolState = new PatrolState("Patrol", this);
        State chaseState = new ChaseState("Chase", this);
        State stopState = new StopState("Stop", this);

        //TRANSITIONS
        _stateMachine.AddTransition(patrolState, chaseState, () => DistanceFromTarget() <= _minChaseDistance);
        _stateMachine.AddTransition(chaseState,patrolState, () => DistanceFromTarget() > _minChaseDistance);
        _stateMachine.AddTransition(chaseState,stopState, () => DistanceFromTarget() <= _stoppingDistance);
        _stateMachine.AddTransition(stopState,chaseState, () => DistanceFromTarget() > _stoppingDistance);

        //START STATE
        _stateMachine.SetState(patrolState);
    }

    void Update() => _stateMachine.Tik();
    public void StopAgent(bool stop) => _navMeshAgent.isStopped = stop;
    public void SetWayPointDestination()
    {
        if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance && _navMeshAgent.velocity.sqrMagnitude <= 0f)
        {
            _currentWayPointIndex = (_currentWayPointIndex + 1) % _waypoints.Count;
            Vector3 nextWayPointPos = _waypoints[_currentWayPointIndex].position;
            _navMeshAgent.SetDestination(new Vector3(nextWayPointPos.x, transform.position.y, nextWayPointPos.z));
        }
    }
    public void FollowTarget() => _navMeshAgent.SetDestination(_target.transform.position);
    
    //TRANSITION FUNCTIONS
    private float DistanceFromTarget() => Vector3.Distance(_target.transform.position, transform.position);
}

public class PatrolState : State
{
    private GuardFSM _guard;
    public PatrolState(string name, GuardFSM guard) : base(name)
    {
        _guard = guard;
    }

    public override void Enter()
    {
        _guard.StopAgent(false);
        _guard.Renderer.material.color = _guard.OriginalColor;
    }

    public override void Tik()
    {
        _guard.SetWayPointDestination();
    }

    public override void Exit()
    {
        
    }
}

public class ChaseState : State
{
    private GuardFSM _guard;
    public ChaseState(string name, GuardFSM guard) : base(name)
    {
        _guard = guard;
    }

    public override void Enter()
    {
        _guard.StopAgent(false);
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

public class StopState : State
{
    private GuardFSM _guard;
    public StopState(string name, GuardFSM guard) : base(name)
    {
        _guard = guard;
    }

    public override void Enter()
    {
        _guard.StopAgent(true);
        _guard.Renderer.material.color = Color.red;
    }

    public override void Tik()
    {
        
    }

    public override void Exit()
    {
    }
}
