using UnityEngine;

namespace _Project.Scripts.Core.Enemies {
    public interface IMovable {
        public void MoveToPoint(Vector3 point);
        public Vector3 GetPoint();
        public void SetSpeed(float speed);
    }
}