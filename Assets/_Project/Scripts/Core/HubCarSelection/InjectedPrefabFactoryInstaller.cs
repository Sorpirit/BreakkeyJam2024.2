using Zenject;

namespace _Project.Scripts.Core.HubCarSelection {
    public class InjectedPrefabFactoryInstaller : Installer<InjectedPrefabFactoryInstaller> {
        public override void InstallBindings() =>
            Container.Bind<InjectedPrefabFactory>().AsSingle();
    }
}