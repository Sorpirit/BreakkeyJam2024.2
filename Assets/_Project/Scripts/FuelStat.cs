using UnityEngine;
using UnityEngine.UI;

public class FuelStat : MonoBehaviour
{
    [SerializeField] private PrometeoCarController carController;
    [SerializeField] private float fuelUsageScale;
    [SerializeField] private float maxFule;

    [SerializeField] private Image fuleFill;

    private float _currentFuel;

    private void Start()
    {
        _currentFuel = maxFule;
    }

    private void Update()
    {
        if(_currentFuel > 0)
        {
            _currentFuel -= fuelUsageScale * carController.CurrentEngineTorque * Time.deltaTime;

            fuleFill.fillAmount = _currentFuel / maxFule;
        }
    }
}
