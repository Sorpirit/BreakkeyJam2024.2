using _Project.Scripts.Core;
using _Project.Scripts.Core.HubCarSelection;
using _Project.Scripts.Infrastructure;
using _Project.Scripts.Infrastructure.AssetLoaderModule.Scripts;
using Zenject;

namespace _Project.Scripts {
    public class ProjectContextInstaller : MonoInstaller {
        public override void InstallBindings() {
            AssetLoaderInstaller.Install(Container);
            DataInstaller.Install(Container);
            BindSceneLoader();
        }

        private void BindSceneLoader() =>
            Container.Bind<IScenesLoader>().To<ScenesLoader>().AsSingle();
    }

    public class DataInstaller : Installer<DataInstaller> {
        public override void InstallBindings() =>
            Container.Bind<SelectedCarModel>().AsSingle();
    }
}