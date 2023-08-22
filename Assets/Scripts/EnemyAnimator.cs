using UnityEngine;

namespace HitmasterClone
{
    public class EnemyAnimator
    {
        private Animator _animator;

        public EnemyAnimator(Animator animator, EnemyData data)
        {
            _animator = animator;

            data.OnDeath += Death;
        }

        private void Death()
        {
            _animator.SetTrigger("OnDeath");
        }
    }
}