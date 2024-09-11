using _Project.Scripts.Core.CarUpgrades;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Core.Enemies {
    public class SimpleEnemyBehaviour : MonoBehaviour {
        private StateMachine _stateMachine;

        private ChaseState _chaseState;
        private PatrolState _patrolState;

        [SerializeField] private EntityMovable _entityMovable;
        [SerializeField] private float _attackDistance;
        [SerializeField] private float _sightDistance;
        [SerializeField] private float _patrolRadius;
        [SerializeField] private float _minDistanceToPatrolPoint;

        [Header("Speed")]
        [SerializeField] private float _patrolSpeed;

        [SerializeField] private float _chaseSpeed;

        [Inject] private CurrentCarStatsModel _currentCarStatsModel;

        private void Start() {
            _stateMachine = new StateMachine();

            IMovable movable = _entityMovable;
            Transform playerTransform = _currentCarStatsModel.CarStatsHolder.transform;

            ChaseState chaseState = CreateChaseState(playerTransform, movable);
            _stateMachine.RegisterState(chaseState);
            _chaseState = chaseState;

            PatrolState patrolState = CreatePatrolState(movable, playerTransform);
            _stateMachine.RegisterState(patrolState);
            _patrolState = patrolState;
            
            ConfigureStates();

            _stateMachine.SwitchState<PatrolState>();
        }

        private void Update() {
            _stateMachine.CurrentState?.OnUpdate();
            ConfigureStates();
        }

        private void ConfigureStates() {
            _chaseState.Configure(_attackDistance, _sightDistance, _chaseSpeed);
            _patrolState.Configure(_patrolRadius, _minDistanceToPatrolPoint, _patrolSpeed);
        }

        private ChaseState CreateChaseState(Transform playerTransform, IMovable movable) =>
            new(_stateMachine, playerTransform, movable);

        private PatrolState CreatePatrolState(IMovable movable, Transform playerTransform) =>
            new(_stateMachine, movable, playerTransform);
    }
}