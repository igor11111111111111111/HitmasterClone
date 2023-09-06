using System;
using UnityEngine;
using Zenject;

namespace HitmasterClone
{
    public class PlayerAnimator
    {
        private Animator _animator;
        private HashAnimationNames _hashNames;

        public PlayerAnimator(Animator animator)
        {
            _animator = animator;
            _hashNames = new HashAnimationNames();
        }

        [Inject]
        private void Init(PlayerController controller)
        {
            controller.OnMove += Move;
            controller.OnShoot += Shoot;
            controller.OnInBattle += InBattle;
        }

        private void Move(bool active)
        {
            _animator.SetBool(_hashNames.IsMove, active);
        }

        private void Shoot(Vector3 _)
        {
            _animator.SetTrigger(_hashNames.OnShoot);
        }

        private void InBattle(bool active)
        {
            _animator.SetBool(_hashNames.InBattle, active);
        }
    }
}

