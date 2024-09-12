
using _Project.Scripts.Core.Enemies;
using UnityEngine;
using UnityEngine.AI;

namespace Assets._Project.Scripts.Core.Enemies
{
    [RequireComponent(typeof(Rigidbody))]
    internal class RigidbodyEntityMovable : EntityMovable
    {
        [SerializeField] private NavMeshAgent _navMeshAgent;
        [SerializeField] private float _speed;
        [SerializeField] private float _rotationSpeed;

        private Rigidbody _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            if(_navMeshAgent.hasPath)
            {
                Vector3 moveDir = (_navMeshAgent.steeringTarget - transform.position).normalized;
                float distanceToDestanation = Vector3.Distance(_navMeshAgent.destination, transform.position);
                bool isFacingMoveDirection = Vector3.Dot(moveDir, transform.forward) > .5f ;

                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(moveDir), _rotationSpeed * 360.0f * Time.deltaTime);
                if(isFacingMoveDirection)
                    _rb.AddForce(moveDir * _speed, ForceMode.Acceleration);
            }
         
        }

        public override void MoveToPoint(Vector3 point) =>
            _navMeshAgent.SetDestination(point);

        public override Vector3 GetPoint() =>
            _navMeshAgent.transform.position;

        public override void SetSpeed(float speed)
        {
            _speed = speed;
        }

        private void OnDrawGizmosSelected()
        {
            if (_navMeshAgent != null && _navMeshAgent.hasPath)
            {
                for (int i = 0; i < _navMeshAgent.path.corners.Length - 1; i++)
                {
                    Debug.DrawLine(_navMeshAgent.path.corners[i], _navMeshAgent.path.corners[i + 1], Color.blue);
                }
            }
        }
    }
}
