using UnityEngine;

namespace _Project.Scripts.Infrastructure.AssetLoaderModule.Scripts {
    public class ResourcesAssetLoader : IResourcesAssetLoader {
        public TAsset LoadAsset<TAsset>(string path) where TAsset : Object =>
            Resources.Load<TAsset>(path);
    }
}