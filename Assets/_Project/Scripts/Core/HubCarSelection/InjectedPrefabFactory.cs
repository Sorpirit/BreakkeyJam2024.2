using UnityEngine;
using Zenject;

namespace _Project.Scripts.Core.HubCarSelection {
    public class InjectedPrefabFactory {
        private readonly DiContainer _container;

        public InjectedPrefabFactory(DiContainer container) =>
            _container = container;

        public T Instantiate<T>(T prefab, Transform parent) where T : MonoBehaviour =>
            _container.InstantiatePrefabForComponent<T>(prefab, parent);
    }
}