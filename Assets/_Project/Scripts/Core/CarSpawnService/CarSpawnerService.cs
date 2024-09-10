using _Project.Scripts.Core.CarUpgrades;
using _Project.Scripts.Core.HubCarSelection;
using UnityEngine;

namespace _Project.Scripts.Core.CarSpawnService {
    public class CarSpawnerService {
        private readonly SelectedCarModel _selectedCarModel;
        private readonly CurrentCarStatsModel _currentCarStatsModel;
        private readonly InjectedPrefabFactory _injectedPrefabFactory;
        private readonly CarSpawnPlatform _carSpawnPlatform;
        private readonly CarInGamePrefabConfiguration _carInGamePrefabConfiguration;
        
        public CarSpawnerService(SelectedCarModel selectedCarModel, CurrentCarStatsModel currentCarStatsModel, CarSpawnPlatform carSpawnPlatform, InjectedPrefabFactory injectedPrefabFactory, CarInGamePrefabConfiguration carInGamePrefabConfiguration) {
            _selectedCarModel = selectedCarModel;
            _currentCarStatsModel = currentCarStatsModel;
            _carSpawnPlatform = carSpawnPlatform;
            _injectedPrefabFactory = injectedPrefabFactory;
            _carInGamePrefabConfiguration = carInGamePrefabConfiguration;
        }
        
        public GameObject Spawn() {
            CarStatsHolder spawnedCar = _injectedPrefabFactory.Instantiate(_carInGamePrefabConfiguration.GetPrefabForType(_selectedCarModel.CarType), null);
            spawnedCar.transform.position = _carSpawnPlatform.SpawnParent.position;
            _currentCarStatsModel.OverrideCarStatsHolder(spawnedCar);
            return spawnedCar.gameObject;
        }
    }
}