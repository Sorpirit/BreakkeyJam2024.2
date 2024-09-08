using UnityEngine;

namespace _Project.Scripts.Infrastructure.AssetLoaderModule.Scripts {
    public interface IAssetLoaderFacadeService {
        public TAsset LoadAsset<TAsset>(string path, AssetLoadSource source) where TAsset : Object;
    }
    
    public enum AssetLoadSource {
        Addressables,
        Resources
    }
}