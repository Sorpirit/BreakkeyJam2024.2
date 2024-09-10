using UnityEngine;

namespace _Project.Scripts.Core.CarUpgrades {
    [CreateAssetMenu(fileName = nameof(CarStatUpgradeConfiguration_Speed) + "_Default",
        menuName = "Configurations/" + nameof(CarStatUpgradeConfiguration_Speed))]
    public class CarStatUpgradeConfiguration_Speed : CarStatUpgradeConfiguration {
        [SerializeField] private float _speedUpgradeValue;

        public override void ApplyUpgrade(CarStatsHolder carStatsHolder) =>
            carStatsHolder.Speed += _speedUpgradeValue;
    }
}