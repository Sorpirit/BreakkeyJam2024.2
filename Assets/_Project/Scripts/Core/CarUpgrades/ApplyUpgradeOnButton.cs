using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Project.Scripts.Core.CarUpgrades {
    public class ApplyUpgradeOnButton : MonoBehaviour {
        [Inject] private CurrentCarStatsModel _currentCarStatsModel;
        [SerializeField] private CarStatUpgradeConfiguration _carStatUpgradeConfiguration;
        [SerializeField] private Button _button;

        private void OnEnable() =>
            _button.onClick.AddListener(ApplyUpgrade);

        private void OnDisable() =>
            _button.onClick.RemoveListener(ApplyUpgrade);

        private void ApplyUpgrade()
        {
            bool result = _carStatUpgradeConfiguration.TryApplyUpgrade(_currentCarStatsModel.CarStatsHolder);
            Debug.Log(result ? "Upgrade applied!" : "Unable to apply upgrade" );
        }
            
    }
}