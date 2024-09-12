using UnityEngine;

namespace _Project.Scripts.Core.Enemies {
    public abstract class EntityMovable : MonoBehaviour, IMovable {
        public abstract void MoveToPoint(Vector3 point);

        public abstract Vector3 GetPoint();
        public abstract void SetSpeed(float speed);
    }
}