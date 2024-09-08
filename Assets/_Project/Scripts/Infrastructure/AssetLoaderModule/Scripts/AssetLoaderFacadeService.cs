using System;
using Object = UnityEngine.Object;

namespace _Project.Scripts.Infrastructure.AssetLoaderModule.Scripts {
    public class AssetLoaderFacadeService : IAssetLoaderFacadeService {
        private readonly IAddressablesAssetLoader _addressablesAssetLoader;
        private readonly IResourcesAssetLoader _resourcesAssetLoader;

        public AssetLoaderFacadeService(IAddressablesAssetLoader addressablesAssetLoader, IResourcesAssetLoader resourcesAssetLoader) {
            _addressablesAssetLoader = addressablesAssetLoader;
            _resourcesAssetLoader = resourcesAssetLoader;
        }

        public TAsset LoadAsset<TAsset>(string path, AssetLoadSource source) where TAsset : Object =>
            source switch {
                AssetLoadSource.Addressables => _addressablesAssetLoader.LoadAsset<TAsset>(path),
                AssetLoadSource.Resources    => _resourcesAssetLoader.LoadAsset<TAsset>(path),
                _                            => throw new ArgumentOutOfRangeException()
            };
    }
}