using _Project.Scripts.Core.CarUpgrades;
using TMPro;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.UI
{
    internal class UpgradePointsVisuals : MonoBehaviour
    {
        [Inject] private CurrentCarStatsModel _currentCarStatsModel;
        [SerializeField] private TMP_Text _upgradePoints;

        private void OnEnable()
        {
            if (_currentCarStatsModel.CarStatsHolder != null)
                SubscribeToEvents();
            _currentCarStatsModel.OnCarStatsHolderChanged += SubscribeToEvents;
        }

        private void SubscribeToEvents()
        {
            _currentCarStatsModel.CarStatsHolder.OnUpgradePointsValueUpdated += UpdateUpgradePoints;
            UpdateUpgradePoints();
        }

        private void OnDisable()
        {
            _currentCarStatsModel.CarStatsHolder.OnUpgradePointsValueUpdated -= UpdateUpgradePoints;
            _currentCarStatsModel.OnCarStatsHolderChanged -= SubscribeToEvents;
        }

        private void UpdateUpgradePoints() =>
            _upgradePoints.text = "Gears:" + _currentCarStatsModel.CarStatsHolder.UpgradePoints;
    }
}
