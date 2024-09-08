using _Project.Scripts.Constants;
using _Project.Scripts.Infrastructure.AssetLoaderModule.Scripts;
using Zenject;

namespace _Project.Scripts.Core.HubCarSelection {
    public class HubCarSelectionInstaller : Installer<HubCarSelectionInstaller> {
        public override void InstallBindings() {
            IAssetLoaderFacadeService loaderService = Container.Resolve<IAssetLoaderFacadeService>();
            BindCarTypeToVisualsPrefabConfiguration(loaderService);
        }

        private void BindCarTypeToVisualsPrefabConfiguration(IAssetLoaderFacadeService loaderService) {
            string addressableKey = Address.Configurations.CarTypeToVisualsPrefabConfiguration;

            CarTypeToVisualsPrefabConfiguration carTypeToVisualsPrefabConfiguration =
                loaderService.LoadAsset<CarTypeToVisualsPrefabConfiguration>(addressableKey, AssetLoadSource.Addressables);

            Container.Bind<CarTypeToVisualsPrefabConfiguration>()
                .FromScriptableObject(carTypeToVisualsPrefabConfiguration)
                .AsSingle();
        }
    }
}