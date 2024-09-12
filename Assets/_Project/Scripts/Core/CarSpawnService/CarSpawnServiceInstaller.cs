using _Project.Scripts.Constants;
using _Project.Scripts.Core.HubCarSelection;
using _Project.Scripts.Infrastructure.AssetLoaderModule.Scripts;
using Zenject;

namespace _Project.Scripts.Core.CarSpawnService {
    public class CarSpawnServiceInstaller : Installer<CarSpawnServiceInstaller> {
        public override void InstallBindings() {
            IAssetLoaderFacadeService loaderService = Container.Resolve<IAssetLoaderFacadeService>();
            BindCarInGamePrefabConfiguration(loaderService);

            BindSpawnCarPlatform();

            BindCarSpawnService();
        }

        private void BindCarSpawnService() =>
            Container.Bind<CarSpawnerService>().AsSingle();

        private void BindSpawnCarPlatform() =>
            Container.Bind<CarSpawnPlatform>().FromComponentInHierarchy().AsSingle();

        private void BindCarInGamePrefabConfiguration(IAssetLoaderFacadeService loaderService) {
            string addressableKey = Address.Configurations.CarInGamePrefabConfiguration;

            CarInGamePrefabConfiguration carInGamePrefabConfiguration =
                loaderService.LoadAsset<CarInGamePrefabConfiguration>(addressableKey, AssetLoadSource.Addressables);

            Container.Bind<CarInGamePrefabConfiguration>()
                .FromScriptableObject(carInGamePrefabConfiguration)
                .AsSingle();
        }
    }
}