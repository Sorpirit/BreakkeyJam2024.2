using UnityEngine.SceneManagement;

namespace _Project.Scripts.Infrastructure {
    public interface IScenesLoader {
        public void LoadScene(string sceneName, LoadSceneMode loadSceneMode = LoadSceneMode.Single);
    }
}