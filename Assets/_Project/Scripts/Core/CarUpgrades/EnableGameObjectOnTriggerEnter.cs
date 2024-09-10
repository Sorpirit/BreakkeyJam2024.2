using System;
using UnityEngine;

namespace _Project.Scripts.Core.CarUpgrades {
    public class EnableGameObjectOnTriggerEnter : MonoBehaviour {
        [SerializeField] private CollisionDetector _collisionDetector;
        [SerializeField] private GameObject _gameObject;

        private void OnEnable() {
            _collisionDetector.OnTriggerEntered += ShowUpgrades;
            _collisionDetector.OnTriggerExited += HideUpgrades;
        }
        
        private void OnDisable() {
            _collisionDetector.OnTriggerEntered -= ShowUpgrades;
            _collisionDetector.OnTriggerExited -= HideUpgrades;
        }

        private void HideUpgrades() =>
            _gameObject.SetActive(false);

        private void ShowUpgrades() =>
            _gameObject.SetActive(true);
    }
}