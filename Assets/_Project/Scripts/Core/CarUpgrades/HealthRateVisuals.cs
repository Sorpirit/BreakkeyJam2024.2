using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Project.Scripts.Core.CarUpgrades {
    public class HealthRateVisuals : MonoBehaviour {
        [Inject] private CurrentCarStatsModel _currentCarStatsModel;
        [SerializeField] private Image _healthFill;

        private void OnEnable() {
            if (_currentCarStatsModel.CarStatsHolder != null)
                SubscribeToEvents();
            _currentCarStatsModel.OnCarStatsHolderChanged += SubscribeToEvents;
        }

        private void SubscribeToEvents() {
            _currentCarStatsModel.CarStatsHolder.OnHealthValueUpdated += UpdateHealthFill;
            UpdateHealthFill();
        }

        private void OnDisable() {
            _currentCarStatsModel.CarStatsHolder.OnHealthValueUpdated -= UpdateHealthFill;
            _currentCarStatsModel.OnCarStatsHolderChanged -= SubscribeToEvents;
        }

        private void UpdateHealthFill() =>
            _healthFill.fillAmount = _currentCarStatsModel.CarStatsHolder.CurrentHealth / _currentCarStatsModel.CarStatsHolder.MaxHealth;
    }
}