using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace _Project.Scripts.Infrastructure.AssetLoaderModule.Scripts {
    public class AddressablesAssetLoader : IAddressablesAssetLoader {
        public TAsset LoadAsset<TAsset>(string path) where TAsset : Object {
            AsyncOperationHandle<TAsset> handle = Addressables.LoadAssetAsync<TAsset>(path);
            handle.WaitForCompletion();
            return handle.Result;
        }
    }
}