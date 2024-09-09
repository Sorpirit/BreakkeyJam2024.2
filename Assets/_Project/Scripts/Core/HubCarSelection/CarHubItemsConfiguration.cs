using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Project.Scripts.Core.HubCarSelection {
    [CreateAssetMenu(fileName = nameof(CarHubItemsConfiguration) + "_Default",
        menuName = "Configurations/" + nameof(CarHubItemsConfiguration))]
    public class CarHubItemsConfiguration : ScriptableObject {
        [field: SerializeField] public CarHubItem[] CarHubItems { get; private set; }
        
        public CarHubItem GetCarHubItem(CarType carType) =>
            CarHubItems.Where(carHubItem => carHubItem.CarType == carType).FirstOrDefault();
        
        public bool HasCarHubItem(CarType carType) =>
            CarHubItems.Any(carHubItem => carHubItem.CarType == carType);
    }
}