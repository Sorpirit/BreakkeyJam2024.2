using System;
using UnityEngine;

namespace _Project.Scripts.Core.CarUpgrades {
    public class CarDamageable : MonoBehaviour {
        [SerializeField] private CarStatsHolder _carStatsHolder;

        public event Action OnDamaged;
        public event Action OnRepaired;

        public void OnDamage(float damage) {
            float newHealth = _carStatsHolder.CurrentHealth - damage * _carStatsHolder.DamageScale;
            _carStatsHolder.CurrentHealth = (Mathf.Clamp(newHealth, 0, _carStatsHolder.MaxHealth));
            OnDamaged?.Invoke();
        }

        public void OnRepair(float repair) {
            float newHealth = _carStatsHolder.CurrentHealth + repair;
            _carStatsHolder.CurrentHealth = Mathf.Clamp(newHealth, 0, _carStatsHolder.MaxHealth);
            OnRepaired?.Invoke();
        }
    }

    public class CurrentCarStatsModel {
        public CarStatsHolder CarStatsHolder { get; set; }
    }
}