using System;
using UnityEngine;

namespace _Project.Scripts.Core.CarUpgrades {
    public class FuelManager : MonoBehaviour {
        [SerializeField] private CarStatsHolder carStatsHolder;

        public event Action OnFuelEmpty;
        public event Action OnFuelFull;

        private void Start() =>
            carStatsHolder.CurrentFuel = carStatsHolder.MaxFuel;

        public void ConsumeFuel(float fuel) {
            carStatsHolder.CurrentFuel -= fuel;
            carStatsHolder.CurrentFuel = Mathf.Clamp(carStatsHolder.CurrentFuel, 0, carStatsHolder.MaxFuel);

            if (carStatsHolder.CurrentFuel <= 0)
                OnFuelEmpty?.Invoke();
        }

        public void AddFuel(float fuel) {
            carStatsHolder.CurrentFuel += fuel;
            carStatsHolder.CurrentFuel = Mathf.Clamp(carStatsHolder.CurrentFuel, 0, carStatsHolder.MaxFuel);

            if (carStatsHolder.CurrentFuel >= carStatsHolder.MaxFuel)
                OnFuelFull?.Invoke();
        }
    }
}