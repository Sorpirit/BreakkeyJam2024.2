using _Project.Scripts.Core.CarUpgrades;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using _Project.Scripts.Core.CarUpgrades;
using Zenject;

public class GearInstance : MonoBehaviour
{   
    [SerializeField] private CarStatsHolder _carStatsHolder;
    [SerializeField] private int points = 10;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject != _carStatsHolder.gameObject)
            return;
        if (other.gameObject.Equals(_carStatsHolder.gameObject)) {
            Destroy(this.gameObject);
            _carStatsHolder.CurrentUpdatePoints += points; 
            Debug.Log(_carStatsHolder.CurrentUpdatePoints);
        }
    }

}
