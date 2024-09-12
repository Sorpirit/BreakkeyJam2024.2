using _Project.Scripts.Core.CarUpgrades;
using UnityEngine;

namespace _Project.Scripts.Core.CarSpawnService {
    [CreateAssetMenu(fileName = nameof(CarInGamePrefabConfiguration) + "_Default",
        menuName = "Configurations/" + nameof(CarInGamePrefabConfiguration))]
    public class CarInGamePrefabConfiguration : ScriptableObject {
        [SerializeField] private CarToInGamePrefabItem[] _carPrefabs;

        public CarStatsHolder GetPrefabForType(CarType carType) {
            foreach (CarToInGamePrefabItem carPrefab in _carPrefabs)
                if (carPrefab.CarType == carType)
                    return carPrefab.CarPrefab;

            return null;
        }
    }
}