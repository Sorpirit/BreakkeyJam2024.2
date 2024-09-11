using UnityEngine;
using UnityEngine.AI;

namespace _Project.Scripts.Core.Enemies {
    public class PatrolState : IState {
        private readonly StateMachine _stateMachine;
        private readonly IMovable _movable;
        private readonly Transform _playerTransform;

        private float _patrolRadius = 5f;
        private float _minDistanceToPatrolPoint = 0.5f;
        private float _patrolSpeed = 3f;

        private Vector3 _currentPatrolPoint;

        public PatrolState(StateMachine stateMachine, IMovable movable, Transform playerTransform) {
            _stateMachine = stateMachine;
            _movable = movable;
            _playerTransform = playerTransform;
        }

        public void Configure(float patrolRadius, float minDistanceToPatrolPoint, float patrolSpeed) {
            _patrolRadius = patrolRadius;
            _minDistanceToPatrolPoint = minDistanceToPatrolPoint;
            _patrolSpeed = patrolSpeed;
        }

        public void OnEnter() {
            _movable.SetSpeed(_patrolSpeed);
            _currentPatrolPoint = ChooseRandomPatrolPoint();
            StartMovingToPoint(_currentPatrolPoint);
        }

        private Vector3 ChooseRandomPatrolPoint() {
            Vector3 enemyPosition = _movable.GetPoint();
            return GetRandomPointOnNavMesh(enemyPosition, _patrolRadius);
        }

        private static Vector3 GetRandomPointOnNavMesh(Vector3 origin, float radius) {
            Vector3 randomDirection = GetRandomPointOnUnitCircle(radius);
            randomDirection += origin;

            NavMeshHit navHit;
            if (NavMesh.SamplePosition(randomDirection, out navHit, radius, NavMesh.AllAreas))
                return navHit.position;

            return origin;
        }

        private static Vector3 GetRandomPointOnUnitCircle(float radius = 1f) {
            float randomAngle = Random.Range(0f, Mathf.PI * 2);
            float x = Mathf.Cos(randomAngle) * radius;
            float z = Mathf.Sin(randomAngle) * radius;
            return new Vector3(x, 0f, z);
        }

        private void StartMovingToPoint(Vector3 point) =>
            _movable.MoveToPoint(point);

        public void OnUpdate() {
            if (IsCloseToPatrolPoint()) {
                _currentPatrolPoint = ChooseRandomPatrolPoint();
                StartMovingToPoint(_currentPatrolPoint);
            }
            else if (IsPlayerClose()) {
                _stateMachine.SwitchState<ChaseState>();
            }
        }

        private bool IsPlayerClose() {
            Vector3 playerPosition = _playerTransform.position;
            Vector3 enemyPosition = _movable.GetPoint();
            return Vector3.Distance(playerPosition, enemyPosition) < _patrolRadius;
        }

        private bool IsCloseToPatrolPoint() =>
            Vector3.Distance(_currentPatrolPoint, _movable.GetPoint()) < _minDistanceToPatrolPoint;
    }
}