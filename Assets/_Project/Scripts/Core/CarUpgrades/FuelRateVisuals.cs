using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.Core.CarUpgrades {
    public class FuelRateVisuals : MonoBehaviour {
        [SerializeField] private CarStatsHolder _carStatsHolder;
        [SerializeField] private Image _fuelFill;
    
        private void OnEnable() {
            _carStatsHolder.OnFuelValueUpdated += UpdateFuelFill;
            UpdateFuelFill();
        }
    
        private void OnDisable() =>
            _carStatsHolder.OnFuelValueUpdated -= UpdateFuelFill;

        private void UpdateFuelFill() =>
            _fuelFill.fillAmount = _carStatsHolder.CurrentFuel / _carStatsHolder.MaxFuel;
    }
}