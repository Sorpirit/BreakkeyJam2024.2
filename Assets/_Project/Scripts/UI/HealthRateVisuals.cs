using _Project.Scripts.Core.CarUpgrades;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Project.Scripts.UI
{
    internal class HealthRateVisuals : MonoBehaviour {
        [Inject] private CurrentCarStatsModel _currentCarStatsModel;
        [SerializeField] private Image _healthFill;

        private void OnEnable() {
            if (_currentCarStatsModel.CarStatsHolder != null)
                SubscribeToEvents();
            _currentCarStatsModel.OnCarStatsHolderChanged += SubscribeToEvents;
        }

        private void SubscribeToEvents() {
            _currentCarStatsModel.CarStatsHolder.HealthStat.OnHealthUpdated += UpdateHealthFill;
            UpdateHealthFill();
        }

        private void OnDisable() {
            _currentCarStatsModel.CarStatsHolder.HealthStat.OnHealthUpdated -= UpdateHealthFill;
            _currentCarStatsModel.OnCarStatsHolderChanged -= SubscribeToEvents;
        }

        private void UpdateHealthFill() =>
            _healthFill.fillAmount = _currentCarStatsModel.CarStatsHolder.HealthStat.Health01;
    }
}