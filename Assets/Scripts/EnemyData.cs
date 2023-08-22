using System;
using UnityEngine;

namespace HitmasterClone
{
    public class EnemyData
    {
        public Action OnDeath;

        public bool IsAlive => _isAlive;
        private bool _isAlive;

        public readonly int MaxHealth;
        public int CurrentHealth
        {
            get
            {
                return _currentHealth;
            }
            set
            {
                _currentHealth = value;
                if (_currentHealth <= 0)
                    OnDeath?.Invoke();
            }
        }
        private int _currentHealth;
        public float NormalizedHealth => CurrentHealth / (float)MaxHealth;

        public EnemyData(int health)
        {
            MaxHealth = _currentHealth = health;
            _isAlive = true;
            OnDeath += () => _isAlive = false;
        }
    }
}