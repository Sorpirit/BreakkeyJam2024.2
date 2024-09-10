using UnityEngine;

namespace _Project.Scripts.Core.CarUpgrades {
    public class SyncSpeedWithCarController : MonoBehaviour {
        [SerializeField] private PrometeoCarController _prometeoCarController;
        [SerializeField] private CarStatsHolder _carStatsHolder;

        private void OnEnable() {
            _carStatsHolder.OnSpeedValueUpdated += UpdateSpeed;
            UpdateSpeed();
        }

        private void OnDisable() =>
            _carStatsHolder.OnSpeedValueUpdated -= UpdateSpeed;

        private void UpdateSpeed() =>
            _prometeoCarController.maxSpeed = (int)_carStatsHolder.Speed;
    }
}