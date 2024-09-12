using System;
using _Project.Scripts.Core.CarUpgrades;

namespace _Project.Scripts.Core.CarSpawnService {
    [Serializable]
    public class CarToInGamePrefabItem {
        public CarType CarType;
        public CarStatsHolder CarPrefab;
    }
}