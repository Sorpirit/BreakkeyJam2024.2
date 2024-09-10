using UnityEngine;

namespace _Project.Scripts.Core.CarUpgrades {
    [CreateAssetMenu(fileName = nameof(CarStatUpgradeConfiguration_Fuel) + "_Default",
        menuName = "Configurations/" + nameof(CarStatUpgradeConfiguration_Fuel))]
    public class CarStatUpgradeConfiguration_Fuel : CarStatUpgradeConfiguration {
        [SerializeField] private float _fuelUpgradeValue;

        public override void ApplyUpgrade(CarStatsHolder carStatsHolder) {
            carStatsHolder.MaxFuel += _fuelUpgradeValue;
            carStatsHolder.CurrentFuel += _fuelUpgradeValue;
        }
    }
}