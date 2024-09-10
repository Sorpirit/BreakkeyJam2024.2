using UnityEngine;
using UnityEngine.Serialization;

namespace _Project.Scripts.Core.CarUpgrades {
    public class FuelStation : MonoBehaviour
    {
        [SerializeField] private float fullingSpeed;
        [SerializeField] private float fuellingStationMaxCapacity;

        [FormerlySerializedAs("stat"),SerializeField] private FuelManager _manager;

        private bool _isFuellingCar;
        private float _currentFuel;

        private void Start()
        {
            _currentFuel = fuellingStationMaxCapacity;
        }

        private void Update()
        {
            if (!_isFuellingCar || _currentFuel < 0)
                return;

            float addFuel = fullingSpeed * Time.deltaTime;
            _manager.AddFuel(addFuel);
            _currentFuel -= addFuel;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.attachedRigidbody.gameObject == _manager.gameObject)
            {
                _isFuellingCar = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.attachedRigidbody.gameObject == _manager.gameObject)
            {
                _isFuellingCar = false;
            }
        }
    }
}
