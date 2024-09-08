using UnityEngine;
using Zenject;

namespace _Project.Scripts.Core.HubCarSelection {
    public class HubCarSceneVisuals : MonoBehaviour {
        private SelectedCarModel _selectedCarModel;
        private CarTypeToVisualsPrefabConfiguration _carTypeToVisualsPrefabConfiguration;
        
        private GameObject _currentVisual;
        
        [Inject]
        private void InjectDependencies(SelectedCarModel selectedCarModel, CarTypeToVisualsPrefabConfiguration carTypeToVisualsPrefabConfiguration) {
            _selectedCarModel = selectedCarModel;
            _carTypeToVisualsPrefabConfiguration = carTypeToVisualsPrefabConfiguration;
        }

        private void OnEnable() {
            _selectedCarModel.OnCarTypeChanged += OnCarTypeChanged;
            OnCarTypeChanged(_selectedCarModel.CarType);
        }

        private void OnDisable() =>
            _selectedCarModel.OnCarTypeChanged -= OnCarTypeChanged;

        private void OnCarTypeChanged(CarType carType) {
            if (_currentVisual != null)
                Destroy(_currentVisual);

            if (_carTypeToVisualsPrefabConfiguration.HasVisualPrefab(carType))
                _currentVisual = Instantiate(_carTypeToVisualsPrefabConfiguration.GetVisualPrefab(carType));
        }
    }
}