using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CarHealthStat : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private float damageScale;

    [SerializeField] private Image healthFill;

    private float _currentHealth;

    private void Start()
    {
        _currentHealth = maxHealth;
    }

    public void OnDamage(float damage)
    {
        _currentHealth -= damage * damageScale;
        _currentHealth = Mathf.Clamp(_currentHealth, 0, maxHealth);
        healthFill.fillAmount = _currentHealth / maxHealth;
        Debug.Log("OnDamage: " + damage);
    }

    public void OnRepair(float repair)
    {
        _currentHealth = repair;
        _currentHealth = Mathf.Clamp(_currentHealth, 0, maxHealth);
        healthFill.fillAmount = _currentHealth / maxHealth;
        Debug.Log("OnRepair: " + repair);
    }
}
