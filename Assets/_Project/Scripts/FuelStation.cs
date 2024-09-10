using UnityEngine;

public class FuelStation : MonoBehaviour
{
    [SerializeField] private float fullingSpeed;
    [SerializeField] private float fuellingStationMaxCapacity;

    [SerializeField] private FuelStat stat;

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
        stat.AddFuel(addFuel);
        _currentFuel -= addFuel;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody.gameObject == stat.gameObject)
        {
            _isFuellingCar = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.attachedRigidbody.gameObject == stat.gameObject)
        {
            _isFuellingCar = false;
        }
    }
}
