using System;
using UnityEngine;
using _Project.Scripts.Core.HealthSystem;

namespace _Project.Scripts.Core.CarUpgrades {
    public class CarStatsHolder : MonoBehaviour, IHealthProvider {
        [Header("Fuel")]
        [SerializeField] private float _maxFuel;

        [SerializeField] private float _currentFuel;
        [SerializeField] private float _fuelUsageScale;

        [Header("Health")]
        [SerializeField] private float _maxHealth;

        [Header("Damage")]
        [SerializeField] private float _minSpeedForDamage;

        [SerializeField] private float _carBodyDamageMultiplier;
        [SerializeField] private float _damageScale;

        [Header("Speed")]
        [SerializeField] private float _maxSpeed;
        private float _speed;

        [Header("Score")]
        [SerializeField] private float _upgradePoints;

        public float MaxFuel { get => _maxFuel; set => _maxFuel = value; }

        public float CurrentFuel {
            get => _currentFuel;
            set {
                _currentFuel = value;
                OnFuelValueUpdated?.Invoke();
            }
        }

        public float FuelUsageScale { get => _fuelUsageScale; set => _fuelUsageScale = value; }

        public float DamageScale { get => _damageScale; set => _damageScale = value; }

        public float MinSpeedForDamage { get => _minSpeedForDamage; set => _minSpeedForDamage = value; }
        public float CarBodyDamageMultiplier { get => _carBodyDamageMultiplier; set => _carBodyDamageMultiplier = value; }

        public float MaxSpeed {
            get => _maxSpeed;
            set {
                _maxSpeed = value;
                OnMaxSpeedValueUpdated?.Invoke();
            }
        }

        public float Speed 
        { 
            get => _speed; 
            set { 
                _speed = value;
                OnSpeedValueUpdated?.Invoke();
            } 
        }

        public float UpgradePoints {
            get => _upgradePoints;
            set {
                _upgradePoints = value;
                OnUpgradePointsValueUpdated?.Invoke();
            }
        }

        public HealthStat HealthStat { get; private set; }

        public event Action OnMaxSpeedValueUpdated;
        public event Action OnSpeedValueUpdated;
        public event Action OnFuelValueUpdated;
        public event Action OnUpgradePointsValueUpdated;

        private void Awake()
        {
            HealthStat = new HealthStat(_maxHealth);
        }
    }
}