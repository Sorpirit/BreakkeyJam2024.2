using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Project.Scripts.Core.CarUpgrades {
    public class CollisionDetector : MonoBehaviour {
        public event Action OnTriggerEntered;
        public event Action OnTriggerExited;
        
        private HashSet<Collider> _enteredColliders = new();

        private void OnTriggerEnter(Collider other) {
            if (_enteredColliders.Contains(other)) return;
            OnTriggerEntered?.Invoke();
            _enteredColliders.Add(other);
        }

        private void OnTriggerExit(Collider other) {
            if (!_enteredColliders.Contains(other)) return;
            OnTriggerExited?.Invoke();
            _enteredColliders.Remove(other);
        }
    }
}