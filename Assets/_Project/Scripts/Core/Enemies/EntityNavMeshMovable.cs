using UnityEngine;
using UnityEngine.AI;

namespace _Project.Scripts.Core.Enemies {
    public class EntityNavMeshMovable : EntityMovable {
        [SerializeField] private NavMeshAgent _navMeshAgent;
        [SerializeField] private float _speed;

        private void Awake() =>
            _navMeshAgent.speed = _speed;

        public override void MoveToPoint(Vector3 point) =>
            _navMeshAgent.SetDestination(point);

        public override Vector3 GetPoint() =>
            _navMeshAgent.transform.position;

        public override void SetSpeed(float speed) {
            _navMeshAgent.speed = speed;
            _speed = speed;
        }
    }
}