using System;
using UnityEngine;

namespace _Project.Scripts.Core.CarUpgrades {
    public class CarStatsHolder : MonoBehaviour {
        [Header("Fuel")]
        [SerializeField] private float _maxFuel;

        [SerializeField] private float _currentFuel;
        [SerializeField] private float _fuelUsageScale;

        [Header("Health")]
        [SerializeField] private float _maxHealth;

        [SerializeField] private float _currentHealth;

        [Header("Damage")]
        [SerializeField] private float _minSpeedForDamage;

        [SerializeField] private float _carBodyDamageMultiplier;
        [SerializeField] private float _damageScale;

        [Header("Speed")]
        [SerializeField] private float _speed;

        public float MaxFuel { get => _maxFuel; set => _maxFuel = value; }

        public float CurrentFuel {
            get => _currentFuel;
            set {
                _currentFuel = value;
                OnFuelValueUpdated?.Invoke();
            }
        }

        public float FuelUsageScale { get => _fuelUsageScale; set => _fuelUsageScale = value; }

        public float MaxHealth {
            get => _maxHealth;
            set {
                _maxHealth = value;
                OnHealthValueUpdated?.Invoke();
            }
        }

        public float CurrentHealth {
            get => _currentHealth;
            set {
                _currentHealth = value;
                OnHealthValueUpdated?.Invoke();
            }
        }

        public float DamageScale { get => _damageScale; set => _damageScale = value; }

        public float MinSpeedForDamage { get => _minSpeedForDamage; set => _minSpeedForDamage = value; }
        public float CarBodyDamageMultiplier { get => _carBodyDamageMultiplier; set => _carBodyDamageMultiplier = value; }

        public float Speed {
            get => _speed;
            set {
                _speed = value;
                OnSpeedValueUpdated?.Invoke();
            }
        }

        public event Action OnHealthValueUpdated;
        public event Action OnSpeedValueUpdated;
        public event Action OnFuelValueUpdated;
    }
}