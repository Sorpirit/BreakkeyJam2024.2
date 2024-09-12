using _Project.Scripts.Core.CarUpgrades;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Project.Scripts.UI
{
    internal class FuelRateVisuals : MonoBehaviour 
    {
        [Inject] private CurrentCarStatsModel _currentCarStatsModel;
        [SerializeField] private Image _fuelFill;

        private void OnEnable() {
            if (_currentCarStatsModel.CarStatsHolder != null)
                SubscribeToEvents();
            _currentCarStatsModel.OnCarStatsHolderChanged += SubscribeToEvents;
        }

        private void SubscribeToEvents() {
            _currentCarStatsModel.CarStatsHolder.OnFuelValueUpdated += UpdateFuelFill;
            UpdateFuelFill();
        }

        private void OnDisable() {
            _currentCarStatsModel.CarStatsHolder.OnFuelValueUpdated -= UpdateFuelFill;
            _currentCarStatsModel.OnCarStatsHolderChanged -= SubscribeToEvents;
        }

        private void UpdateFuelFill() =>
            _fuelFill.fillAmount = _currentCarStatsModel.CarStatsHolder.CurrentFuel / _currentCarStatsModel.CarStatsHolder.MaxFuel;
    }
}