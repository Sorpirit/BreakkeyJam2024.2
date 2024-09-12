using _Project.Scripts.Core.CarUpgrades;
using TMPro;
using UnityEngine;
using Zenject;

namespace Assets._Project.Scripts.UI
{
    internal class SpeedVisuals : MonoBehaviour
    {
        [Inject] private CurrentCarStatsModel _currentCarStatsModel;
        [SerializeField] private TMP_Text _speed;

        private void OnEnable()
        {
            if (_currentCarStatsModel.CarStatsHolder != null)
                SubscribeToEvents();
            _currentCarStatsModel.OnCarStatsHolderChanged += SubscribeToEvents;
        }

        private void SubscribeToEvents()
        {
            _currentCarStatsModel.CarStatsHolder.OnSpeedValueUpdated += UpdateSpeed;
            UpdateSpeed();
        }

        private void OnDisable()
        {
            _currentCarStatsModel.CarStatsHolder.OnSpeedValueUpdated -= UpdateSpeed;
            _currentCarStatsModel.OnCarStatsHolderChanged -= SubscribeToEvents;
        }

        private void UpdateSpeed() =>
            _speed.text = _currentCarStatsModel.CarStatsHolder.Speed.ToString();
    }
}
