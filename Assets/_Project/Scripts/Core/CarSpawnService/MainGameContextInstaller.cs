using _Project.Scripts.Core.HubCarSelection;
using Zenject;

namespace _Project.Scripts.Core.CarSpawnService {
    public class MainGameContextInstaller : MonoInstaller {
        public override void InstallBindings() {
            InjectedPrefabFactoryInstaller.Install(Container);
            CarSpawnServiceInstaller.Install(Container);
        }
    }
}