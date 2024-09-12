using UnityEngine;

namespace Assets._Project.Scripts.Core.HealthSystem
{
    public class BasicHealthComponent : MonoBehaviour, IHealthProvider
    {
        [SerializeField] private float maxHealth;

        private HealthStat healthStat;

        public HealthStat HealthStat => healthStat;

        private void Awake()
        {
            healthStat = new HealthStat(maxHealth);
        }
    }
}
