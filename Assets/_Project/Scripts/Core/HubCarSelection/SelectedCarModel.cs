using System;

namespace _Project.Scripts.Core.HubCarSelection {
    public class SelectedCarModel {
        private const CarType DEFAULT_CAR_TYPE = CarType.Car01;

        public CarType CarType { get; private set; } = DEFAULT_CAR_TYPE;

        public event Action<CarType> OnCarTypeChanged;

        public void SetCarType(CarType carType) {
            CarType = carType;
            OnCarTypeChanged?.Invoke(CarType);
        }
    }
}