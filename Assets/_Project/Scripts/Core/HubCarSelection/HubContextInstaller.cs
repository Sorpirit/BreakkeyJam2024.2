using Zenject;

namespace _Project.Scripts.Core.HubCarSelection {
    public class HubContextInstaller : MonoInstaller {
        public override void InstallBindings() {
            InjectedPrefabFactoryInstaller.Install(Container);
            HubCarSelectionInstaller.Install(Container);
        }
    }
}