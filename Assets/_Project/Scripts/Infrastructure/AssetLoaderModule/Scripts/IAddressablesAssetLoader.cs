using UnityEngine;

namespace _Project.Scripts.Infrastructure.AssetLoaderModule.Scripts {
    public interface IAddressablesAssetLoader {
        public TAsset LoadAsset<TAsset>(string path) where TAsset : Object;
    }
}