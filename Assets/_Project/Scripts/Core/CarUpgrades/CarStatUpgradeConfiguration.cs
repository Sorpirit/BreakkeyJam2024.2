using UnityEngine;

namespace _Project.Scripts.Core.CarUpgrades {
    [CreateAssetMenu(fileName = nameof(CarStatUpgradeConfiguration) + "_Default",
        menuName = "Configurations/" + nameof(CarStatUpgradeConfiguration))]
    public abstract class CarStatUpgradeConfiguration : ScriptableObject {
        public abstract void ApplyUpgrade(CarStatsHolder carStatsHolder);
    }
}