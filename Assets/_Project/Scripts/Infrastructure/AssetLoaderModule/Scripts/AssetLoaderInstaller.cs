using Zenject;

namespace _Project.Scripts.Infrastructure.AssetLoaderModule.Scripts {
    public class AssetLoaderInstaller : Installer<AssetLoaderInstaller> {
        public override void InstallBindings() {
            BindResourcesAssetLoader();
            BindAddressablesAssetLoader();
            BindAssetLoaderFacade();
        }

        private void BindResourcesAssetLoader() =>
            Container.BindInterfacesTo<ResourcesAssetLoader>().AsSingle();

        private void BindAddressablesAssetLoader() =>
            Container.BindInterfacesTo<AddressablesAssetLoader>().AsSingle();

        private void BindAssetLoaderFacade() =>
            Container.BindInterfacesTo<AssetLoaderFacadeService>().AsSingle();
    }
}