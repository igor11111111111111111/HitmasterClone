using UnityEngine;

namespace HitmasterClone
{
    public class Enemy : MonoBehaviour
    { 
        public EnemyData Data => _data;
        private EnemyData _data;
        [SerializeField]
        private EnemyHealthUI _healthUI;
        [SerializeField]
        private Animator _animator;

        private void Awake()
        {
            _data = new EnemyData(3);
            new EnemyAnimator(_animator, _data);
            _healthUI.Refresh(_data.NormalizedHealth);

            _data.OnDeath += () => _healthUI.Enable(false);
        }

        public void TakeDamage(int damage)
        {
            if (!_data.IsAlive)
                return;

            _data.CurrentHealth -= damage;
            _healthUI.Refresh(_data.NormalizedHealth);
        }
    }
}