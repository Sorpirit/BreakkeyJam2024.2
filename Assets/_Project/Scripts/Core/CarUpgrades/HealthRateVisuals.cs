using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.Core.CarUpgrades {
    public class HealthRateVisuals : MonoBehaviour
    {
        [SerializeField] private CarStatsHolder _carStatsHolder;
        [SerializeField] private Image _healthFill;

        private void OnEnable()
        {
            _carStatsHolder.OnHealthValueUpdated += UpdateHealthFill;
            UpdateHealthFill();
        }

        private void OnDisable() =>
            _carStatsHolder.OnHealthValueUpdated -= UpdateHealthFill;

        private void UpdateHealthFill() =>
            _healthFill.fillAmount = _carStatsHolder.CurrentHealth / _carStatsHolder.MaxHealth;
    }
}