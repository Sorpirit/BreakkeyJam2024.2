using UnityEngine;

namespace _Project.Scripts.Core.CarUpgrades {
    public class SyncSpeedWithCarController : MonoBehaviour {
        [SerializeField] private PrometeoCarController _prometeoCarController;
        [SerializeField] private CarStatsHolder _carStatsHolder;

        private void OnEnable() {
            _carStatsHolder.OnMaxSpeedValueUpdated += UpdateMaxSpeed;
            UpdateMaxSpeed();
            UpdateSpeed();
        }

        private void OnDisable() =>
            _carStatsHolder.OnMaxSpeedValueUpdated -= UpdateMaxSpeed;

        private void LateUpdate()
        {
            UpdateSpeed();
        }

        private void UpdateMaxSpeed() =>
            _prometeoCarController.maxSpeed = (int)_carStatsHolder.MaxSpeed;

        private void UpdateSpeed() =>
            _carStatsHolder.Speed = (int) Mathf.Abs(_prometeoCarController.carSpeed);
    }
}