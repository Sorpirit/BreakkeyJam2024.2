
using System;

namespace _Project.Scripts.Core.CarUpgrades
{
    public class CurrentCarStatsModel
    {
        public CarStatsHolder CarStatsHolder { get; private set; }

        public event Action OnCarStatsHolderChanged;
        public void OverrideCarStatsHolder(CarStatsHolder carStatsHolder)
        {
            CarStatsHolder = carStatsHolder;
            OnCarStatsHolderChanged?.Invoke();

        }
    }
}
