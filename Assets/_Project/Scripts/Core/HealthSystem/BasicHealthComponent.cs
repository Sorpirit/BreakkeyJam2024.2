using UnityEngine;

namespace _Project.Scripts.Core.HealthSystem
{
    public class BasicHealthComponent : MonoBehaviour, IHealthProvider
    {
        [SerializeField] private float maxHealth;
        [SerializeField] private GameObject ragdallPrefab;
        [SerializeField] protected Transform ragdallPosition;

        private HealthStat healthStat;

        public HealthStat HealthStat => healthStat;

        private void Awake()
        {
            healthStat = new HealthStat(maxHealth);

            healthStat.OnDead += Dead;
        }

        private void Dead()
        {
            Instantiate(ragdallPrefab, ragdallPosition.position, ragdallPosition.rotation);
            Destroy(gameObject);
        }
    }
}
