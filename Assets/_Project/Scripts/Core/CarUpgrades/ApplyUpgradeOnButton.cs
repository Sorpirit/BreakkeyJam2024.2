using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.Core.CarUpgrades {
    public class ApplyUpgradeOnButton : MonoBehaviour {
        [SerializeField] private CarStatUpgradeConfiguration _carStatUpgradeConfiguration;
        [SerializeField] private CarStatsHolder _carStatsHolder;
        [SerializeField] private Button _button;

        private void OnEnable() =>
            _button.onClick.AddListener(ApplyUpgrade);

        private void OnDisable() =>
            _button.onClick.RemoveListener(ApplyUpgrade);

        private void ApplyUpgrade() =>
            _carStatUpgradeConfiguration.ApplyUpgrade(_carStatsHolder);
    }
}