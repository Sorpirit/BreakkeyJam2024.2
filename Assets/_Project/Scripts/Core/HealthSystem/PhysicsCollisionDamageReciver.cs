
using UnityEngine;

namespace Assets._Project.Scripts.Core.HealthSystem
{
    [RequireComponent(typeof(IHealthProvider))]
    public class PhysicsCollisionDamageReciver : MonoBehaviour
    {
        [SerializeField] private float activationImpulse;
        [SerializeField] private AnimationCurve damageCurve;

        private IHealthProvider healthProvider;

        private void Awake()
        {
            healthProvider = GetComponent<IHealthProvider>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            float impulse = collision.impulse.magnitude;
            Debug.Log($"Collision between: {name} vs {collision.gameObject.name} impulse = {impulse} ({(impulse < activationImpulse)}) ");
            if (impulse < activationImpulse)
                return;

            healthProvider.HealthStat.Health -= damageCurve.Evaluate(impulse - activationImpulse);
        }
    }
}
