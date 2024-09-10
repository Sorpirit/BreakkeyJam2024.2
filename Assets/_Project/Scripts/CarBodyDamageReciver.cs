using UnityEngine;

public class CarBodyDamageReciver : MonoBehaviour
{
    [SerializeField] private PrometeoCarController carController;
    [SerializeField] private CarHealthStat healthStat;
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
            healthStat.OnDamage(damage);
        }
    }
}
