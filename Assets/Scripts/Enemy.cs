using System;
using UnityEngine;

namespace HitmasterClone
{

    public class Enemy : MonoBehaviour
    {
        public event Action<int> OnTakeDamage;
        public EnemyData Data => _data;
        private EnemyData _data;
        [SerializeField]
        private EnemyHealthUI _healthUI;
        [SerializeField]
        private Animator _animator;
        [SerializeField]
        private Collider _collider;

        private void Awake()
        {
            _data = new EnemyData(3, this);
            new EnemyAnimator(_animator, _data);
            new EnemyHealthController(_healthUI, _data, this);

            _data.OnDeath += () => _collider.enabled = false;
        }

        public void TakeDamage(int damage)
        {
            if (!_data.IsAlive)
                return;
            OnTakeDamage?.Invoke(damage);
        }
    }
}