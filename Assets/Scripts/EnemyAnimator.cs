using UnityEngine;

namespace HitmasterClone
{
    public class EnemyAnimator
    {
        private Animator _animator;
        private HashAnimationNames _hashNames;

        public EnemyAnimator(Animator animator, EnemyData data)
        {
            _animator = animator;
            _hashNames = new HashAnimationNames();

            data.OnDeath += Death;
        }

        private void Death()
        {
            _animator.SetTrigger(_hashNames.OnDeath);
        }
    }
}