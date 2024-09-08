using UnityEngine;

namespace _Project.Scripts.Infrastructure.AssetLoaderModule.Scripts {
    public interface IResourcesAssetLoader {
        public TAsset LoadAsset<TAsset>(string path) where TAsset : Object;
    }
}