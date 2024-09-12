using UnityEngine;
using UnityEngine.Serialization;

namespace _Project.Scripts.Core.CarUpgrades {
    public class CarBodyDamageReciver : MonoBehaviour
    {
        [SerializeField] private PrometeoCarController carController;
        [FormerlySerializedAs("healthStat"),SerializeField] private CarDamageable _damageable;
        [SerializeField] private Rigidbody carRb;

        [SerializeField] private float minSpeedForDamage;
        [SerializeField] private AnimationCurve speedDamageCurve;

        private void OnCollisionEnter(Collision collision)
        {
        
            float absSpeed = carRb.linearVelocity.magnitude;
            Debug.Log(collision.gameObject.name + " lV:" + absSpeed);
            if (absSpeed > minSpeedForDamage)
            {
                float damage = speedDamageCurve.Evaluate(absSpeed);
                _damageable.OnDamage(damage);
            }
        }
    }
}
