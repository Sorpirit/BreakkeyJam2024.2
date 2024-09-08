using System;

namespace _Project.Scripts.Core.HubCarSelection {
    public class SelectedCarModel {
        public CarType CarType { get; private set; }

        public event Action<CarType> OnCarTypeChanged;

        public void SetCarType(CarType carType) {
            CarType = carType;
            OnCarTypeChanged?.Invoke(CarType);
        }
    }
}