using UnityEngine.SceneManagement;

namespace _Project.Scripts.Infrastructure {
    public class ScenesLoader : IScenesLoader {
        public void LoadScene(string sceneName, LoadSceneMode loadSceneMode = LoadSceneMode.Single) =>
            SceneManager.LoadScene(sceneName, loadSceneMode);
    }
}