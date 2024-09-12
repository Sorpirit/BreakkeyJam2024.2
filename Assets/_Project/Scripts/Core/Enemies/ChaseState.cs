using UnityEngine;

namespace _Project.Scripts.Core.Enemies {
    public class ChaseState : IState {
        private readonly StateMachine _stateMachine;
        private readonly Transform _playerTransform;
        private readonly IMovable _movable;

        private float _attackDistance = 1.5f;
        private float _sightDistance = 10f;
        private float _chaseSpeed = 5f;

        public ChaseState(StateMachine stateMachine, Transform playerTransform, IMovable movable) {
            _stateMachine = stateMachine;
            _playerTransform = playerTransform;
            _movable = movable;
        }

        public void Configure(float attackDistance, float sightDistance, float chaseSpeed) {
            _attackDistance = attackDistance;
            _sightDistance = sightDistance;
            _chaseSpeed = chaseSpeed;
        }

        public void OnEnter() {
            _movable.SetSpeed(_chaseSpeed);
            MoveToPlayer();
        }

        private void MoveToPlayer() =>
            _movable.MoveToPoint(_playerTransform.position);

        public void OnUpdate() {
            MoveToPlayer();

            if (IsPlayerClose()) {
                StartAttackingPlayer();
            }
            else if (IsPlayerOutOfSight()) {
                _stateMachine.SwitchState<PatrolState>();
            }
        }

        private void StartAttackingPlayer() =>
            Debug.LogError("Attacking player!");

        private bool IsPlayerClose() {
            Vector3 playerPosition = _playerTransform.position;
            Vector3 enemyPosition = _movable.GetPoint();
            return Vector3.Distance(playerPosition, enemyPosition) < _attackDistance;
        }

        private bool IsPlayerOutOfSight() {
            Vector3 playerPosition = _playerTransform.position;
            Vector3 enemyPosition = _movable.GetPoint();
            return Vector3.Distance(playerPosition, enemyPosition) > _sightDistance;
        }
    }
}