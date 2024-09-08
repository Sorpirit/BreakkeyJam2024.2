using _Project.Scripts.Constants;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Infrastructure {
    public class GameBootstrapper : MonoBehaviour {
        private IScenesLoader _scenesLoader;

        [Inject]
        private void InjectDependencies() =>
            _scenesLoader = new ScenesLoader();

        private void Start() =>
            LoadHubScene();

        private void LoadHubScene() =>
            _scenesLoader.LoadScene(Scenes.HUB_SCENE);
    }
}