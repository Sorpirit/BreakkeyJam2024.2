using UnityEngine;

namespace _Project.Scripts.Core.CarUpgrades {
    public class FuelConsumer : MonoBehaviour {
        [SerializeField] private CarStatsHolder _carStatsHolder;
        [SerializeField] private PrometeoCarController _carController;
        [SerializeField] private FuelManager _fuelManager;

        private void Update() {
            if (_carStatsHolder.CurrentFuel > 0) {
                float fuelToConsume = _carStatsHolder.FuelUsageScale * _carController.CurrentEngineTorque * Time.deltaTime;
                _fuelManager.ConsumeFuel(fuelToConsume);
            }
        }
    }
}