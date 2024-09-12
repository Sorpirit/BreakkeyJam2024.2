using UnityEngine;

namespace _Project.Scripts.Core.CarUpgrades {
    [CreateAssetMenu(fileName = nameof(CarStatUpgradeConfiguration) + "_Default",
        menuName = "Configurations/" + nameof(CarStatUpgradeConfiguration))]
    public abstract class CarStatUpgradeConfiguration : ScriptableObject {

        [SerializeField] private int _upgradePointsCost;

        public int UpgradePointsCost => _upgradePointsCost;


        public bool TryApplyUpgrade(CarStatsHolder carStatsHolder)
        {
            if(carStatsHolder.UpgradePoints <  UpgradePointsCost) 
                return false;

            carStatsHolder.UpgradePoints -= UpgradePointsCost;
            ApplyUpgrade(carStatsHolder);

            return true;
        }

        protected abstract void ApplyUpgrade(CarStatsHolder carStatsHolder);
    }
}