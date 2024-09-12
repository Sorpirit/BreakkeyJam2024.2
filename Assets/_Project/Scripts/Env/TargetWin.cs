using _Project.Scripts.Core.CarUpgrades;
using UnityEngine;
using Zenject;

public class TargetWin : MonoBehaviour
{
    [SerializeField] private GameObject winScreen;
    [Inject] private CurrentCarStatsModel _currentCarStatsModel;

    private void Start()
    {
        winScreen.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody.gameObject != _currentCarStatsModel.CarStatsHolder.gameObject)
            return;

        winScreen.SetActive(true);
    }
}
