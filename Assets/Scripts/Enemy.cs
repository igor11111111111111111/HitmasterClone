using UnityEngine;

namespace HitmasterClone
{
    public class Enemy : MonoBehaviour
    {
        public EnemyData Data => _data;
        private EnemyData _data;
        [SerializeField]
        private EnemyHealthUI _healthUI;

        private void Awake()
        {
            _data = new EnemyData(3);
            new EnemyAnimator(GetComponentInChildren<Animator>(), _data);
            _data.OnDeath += () => _healthUI.Enable(false);
            _healthUI.Refresh(_data.NormalizedHealth);
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