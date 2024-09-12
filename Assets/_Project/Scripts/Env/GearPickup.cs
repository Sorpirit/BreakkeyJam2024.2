
using _Project.Scripts.Core.CarUpgrades;
using UnityEngine;
using Zenject;

public class GearPickup : MonoBehaviour
{
    [Inject] private CurrentCarStatsModel _currentCarStatsModel;
    [SerializeField] private int points = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody.gameObject != _currentCarStatsModel.CarStatsHolder.gameObject)
            return;

        _currentCarStatsModel.CarStatsHolder.UpgradePoints += points;
        Destroy(gameObject);
    }

}
