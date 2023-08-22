using System;
using UnityEngine;
using Zenject;

namespace HitmasterClone
{
    public class PlayerAnimator
    {
        private Animator _animator;

        public PlayerAnimator(Animator animator)
        {
            _animator = animator;
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
            _animator.SetBool("IsMove", active);
        }

        private void Shoot(Vector3 _)
        {
            _animator.SetTrigger("OnShoot");
        }

        private void InBattle(bool active)
        {
            _animator.SetBool("InBattle", active);
        }
    }
}

