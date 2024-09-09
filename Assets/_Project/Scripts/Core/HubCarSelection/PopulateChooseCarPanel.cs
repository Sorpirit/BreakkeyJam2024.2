using UnityEngine;
using Zenject;

namespace _Project.Scripts.Core.HubCarSelection {
    public class PopulateChooseCarPanel : MonoBehaviour {
        [SerializeField] private CarType[] _carTypes;

        [SerializeField] private CarHubItemsConfiguration _carHubItemsConfiguration;

        [SerializeField] private Transform _contentParent;
        [SerializeField] private ChooseCarButton _chooseCarButtonPrefab;

        [Inject] private SelectedCarModel _selectedCarModel;
        [Inject] private InjectedPrefabFactory _injectedPrefabFactory;

        private void Start() {
            foreach (Transform child in _contentParent) {
                Destroy(child.gameObject);
            }

            foreach (CarType carType in _carTypes) {
                CarHubItem carHubItem = _carHubItemsConfiguration.GetCarHubItem(carType);
                if (carHubItem == null) {
                    Debug.LogError($"CarHubItem for {carType} not found");
                    continue;
                }

                ChooseCarButton chooseCarButton = _injectedPrefabFactory.Instantiate(_chooseCarButtonPrefab, _contentParent);
                chooseCarButton.SetCarType(carType);
                chooseCarButton.SetCarHubItem(carHubItem.Name);
            }
        }
    }
}