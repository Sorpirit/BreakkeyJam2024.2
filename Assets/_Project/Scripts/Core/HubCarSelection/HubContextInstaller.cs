using Zenject;

namespace _Project.Scripts.Core.HubCarSelection {
    public class HubContextInstaller : MonoInstaller {
        public override void InstallBindings() =>
            HubCarSelectionInstaller.Install(Container);
    }
}