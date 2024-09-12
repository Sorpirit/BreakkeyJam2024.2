using UnityEngine;

namespace _Project.Scripts.Core.CarUpgrades {
    [CreateAssetMenu(fileName = nameof(CarStatUpgradeConfiguration_Health) + "_Default",
        menuName = "Configurations/" + nameof(CarStatUpgradeConfiguration_Health))]
    public class CarStatUpgradeConfiguration_Health : CarStatUpgradeConfiguration {
        [SerializeField] private float _healthUpgradeValue;

        protected override void ApplyUpgrade(CarStatsHolder carStatsHolder) {
            carStatsHolder.HealthStat.MaxHealth += _healthUpgradeValue;
            carStatsHolder.HealthStat.Health += _healthUpgradeValue;
        }
    }
}