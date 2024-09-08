using _Project.Scripts.Infrastructure;
using Zenject;

namespace _Project.Scripts {
    public class BootstrapperContextInstaller : MonoInstaller<BootstrapperContextInstaller> {
        public override void InstallBindings() =>
            Container.Bind<ICoroutineRunner>().To<CoroutineRunner>().FromComponentInHierarchy().AsSingle();
    }
}