using TMPro;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using _Project.Scripts.Core.CarUpgrades;
using Zenject;

public class UpdatePointsVisuals : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textMeshPro;
   // [Inject] private CurrentCarStatsModel _currentCarStatsModel;
    [SerializeField] private CarStatsHolder _carStatsHolder;


    void Start() {
        _textMeshPro.text = _carStatsHolder.CurrentUpdatePoints.ToString();
    }

    private void OnEnable() {
        if (_carStatsHolder != null)
            UpdatePoints();
        _carStatsHolder.OnUpdatePointsValueUpdated += UpdatePoints;

    }

    private void OnDisable() {
        _carStatsHolder.OnUpdatePointsValueUpdated -= UpdatePoints;
    }


    public void UpdatePoints() {
        
        _textMeshPro.text = _carStatsHolder.CurrentUpdatePoints.ToString();
        
    }
}
