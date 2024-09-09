using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Project.Scripts.Core.HubCarSelection {
    public class ChooseCarButton : MonoBehaviour {
        [SerializeField] private CarType _carType;
        [SerializeField] private Button _button;
        [SerializeField] private TMP_Text _carName;
        
        private SelectedCarModel _selectedCarModel;
        
        [Inject]
        private void InjectDependencies(SelectedCarModel selectedCarModel) =>
            _selectedCarModel = selectedCarModel;
        
        public void SetCarType(CarType carType) =>
            _carType = carType;

        private void OnEnable() =>
            _button.onClick.AddListener(OnButtonClicked);

        private void OnDisable() =>
            _button.onClick.RemoveListener(OnButtonClicked);

        private void OnButtonClicked() =>
            _selectedCarModel.SetCarType(_carType);

        public void SetCarHubItem(string carName) =>
            _carName.text = carName;
    }
}