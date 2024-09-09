using UnityEngine;

namespace _Project.Scripts.Core.HubCarSelection {
    public class CarSpawnPlatform : MonoBehaviour {
        [field: SerializeField] public Transform SpawnParent { get; private set; }
    }
}