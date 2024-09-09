using System;
using System.Linq;
using UnityEngine;

namespace _Project.Scripts.Core.HubCarSelection {
    [CreateAssetMenu(fileName = nameof(CarTypeToVisualsPrefabConfiguration) + "_Default",
        menuName = "Configurations/" + nameof(CarTypeToVisualsPrefabConfiguration))]
    public class CarTypeToVisualsPrefabConfiguration : ScriptableObject {
        [field: SerializeField] public CarTypeToVisualItem[] CarTypeToVisualItems { get; private set; }
        
        public GameObject GetVisualPrefab(CarType carType) =>
            CarTypeToVisualItems.Where(carTypeToVisualItem => carTypeToVisualItem.CarType == carType).Select(carTypeToVisualItem => carTypeToVisualItem.VisualPrefab).FirstOrDefault();
        
        public bool HasVisualPrefab(CarType carType) =>
            CarTypeToVisualItems.Any(carTypeToVisualItem => carTypeToVisualItem.CarType == carType);
    }

    [Serializable]
    public class CarHubItem {
        public CarType CarType;
        public Sprite Icon;
        public string Name;
    }
}