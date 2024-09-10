using Unity.Cinemachine;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Core.CarSpawnService {
    public class DrivingTestBootstrapper : MonoBehaviour {
        [Inject] private CarSpawnerService _carSpawnerService;
        [SerializeField] private HardLock _hardLock;
        [SerializeField] private CinemachineCamera _cinemachineCamera;
        
        
        private void Start() {
            GameObject spawnedCar = _carSpawnerService.Spawn();
            _hardLock.SetTarget(spawnedCar.transform);
            _cinemachineCamera.Follow = spawnedCar.transform;
        }
    }
}