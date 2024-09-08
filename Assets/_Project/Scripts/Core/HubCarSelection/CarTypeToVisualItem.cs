using System;
using UnityEngine;

namespace _Project.Scripts.Core.HubCarSelection {
    [Serializable]
    public class CarTypeToVisualItem {
        [field: SerializeField] public CarType CarType { get; private set; }
        [field: SerializeField] public GameObject VisualPrefab { get; private set; }
    }
}