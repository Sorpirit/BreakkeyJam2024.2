using System;

namespace Assets._Project.Scripts.Core.HealthSystem
{
    public class HealthStat
    {
        public float MaxHealth { 
            get => _maxHealth; 
            set
            { 
                _maxHealth = value;
                OnMaxHealthUpdated.Invoke(_maxHealth);
            } 
        }
        public float Health 
        { 
            get => _health; 
            set 
            {
                if (_health == value || IsDead)
                    return;

                var evnt = _health > value ? OnDamageRecived : OnHealling;
                _health = value;
                evnt.Invoke(_health);
            }  
        }

        public bool IsDead { get; private set; }

        public float Health01 => _health / MaxHealth;

        public event Action<float> OnDamageRecived;
        public event Action<float> OnHealling;
        public event Action OnDead;
        public event Action<float> OnMaxHealthUpdated;

        private float _health;
        private float _maxHealth;

        public HealthStat(float maxHealth)
        {
            _maxHealth = maxHealth;
            _health = maxHealth;   
        }
    }
}
